namespace CustomerRelationshipManagementBackend.Common
{
    public static class Enums
    {

        public enum Roles
        {
            Admin = 1,
            SubAdmin = 2,
        }

        public enum QueryStatus
        {
            Pending = 1,
            Resolved = 2,
            Unresolved = 3,
        }

        public enum ProjectStatus 
        {
            Draft = 1,
            Confirmed = 2,
            Canceled = 3,
        }

        public enum TaskStatus
        {
            Pending = 1,
            Done = 2,
            Canceled = 3,
        }
        public enum BillStatus
        {
            Pending = 1,
            Confirmed = 2,
            Canceled = 3,
        }

    }
}
