using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using infrastructure.interfaces;

namespace infrastructure.repositories
{
    public class RepositoryMock : IRepository
    {
        #region Members

        Dictionary<Type, Dictionary<object, object>> _tables = null;
        IList<object> _queryPassthroughObject = null;
        IList<object> _querySqlPassthroughObject = null;

        #endregion

        #region Constructors

        public RepositoryMock()
        {
            _tables = new Dictionary<Type, Dictionary<object, object>>();
        }

        public RepositoryMock(Dictionary<Type, Dictionary<object, object>> tables)
        {
            _tables = tables;
        }

        public RepositoryMock(Dictionary<Type, Dictionary<object, object>> tables, IList<object> querySqlPassthroughObject, IList<object> queryPassthroughObject)
        {
            _tables = tables;
            _queryPassthroughObject = queryPassthroughObject;
            _querySqlPassthroughObject = querySqlPassthroughObject;
        }

        #endregion

        #region IRepository Interface Implementation

        public void BeginTransaction()
        {
            //intentionally left blank -- Should do deep copy?
        }

        public void CommitTransaction()
        {
            //intentionally left blank -- should through out transactional data?
        }

        public void RollbackTransaction()
        {
            //intentionally left blank -- should reset to stored transactional state?
        }

        public void Flush()
        {
            //do nothing
        }

        public void Save(object obj)
        {
            object id = getObjectId(obj);
            Type type = obj.GetType();

            if (!_tables.ContainsKey(type))
            {
                _tables.Add(type, new Dictionary<object, object>());
                //throw new Exception(string.Format("Table for type {0} not found stored in this repository instance", type.Name));
            }

            //ALS HACK: Added to prevent issues with NHibernate and Date/Time truncating ms; causing issues w/ Encounter State when sorting
            Thread.Sleep(1);

            _tables[type].Remove(id);
            _tables[type].Add(id, obj);
        }

        public void Delete(object obj)
        {
            object id = getObjectId(obj);
            Type type = obj.GetType();

            if (null == _tables[type])
                throw new Exception(string.Format("Table for type {0} not found stored in this repository instance", type.Name));

            //ALS HACK: Added to prevent issues with NHibernate and Date/Time truncating ms; causing issues w/ Encounter State when sorting
            Thread.Sleep(1);

            _tables[type].Remove(id);
        }

        public object GetById(Type objType, object objId)
        {
            return _tables[objType][objId];
        }

        public TEntity GetById<TEntity>(object objId, bool force = false)
        {
            if (_tables[typeof(TEntity)].ContainsKey(objId))
                return (TEntity)_tables[typeof(TEntity)][objId];
            else
                return default(TEntity);
        }

        public IQueryable<TEntity> Query<TEntity>()
        {
            return (IQueryable<TEntity>)_tables[typeof(TEntity)].Values.Cast<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Query<TEntity, TRelated>(System.Linq.Expressions.Expression<Func<TEntity, TRelated>> fetchExpression)
        {
            return (IQueryable<TEntity>)_tables[typeof(TEntity)].Values.Cast<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Query<TEntity, TRelated1, TRelated2>(System.Linq.Expressions.Expression<Func<TEntity, IEnumerable<TRelated1>>> mainFetch, System.Linq.Expressions.Expression<Func<TRelated1, TRelated2>> childFetch)
        {
            return (IQueryable<TEntity>)_tables[typeof(TEntity)].Values.Cast<TEntity>().AsQueryable();
        }

        public IList<T> QuerySqlPassthrough<T>(string sql) where T : class
        {
            return _querySqlPassthroughObject.Cast<T>().ToList();
        }

        /// <summary>
        /// Used to set the data for the passthrough object that you'd like to be returned.
        /// </summary>
        /// <param name="passthroughObject"></param>
        public void SetQuerySqlPassthroughObject(IList<object> passthroughObject)
        {
            _querySqlPassthroughObject = passthroughObject;
        }

        public IList<T> QueryPassthrough<T>(string sql) where T : class
        {
            return _queryPassthroughObject.Cast<T>().ToList();
        }

        /// <summary>
        /// Used to set the data for the passthrough object that you'd like to be returned.
        /// </summary>
        /// <param name="passthroughObject"></param>
        public void SetQueryPassthroughObject(IList<object> passthroughObject)
        {
            _queryPassthroughObject = passthroughObject;
        }

        public void SqlExecuteNonQuery(System.Data.IDbCommand cmd)
        {
            //this space intentionally left blank
        }

        public void restoreSession(string conString, SessionType st)
        {
            //this space intentionally left blank
        }

        public void Dispose()
        {
            //this space intentionally left blank
        }

        #endregion

        #region Utility Methods

        private object getObjectId(object obj)
        {
            object ret = null;

            //will need to put exception listing here for objects that don't conform to the 
            //ClassNameId pattern
            string className = obj.GetType().Name;
            Type classType = obj.GetType();

            switch (className)
            {
                default:
                    string idName = className + "Id";
                    PropertyInfo pi = classType.GetProperty(idName);
                    if (null == pi)
                    {
                        idName = className + "ID";
                        pi = classType.GetProperty(idName);
                        if (null == pi)
                            throw new Exception(string.Format("Cannot find id property {0} on class {1}.", idName, className));
                    }
                    ret = pi.GetValue(obj);
                    break;
            }

            if (ret == null)
                throw new Exception("ID value found to be null on class.");

            return ret;
        }

        #endregion
    }
}
