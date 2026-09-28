namespace AtlantisBank.BLL
{
    public enum enOperationResult
    {
        Success = 1,
        NoPermission = 2,
        AccountNotFound = 3,
        Failed = 4,
        NationalNumberExists = 5,
        ValidationError = 6,
        InvalidOperation = 7,
        InActiveAccount = 8,
        EmailExists = 9,
        CountryNotFound = 10,
        BranchNotFound = 11,
        PositionNotFound = 12,
        RoleNotFound = 13,
        EmployeeNotFound = 14,
        PersonNotFound = 15,
        AccountTypeAlreadyExists = 16,
        UsernameExists = 17,
        NotFound = 18
    }
}