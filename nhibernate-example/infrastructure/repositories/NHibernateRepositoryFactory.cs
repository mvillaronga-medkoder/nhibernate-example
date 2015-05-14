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
            if (null == _repo)
            {
                _repo = new NHibernateRepository(_config.DbConnectionString);
            }
            else
            {
                _repo.restoreSession(_config.DbConnectionString);
            }

            
            return _repo;
        }

        #endregion
    }
}
