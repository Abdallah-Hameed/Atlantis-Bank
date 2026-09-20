namespace AtlantisBank.BLL
{
    public enum enOperationResult
    {
        Success = 1,
        NoPermission = 2,
        NotFound = 3,
        Failed = 4,
        AlreadyExists = 5,
        ValidationError = 6,
        InvalidOperation = 7,
        InActiveAccount = 8
    }
}