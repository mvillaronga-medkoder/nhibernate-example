using infrastructure.interfaces;

namespace infrastructure.repositories
{

    public class RepositoryFactoryMock : IRepositoryFactory
    {
        #region Members

        protected IRepository _repo = null;

        #endregion

        #region Constructors

        public RepositoryFactoryMock(IRepository repo)
        {
            _repo = repo;
        }

        #endregion

        #region IRepositoryFactory Implementation

        public IRepository getRepository()
        {
            return _repo;
        }

        #endregion
    }
}
