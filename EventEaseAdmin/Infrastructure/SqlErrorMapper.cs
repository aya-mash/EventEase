using Microsoft.Data.SqlClient;

namespace EventEaseAdmin.Infrastructure
{
    public static class SqlErrorMapper
    {
        public static string Map(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2601:
                case 2627:
                    return "A record with the same key already exists.";
                case 547:
                    return "This item is in use and cannot be deleted.";
                case -2: // Timeout
                case 4060: // Cannot open database
                case 40197: // Azure transient
                case 40501:
                case 40613:
                    return "Temporary database issue; please retry.";
                default:
                    return "A database error occurred.";
            }
        }
    }
}
