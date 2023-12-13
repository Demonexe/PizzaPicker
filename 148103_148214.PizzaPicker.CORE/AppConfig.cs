using System.Configuration;

namespace _148103_148214.PizzaPicker.CORE
{
    public class AppConfig
    {
        public static AppConfig Instance
        {
            get
            {
                lock(_syncRoot)
                {
                    if (_instance == null)
                        _instance = new AppConfig();
                    return _instance;
                }
            }
        }

        public string ConnectionString { get; }
        
        private static object _syncRoot = new object();
        private static AppConfig _instance = null;
        private AppConfig()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
    }
}
