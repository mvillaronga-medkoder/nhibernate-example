namespace infrastructure.interfaces
{
    /// <summary>
    /// Interface that defines class responsible for returning an instance of a repository object.
    /// This is primarily to be used so that the Repository iteself can be used similar to a 
    /// DBCOntext object or a Session object.  It can be used in a using () {} statement
    /// and have it automatically dispose of iteself properly.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// returns an instance of a repository to be used to access the application's persistant store (db)
        /// </summary>
        /// <returns></returns>
        IRepository getRepository();
    }
}
