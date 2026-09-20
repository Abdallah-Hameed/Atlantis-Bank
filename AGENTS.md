# قواعد مشروع Atlantis Bank

هذا الملف يسجل القوانين والاتفاقيات المعمول بها في المشروع لضمان الثبات عند أي عمل قادم.

## البنية (4 مشاريع / Three-Tier Architecture)
- `Atlantis Bank` — WinForms (.NET Framework 4.8) — الواجهة، namespace `Atlantis_Bank`. تشاور على **BLL فقط** (ممنوع مباشرة على DAL أو Models).
- `Atlantis Bank-BLL` — المنطق، namespace `Atlantis_Bank_BLL`. يشاور على DAL + Models.
- `Atlantis Bank-DAL` — الوصول للبيانات، namespace `Atlantis_Bank_DAL`. يشاور على Models.
- `Atlantis Bank-Models` — الكيانات (POCO)، namespace `AtlantisBank.Models` (ملاحظة: تختلف عن RootNamespace).

## أمر البناء
```
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "Atlantis Bank.sln" /t:Build /p:Configuration=Debug /v:minimal /nologo
```
- بعد أي تعديل: البناء إلزامي للتأكد (MSBuild من جذر المشروع).

## قاعدة البيانات
- Server `.;` Database `AtlantisBankDB`, `User Id=sa; Password=sa123456`.
- Connection string hardcoded في `Atlantis Bank-DAL/clsDataAccessSettings.cs` (سطر 11). `App.config` لم يستخدم بعد.
- **الوصول للبيانات عبر Stored Procedures فقط**:
  - ممنوع SQL مضمّن (inline SQL)، ممنوع `SELECT *`، ممنوع dynamic SQL.
  - تسمية SPs: `SP_AddX`, `SP_GetXByID`, `SP_GetXByNationalNo`, `SP_GetAllX`.
- SPs الموجودة: `SP_AddEmployee`, `SP_AddClient`, `SP_GetEmployeeByID`, `SP_GetEmployeeByNationalNo`, `SP_GetClientByID`, `SP_GetClientByNationalNo`, `SP_GetAllEmployees`, `SP_GetAllClients`.
- جَدول `Branches` فاضي (0 صفوف) — أي إدراج اختباري سيفشل FK حتى يُضاف فرع.
- `People` جدول مشترك: إضافة موظف = People → Users → Employees (المعالجة جوخ SP_AddEmployee). إضافة عميل = People → Customers.

## قوانين DAL
- ممنوع نهائيًا: `SqlDataAdapter`, `DataSet`, `DataTable`. فقط `SqlDataReader`.
- كل `SqlConnection` / `SqlCommand` / `SqlDataReader` داخل `using`.
- `command.CommandType = CommandType.StoredProcedure;` و معاملات عبر `AddWithValue` (والاختلاف `DBNull.Value` للقيم nullable).
- صفر business logic في DAL — DAL فقط يقرأ/يكتب.
- **سجل واحد**: pattern كلاسيكي `bool` + `ref` للـ outputs، ترجع `true` لو وُجد الصف، `false` لو لا يوجد أو حدث استثناء (داخل `try/catch`)، والقيم عند الفشل: معرفات `-1`/سلاسل فارغة.
- **إضافة**: ترجع id الجديد (`int`، `-1` عند الفشل)، والـ identitys الفرعية تُخرج `ref` (مثل `PersonID`, `UserID`).
- **مجموعة**: ترجع `List<Model>` من `AtlantisBank.Models`، مبنية بـ mapping يدوي أثناء `while (reader.Read())`.
- ملاحظة حالية غير متسقة: `GetAll*` بدون `try/catch` على عكس دوال السجل الواحد — القرار القادم إما توحيدها كلها بـ try/catch أو بدون.
- ممنوع إنشاء فئات DTO — الكيانات في مشروع Models. ممنوع دوال helper `ReadEmployee`/`ReadClient` — mapping يتم جوه دالة DAL نفسها.
- الأعمدة nullable تُقرأ بالشكل: `reader["X"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["X"]`.

## الكيانات (Models)
- `Employee`: EmployeeID, PersonID, UserID, FirstName, SecondName, LastName, NationalNo, Gender(bool), CountryID, DateOfBirth, HireDate, ExitDate(DateTime?), Salary(decimal), BranchID.
- `Client`: CustomerID, PersonID, FirstName, SecondName, LastName, NationalNo, Gender, CountryID, DateOfBirth, RegDate, BranchID, IsActive.
- `Gender` من النوع `bool` (bit في DB).

## الواجهة (WinForms)
- تنظيم الملفات: `Main Screens/`, `Employee/Forms/`, `Employee/Controls/`, `Admin/`, `Client/`.
- namespace الفورم `Atlantis_Bank` (ماعدا `ctrlEmployeeInfo` في `Atlantis_Bank.Employee.Controls`).
- أي فورم/كونترول جديد **يجب إضافته يدويًا** إلى `Atlantis Bank.csproj` (ملف قديم النمط، لا wildcard).
- فورم الإضافة/التعديل الحالية (`frmAddUpdateEmployee/Admin/Client`) بدون mode — لم يُحدد بعد تمييز إضافة vs تعديل.
- الـ grids (`dgvEmployees` في فورم الـ Management) غير متعبّاة بالبيانات بعد — الربط مع BLL لم يبدأ.
- `ctrlEmployeeInfo` يعرض حاليا بيانات sample (ويحتوي Email/Phone/Address غير موجودة في السكيما) ولم يُستخدم في أي فورم بعد.

## حالة العمل (أين وصلنا)
- تم: SPs الأساسية، DAL (إضافة + بحث فردي ref-style + `GetAll*` ➜ List<Model>), مشروع Models, كل الفورم بنيتها وnavigation بينها.
- لم يبدأ: محتوى BLL (`clsEmployee`/`clsClient` فارغان تقريبا)، ربط UI بالبيانات، login/auth فعلي، التعامل مع `Branches` الفارغة.