using System;
using System.Configuration;
using System.Linq;

using infrastructure.interfaces;


namespace infrastructure.services
{
    public class ConfigService : IConfigService
    {

        #region IConfigService implementation

        public string DbConnectionString
        {
            get
            {
                string conString = null;
                var settings = ConfigurationManager.ConnectionStrings["MedKoder"];
                if (settings != null)
                {
                    conString = settings.ConnectionString;
                }
                return conString;
            }
        }

        public bool containsKey(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key);
        }

        public string getValue(string key)
        {
            string ret = "";

            // check if key null
            if (null == key)
                throw new ArgumentNullException("Passed key was null");

            //check if key present
            if (!containsKey(key))
                throw new ApplicationException(string.Format("Passed key value of {0} not present in the configuration file's app settings.", key));

            ret = ConfigurationManager.AppSettings[key];

            return ret;
        }

        #endregion
    }
}
