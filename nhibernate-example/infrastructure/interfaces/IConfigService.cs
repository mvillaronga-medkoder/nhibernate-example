namespace infrastructure.interfaces
{
    public interface IConfigService
    {
        /// <summary>
        /// returns the DbConnection string for use in the repository
        /// </summary>
        string DbConnectionString { get; }
        
        /// <summary>
        /// Checks to see of the configuration has the passed key present
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool containsKey(string key);

        /// <summary>
        /// Returns the value associated with the passed key as a string.  Caller
        /// is responsible for calling the proper down cast type
        /// </summary>
        /// <param name="key">string of the key for the value wanted</param>
        /// <returns></returns>
        /// <exception>Can throw a few from invalid keys, keys not found in the config repository
        /// to bad down casts</exception>
        string getValue(string key);
    }
}
