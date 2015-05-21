using System;

using infrastructure.interfaces;

namespace infrastructure.repositories
{
    /// <summary>
    /// Concrete instance of the 
    /// </summary>
    public class NHibernateRepositoryFactory : IRepositoryFactory
    {
        #region Members

        IConfigService _config = null;
        NHibernateRepository _repo = null;

        #endregion

        #region Constructors

        public NHibernateRepositoryFactory(IConfigService config)
        {
            _config = config;
        }

        #endregion

        #region IRepositoryFactory implementation

        public IRepository getRepository()
        {

            //pic the DB connection type from the config
            SessionType st = SessionType.MySql;
            if (_config.containsKey("DbType"))
            {
                string dbType = _config.getValue("DbType");
                switch (dbType)
                {
                    case "MSSQL":
                        st = SessionType.LocalSql;
                        break;
                    case "MYSQL":
                        st = SessionType.MySql;
                        break;
                    default:
                        throw new ApplicationException(string.Format("Unknown DB Type defined: {0}", dbType));
                }
            }
            else {
                throw new ApplicationException("Application configuration for DB Type required.");
            }
        

            if (null == _repo)
            {
                //create the repo
                _repo = new NHibernateRepository(_config.DbConnectionString, st);
            }
            else
            {
                _repo.restoreSession(_config.DbConnectionString, st);
            }

            
            return _repo;
        }

        #endregion
    }
}
