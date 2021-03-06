namespace HikiCoffee.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "HikiCoffeeDb"; 
        public static string DomainName { get; set; } = "https://localhost:7227";

        public const string CartSession = "CartSession";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}
