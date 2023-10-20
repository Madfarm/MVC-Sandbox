namespace Web.Utility
{
    public class SD
    {
        public static string AuthAPIBase { get; set; }

        public static string CustomerRole { get; set; } = "CUSTOMER";
        public static string AdminRole { get; set; } = "ADMIN";
        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
