namespace InteriorDesign.Utils
{
    public static class ConnectionStringProvider
    {
        public static string GetConnectionString(string environmentName, string ConStringName)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();
            return configuration.GetConnectionString(ConStringName);
        }
    }
}
