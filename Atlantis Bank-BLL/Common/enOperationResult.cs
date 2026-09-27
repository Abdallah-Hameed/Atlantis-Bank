namespace AtlantisBank.BLL
{
    public enum enOperationResult
    {
        Success = 1,
        NoPermission = 2,
        NotFound = 3,
        Failed = 4,
        NationalNumberExists = 5,
        ValidationError = 6,
        InvalidOperation = 7,
        InActiveAccount = 8,
        EmailExists = 9,
        CountryNotFound = 10,
        BranchNotFound = 11,
        PositionNotFound = 12,
        UsernameExists=12
    }
}