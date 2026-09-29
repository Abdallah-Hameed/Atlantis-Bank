using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

// ============================================================
// ENTRY POINT
// ============================================================
Console.Title = "Atlantis Bank - Console Client";

while (true)
{
    if (!TokenManager.IsLoggedIn)
        await AuthMenu.ShowAsync();
    else
        await MainMenu.ShowAsync();
}


// ============================================================
// TOKEN MANAGER
// ============================================================
public static class TokenManager
{
    public static string? AccessToken { get; set; }
    public static string? RefreshToken { get; set; }
    public static string? UserName { get; set; }

    public static bool IsLoggedIn => !string.IsNullOrEmpty(AccessToken);

    public static void Clear()
    {
        AccessToken = null;
        RefreshToken = null;
        UserName = null;
    }
}


// ============================================================
// API CLIENT
// ============================================================
public class ApiResult
{
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? Body { get; set; }
}

public static class ApiClient
{
    private const string BaseUrl = "https://localhost:7282";

    private static readonly HttpClient http = new(new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    });

    public static Task<ApiResult> GetAsync(string endpoint) => SendAsync(HttpMethod.Get, endpoint, null);
    public static Task<ApiResult> PostAsync(string endpoint, object? body) => SendAsync(HttpMethod.Post, endpoint, body);
    public static Task<ApiResult> PutAsync(string endpoint, object? body) => SendAsync(HttpMethod.Put, endpoint, body);
    public static Task<ApiResult> DeleteAsync(string endpoint) => SendAsync(HttpMethod.Delete, endpoint, null);

    private static async Task<ApiResult> SendAsync(HttpMethod method, string endpoint, object? body)
    {
        try
        {
            var response = await SendOnceAsync(method, endpoint, body);

            if (response.StatusCode == HttpStatusCode.Unauthorized && TokenManager.IsLoggedIn)
            {
                bool refreshed = await TryRefreshAsync();
                if (refreshed)
                    response = await SendOnceAsync(method, endpoint, body);
            }

            string bodyText = await response.Content.ReadAsStringAsync();

            return new ApiResult
            {
                Success = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                Body = bodyText
            };
        }
        catch (HttpRequestException ex)
        {
            return new ApiResult
            {
                Success = false,
                StatusCode = HttpStatusCode.ServiceUnavailable,
                Body = $"Connection failed: {ex.Message}"
            };
        }
    }

    private static async Task<HttpResponseMessage> SendOnceAsync(HttpMethod method, string endpoint, object? body)
    {
        var request = new HttpRequestMessage(method, BaseUrl + endpoint);

        if (body != null)
            request.Content = JsonContent.Create(body);

        if (TokenManager.IsLoggedIn)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.AccessToken);

        return await http.SendAsync(request);
    }

    private static async Task<bool> TryRefreshAsync()
    {
        if (string.IsNullOrEmpty(TokenManager.RefreshToken) || string.IsNullOrEmpty(TokenManager.UserName))
            return false;

        var refreshDto = new
        {
            userName = TokenManager.UserName,
            refreshToken = TokenManager.RefreshToken
        };

        try
        {
            var response = await http.PostAsJsonAsync($"{BaseUrl}/api/Auth/refresh", refreshDto);

            if (!response.IsSuccessStatusCode)
            {
                TokenManager.Clear();
                return false;
            }

            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var root = doc.RootElement;

            TokenManager.AccessToken = root.GetProperty("accessToken").GetString();
            TokenManager.RefreshToken = root.GetProperty("refreshToken").GetString();
            return true;
        }
        catch
        {
            TokenManager.Clear();
            return false;
        }
    }
}


// ============================================================
// UI HELPERS
// ============================================================
public static class UI
{
    public static void Header(string title)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════╗");
        Console.WriteLine($"║  {title.PadRight(43)}║");
        Console.WriteLine("╚═══════════════════════════════════════════════╝");
        Console.WriteLine();
    }

    public static void SubHeader(string title)
    {
        Console.WriteLine($"─── {title} ───\n");
    }

    public static string Prompt(string label)
    {
        Console.Write($"{label}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string PromptRequired(string label)
    {
        while (true)
        {
            var value = Prompt(label);
            if (!string.IsNullOrWhiteSpace(value)) return value;
            Console.WriteLine("⚠️  This field is required.");
        }
    }

    public static int PromptInt(string label)
    {
        while (true)
        {
            var value = Prompt(label);
            if (int.TryParse(value, out int result)) return result;
            Console.WriteLine("⚠️  Please enter a valid number.");
        }
    }

    public static decimal PromptDecimal(string label)
    {
        while (true)
        {
            var value = Prompt(label);
            if (decimal.TryParse(value, out decimal result)) return result;
            Console.WriteLine("⚠️  Please enter a valid decimal.");
        }
    }

    public static bool PromptBool(string label)
    {
        while (true)
        {
            var value = Prompt($"{label} (y/n)").ToLower();
            if (value == "y" || value == "yes") return true;
            if (value == "n" || value == "no") return false;
            Console.WriteLine("⚠️  Please enter 'y' or 'n'.");
        }
    }

    public static DateTime PromptDate(string label)
    {
        while (true)
        {
            var value = Prompt($"{label} (yyyy-MM-dd)");
            if (DateTime.TryParse(value, out DateTime result)) return result;
            Console.WriteLine("⚠️  Please enter a valid date.");
        }
    }

    public static string ReadPassword()
    {
        string password = "";
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter) break;

            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[..^1];
                Console.Write("\b \b");
            }
            else if (key.Key != ConsoleKey.Backspace)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }
        Console.WriteLine();
        return password;
    }

    public static void ShowResult(ApiResult r)
    {
        var color = r.Success ? ConsoleColor.Green : ConsoleColor.Red;
        var icon = r.Success ? "✅" : "❌";

        Console.ForegroundColor = color;
        Console.WriteLine($"\n{icon} [{(int)r.StatusCode} {r.StatusCode}]");
        Console.ResetColor();

        if (!string.IsNullOrWhiteSpace(r.Body))
            PrintPrettyJson(r.Body);
    }

    public static void PrintPrettyJson(string json)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            var pretty = JsonSerializer.Serialize(doc.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(pretty);
            Console.ResetColor();
        }
        catch
        {
            Console.WriteLine(json);
        }
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static int AskChoice(int min, int max)
    {
        while (true)
        {
            Console.Write("\nChoose an option: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                return choice;

            Console.WriteLine("⚠️  Invalid choice.");
        }
    }
}


// ============================================================
// AUTH MENU
// ============================================================
public static class AuthMenu
{
    public static async Task ShowAsync()
    {
        UI.Header("ATLANTIS BANK - LOGIN");
        UI.SubHeader("Enter credentials");

        string user = UI.PromptRequired("Username");
        Console.Write("Password: ");
        string pass = UI.ReadPassword();

        if (string.IsNullOrEmpty(pass))
        {
            Console.WriteLine("\n❌ Password is required.");
            UI.Pause();
            return;
        }

        var loginDto = new { userName = user, password = pass };
        var result = await ApiClient.PostAsync("/api/Auth/login", loginDto);

        if (!result.Success)
        {
            Console.WriteLine($"\n❌ Login failed: {result.Body}");
            UI.Pause();
            return;
        }

        using var doc = JsonDocument.Parse(result.Body!);
        var root = doc.RootElement;

        TokenManager.AccessToken = root.GetProperty("accessToken").GetString();
        TokenManager.RefreshToken = root.GetProperty("refreshToken").GetString();
        TokenManager.UserName = user;

        Console.WriteLine($"\n✅ Welcome, {user}!");
        UI.Pause();
    }
}


// ============================================================
// MAIN MENU
// ============================================================
public static class MainMenu
{
    public static async Task ShowAsync()
    {
        UI.Header("ATLANTIS BANK - MAIN MENU");
        Console.WriteLine($"👤 Logged in as: {TokenManager.UserName}\n");

        Console.WriteLine("  1. Clients Management");
        Console.WriteLine("  2. Employees Management");
        Console.WriteLine("  3. Users Management");
        Console.WriteLine("  4. Accounts Management");
        Console.WriteLine("  5. Account Types");
        Console.WriteLine("  6. Transactions");
        Console.WriteLine("  7. Roles & Positions");
        Console.WriteLine("  8. Show Access Token");
        Console.WriteLine("  9. Logout");
        Console.WriteLine("  0. Exit");

        int choice = UI.AskChoice(0, 9);

        switch (choice)
        {
            case 1: await ClientMenu.ShowAsync(); break;
            case 2: await EmployeeMenu.ShowAsync(); break;
            case 3: await UserMenu.ShowAsync(); break;
            case 4: await AccountMenu.ShowAsync(); break;
            case 5: await AccountTypeMenu.ShowAsync(); break;
            case 6: await TransactionMenu.ShowAsync(); break;
            case 7: await LookupMenu.ShowAsync(); break;
            case 8: ShowToken(); break;
            case 9: await LogoutAsync(); break;
            case 0: Environment.Exit(0); break;
        }
    }

    private static void ShowToken()
    {
        UI.SubHeader("Access Token");
        Console.WriteLine(TokenManager.AccessToken);
        Console.WriteLine("\n💡 Paste into https://jwt.io to inspect claims.");
        UI.Pause();
    }

    private static async Task LogoutAsync()
    {
        var dto = new
        {
            userName = TokenManager.UserName,
            refreshToken = TokenManager.RefreshToken
        };

        await ApiClient.PostAsync("/api/Auth/logout", dto);

        TokenManager.Clear();
        Console.WriteLine("\n✅ Logged out.");
        UI.Pause();
    }
}


// ============================================================
// CLIENT MENU
// ============================================================
public static class ClientMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("CLIENTS MANAGEMENT");
            Console.WriteLine("  1. List all clients");
            Console.WriteLine("  2. Get client by ID");
            Console.WriteLine("  3. Add client");
            Console.WriteLine("  4. Update client");
            Console.WriteLine("  5. Delete client");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 5);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await ListAsync(); break;
                case 2: await GetByIdAsync(); break;
                case 3: await AddAsync(); break;
                case 4: await UpdateAsync(); break;
                case 5: await DeleteAsync(); break;
            }
        }
    }

    private static async Task ListAsync()
    {
        var r = await ApiClient.GetAsync("/api/Client/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetByIdAsync()
    {
        int id = UI.PromptInt("Client ID");
        var r = await ApiClient.GetAsync($"/api/Client/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task AddAsync()
    {
        UI.SubHeader("Add New Client");

        var dto = new
        {
            firstName = UI.PromptRequired("First Name"),
            secondName = UI.PromptRequired("Second Name"),
            lastName = UI.PromptRequired("Last Name"),
            nationalNo = UI.PromptRequired("National Number"),
            gender = UI.PromptBool("Gender (y=Male, n=Female)"),
            countryID = UI.PromptInt("Country ID"),
            dateOfBirth = UI.PromptDate("Date of Birth"),
            address = UI.Prompt("Address"),
            email = UI.Prompt("Email"),
            phone = UI.Prompt("Phone"),
            imagePath = "",
            branchID = UI.PromptInt("Branch ID")
        };

        var r = await ApiClient.PostAsync("/api/Client/Add", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task UpdateAsync()
    {
        int id = UI.PromptInt("Client ID");
        UI.SubHeader("Update Client");

        var dto = new
        {
            firstName = UI.PromptRequired("First Name"),
            secondName = UI.PromptRequired("Second Name"),
            lastName = UI.PromptRequired("Last Name"),
            nationalNo = UI.PromptRequired("National Number"),
            gender = UI.PromptBool("Gender (y=Male, n=Female)"),
            countryID = UI.PromptInt("Country ID"),
            dateOfBirth = UI.PromptDate("Date of Birth"),
            address = UI.Prompt("Address"),
            email = UI.Prompt("Email"),
            phone = UI.Prompt("Phone"),
            imagePath = "",
            branchID = UI.PromptInt("Branch ID")
        };

        var r = await ApiClient.PutAsync($"/api/Client/{id}", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task DeleteAsync()
    {
        int id = UI.PromptInt("Client ID");
        var r = await ApiClient.DeleteAsync($"/api/Client/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }
}


// ============================================================
// EMPLOYEE MENU
// ============================================================
public static class EmployeeMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("EMPLOYEES MANAGEMENT");
            Console.WriteLine("  1. List all employees");
            Console.WriteLine("  2. Get employee by ID");
            Console.WriteLine("  3. Add employee");
            Console.WriteLine("  4. Update employee");
            Console.WriteLine("  5. Delete employee");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 5);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await ListAsync(); break;
                case 2: await GetByIdAsync(); break;
                case 3: await AddAsync(); break;
                case 4: await UpdateAsync(); break;
                case 5: await DeleteAsync(); break;
            }
        }
    }

    private static async Task ListAsync()
    {
        var r = await ApiClient.GetAsync("/api/Employee/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetByIdAsync()
    {
        int id = UI.PromptInt("Employee ID");
        var r = await ApiClient.GetAsync($"/api/Employee/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task AddAsync()
    {
        UI.SubHeader("Add New Employee");

        var dto = new
        {
            firstName = UI.PromptRequired("First Name"),
            secondName = UI.PromptRequired("Second Name"),
            lastName = UI.PromptRequired("Last Name"),
            nationalNumber = UI.PromptRequired("National Number"),
            gender = UI.PromptBool("Gender (y=Male, n=Female)"),
            countryID = UI.PromptInt("Country ID"),
            dateOfBirth = UI.PromptDate("Date of Birth"),
            address = UI.Prompt("Address"),
            email = UI.Prompt("Email"),
            phone = UI.Prompt("Phone"),
            imagePath = "",
            branchID = UI.PromptInt("Branch ID"),
            positionID = UI.PromptInt("Position ID"),
            hireDate = DateTime.UtcNow,
            exitDate = (DateTime?)null,
            salary = UI.PromptDecimal("Salary"),
            isActive = true
        };

        var r = await ApiClient.PostAsync("/api/Employee/Add", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task UpdateAsync()
    {
        int id = UI.PromptInt("Employee ID");
        UI.SubHeader("Update Employee");

        var dto = new
        {
            firstName = UI.PromptRequired("First Name"),
            secondName = UI.PromptRequired("Second Name"),
            lastName = UI.PromptRequired("Last Name"),
            nationalNumber = UI.PromptRequired("National Number"),
            gender = UI.PromptBool("Gender (y=Male, n=Female)"),
            countryID = UI.PromptInt("Country ID"),
            dateOfBirth = UI.PromptDate("Date of Birth"),
            address = UI.Prompt("Address"),
            email = UI.Prompt("Email"),
            phone = UI.Prompt("Phone"),
            imagePath = "",
            branchID = UI.PromptInt("Branch ID"),
            positionID = UI.PromptInt("Position ID"),
            hireDate = UI.PromptDate("Hire Date"),
            exitDate = UI.PromptDate("Exit Date"),
            salary = UI.PromptDecimal("Salary"),
            isActive = UI.PromptBool("Is Active")
        };

        var r = await ApiClient.PutAsync($"/api/Employee/{id}", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task DeleteAsync()
    {
        int id = UI.PromptInt("Employee ID");
        var r = await ApiClient.DeleteAsync($"/api/Employee/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }
}


// ============================================================
// USER MENU
// ============================================================
public static class UserMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("USERS MANAGEMENT");
            Console.WriteLine("  1. List all users");
            Console.WriteLine("  2. Get user by ID");
            Console.WriteLine("  3. Add user");
            Console.WriteLine("  4. Update user");
            Console.WriteLine("  5. Delete user");
            Console.WriteLine("  6. Change password");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 6);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await ListAsync(); break;
                case 2: await GetByIdAsync(); break;
                case 3: await AddAsync(); break;
                case 4: await UpdateAsync(); break;
                case 5: await DeleteAsync(); break;
                case 6: await ChangePasswordAsync(); break;
            }
        }
    }

    private static async Task ListAsync()
    {
        var r = await ApiClient.GetAsync("/api/User/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetByIdAsync()
    {
        int id = UI.PromptInt("User ID");
        var r = await ApiClient.GetAsync($"/api/User/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task AddAsync()
    {
        UI.SubHeader("Add New User");

        var dto = new
        {
            userName = UI.PromptRequired("Username"),
            password = UI.PromptRequired("Password"),
            active = UI.PromptBool("Active"),
            roleID = UI.PromptInt("Role ID"),
            employeeID = UI.PromptInt("Employee ID")
        };

        var r = await ApiClient.PostAsync("/api/User/Add", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task UpdateAsync()
    {
        int id = UI.PromptInt("User ID");
        UI.SubHeader("Update User");

        var dto = new
        {
            userName = UI.PromptRequired("Username"),
            active = UI.PromptBool("Active"),
            roleID = UI.PromptInt("Role ID")
        };

        var r = await ApiClient.PutAsync($"/api/User/{id}", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task DeleteAsync()
    {
        int id = UI.PromptInt("User ID");
        var r = await ApiClient.DeleteAsync($"/api/User/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task ChangePasswordAsync()
    {
        int id = UI.PromptInt("User ID");
        UI.SubHeader("Change Password");

        Console.Write("Old Password (empty for Super Admin reset): ");
        string oldPass = UI.ReadPassword();

        Console.Write("New Password: ");
        string newPass = UI.ReadPassword();

        var dto = new
        {
            oldPassword = oldPass,
            newPassword = newPass
        };

        var r = await ApiClient.PutAsync($"/api/User/{id}/ChangePassword", dto);
        UI.ShowResult(r);
        UI.Pause();
    }
}


// ============================================================
// ACCOUNT MENU
// ============================================================
public static class AccountMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("ACCOUNTS MANAGEMENT");
            Console.WriteLine("  1. List all accounts");
            Console.WriteLine("  2. Get account by ID");
            Console.WriteLine("  3. Get account balance");
            Console.WriteLine("  4. Add account");
            Console.WriteLine("  5. Update account");
            Console.WriteLine("  6. Delete account");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 6);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await ListAsync(); break;
                case 2: await GetByIdAsync(); break;
                case 3: await GetBalanceAsync(); break;
                case 4: await AddAsync(); break;
                case 5: await UpdateAsync(); break;
                case 6: await DeleteAsync(); break;
            }
        }
    }

    private static async Task ListAsync()
    {
        var r = await ApiClient.GetAsync("/api/Account/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetByIdAsync()
    {
        int id = UI.PromptInt("Account ID");
        var r = await ApiClient.GetAsync($"/api/Account/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetBalanceAsync()
    {
        int id = UI.PromptInt("Account ID");
        var r = await ApiClient.GetAsync($"/api/Account/{id}/Balance");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task AddAsync()
    {
        UI.SubHeader("Add New Account");

        var dto = new
        {
            personID = UI.PromptInt("Person ID"),
            branchID = UI.PromptInt("Branch ID"),
            accountTypeID = UI.PromptInt("Account Type ID")
        };

        var r = await ApiClient.PostAsync("/api/Account/Add", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task UpdateAsync()
    {
        int id = UI.PromptInt("Account ID");
        UI.SubHeader("Update Account");

        var dto = new
        {
            branchID = UI.PromptInt("Branch ID"),
            isActive = UI.PromptBool("Is Active")
        };

        var r = await ApiClient.PutAsync($"/api/Account/{id}", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task DeleteAsync()
    {
        int id = UI.PromptInt("Account ID");
        var r = await ApiClient.DeleteAsync($"/api/Account/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }
}


// ============================================================
// ACCOUNT TYPE MENU
// ============================================================
public static class AccountTypeMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("ACCOUNT TYPES");
            Console.WriteLine("  1. List all account types");
            Console.WriteLine("  2. Get account type by ID");
            Console.WriteLine("  3. Update account type");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 3);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await ListAsync(); break;
                case 2: await GetByIdAsync(); break;
                case 3: await UpdateAsync(); break;
            }
        }
    }

    private static async Task ListAsync()
    {
        var r = await ApiClient.GetAsync("/api/AccountType/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetByIdAsync()
    {
        int id = UI.PromptInt("Account Type ID");
        var r = await ApiClient.GetAsync($"/api/AccountType/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task UpdateAsync()
    {
        int id = UI.PromptInt("Account Type ID");
        UI.SubHeader("Update Account Type");

        var dto = new
        {
            accountTypeID = id,
            accountTypeDescription = UI.PromptRequired("Description")
        };

        var r = await ApiClient.PutAsync($"/api/AccountType/{id}", dto);
        UI.ShowResult(r);
        UI.Pause();
    }
}


// ============================================================
// TRANSACTION MENU
// ============================================================
public static class TransactionMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("TRANSACTIONS");
            Console.WriteLine("  1. Deposit");
            Console.WriteLine("  2. Withdrawal");
            Console.WriteLine("  3. Transfer");
            Console.WriteLine("  4. List all transactions");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 4);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await DepositAsync(); break;
                case 2: await WithdrawalAsync(); break;
                case 3: await TransferAsync(); break;
                case 4: await ListAsync(); break;
            }
        }
    }

    private static async Task DepositAsync()
    {
        UI.SubHeader("Deposit");

        var dto = new
        {
            accountID = UI.PromptInt("Account ID"),
            amount = UI.PromptDecimal("Amount"),
            employeeID = UI.PromptInt("Employee ID")
        };

        var r = await ApiClient.PostAsync("/api/Transaction/Deposit", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task WithdrawalAsync()
    {
        UI.SubHeader("Withdrawal");

        var dto = new
        {
            accountID = UI.PromptInt("Account ID"),
            amount = UI.PromptDecimal("Amount"),
            employeeID = UI.PromptInt("Employee ID")
        };

        var r = await ApiClient.PostAsync("/api/Transaction/Withdrawal", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task TransferAsync()
    {
        UI.SubHeader("Transfer");

        var dto = new
        {
            accountID = UI.PromptInt("Source Account ID"),
            destinationAccountID = UI.PromptInt("Destination Account ID"),
            amount = UI.PromptDecimal("Amount"),
            employeeID = UI.PromptInt("Employee ID")
        };

        var r = await ApiClient.PostAsync("/api/Transaction/Transfer", dto);
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task ListAsync()
    {
        var r = await ApiClient.GetAsync("/api/Transaction/All");
        UI.ShowResult(r);
        UI.Pause();
    }
}


// ============================================================
// LOOKUP MENU (Roles & Positions)
// ============================================================
public static class LookupMenu
{
    public static async Task ShowAsync()
    {
        while (true)
        {
            UI.Header("ROLES & POSITIONS");
            Console.WriteLine("  1. List all roles");
            Console.WriteLine("  2. Get role by ID");
            Console.WriteLine("  3. List all positions");
            Console.WriteLine("  4. Get position by ID");
            Console.WriteLine("  0. Back");

            int choice = UI.AskChoice(0, 4);
            if (choice == 0) return;

            switch (choice)
            {
                case 1: await ListRolesAsync(); break;
                case 2: await GetRoleByIdAsync(); break;
                case 3: await ListPositionsAsync(); break;
                case 4: await GetPositionByIdAsync(); break;
            }
        }
    }

    private static async Task ListRolesAsync()
    {
        var r = await ApiClient.GetAsync("/api/Role/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetRoleByIdAsync()
    {
        int id = UI.PromptInt("Role ID");
        var r = await ApiClient.GetAsync($"/api/Role/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task ListPositionsAsync()
    {
        var r = await ApiClient.GetAsync("/api/Position/All");
        UI.ShowResult(r);
        UI.Pause();
    }

    private static async Task GetPositionByIdAsync()
    {
        int id = UI.PromptInt("Position ID");
        var r = await ApiClient.GetAsync($"/api/Position/{id}");
        UI.ShowResult(r);
        UI.Pause();
    }
}