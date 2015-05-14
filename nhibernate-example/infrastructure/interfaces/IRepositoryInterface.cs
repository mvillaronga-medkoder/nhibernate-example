using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace infrastructure.interfaces
{
    public interface IRepository : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Flush();

        void Save(object obj);
        void Delete(object obj);
        object GetById(Type objType, object objId);
        TEntity GetById<TEntity>(object objId, bool force = false);
        IQueryable<TEntity> Query<TEntity>();
        IQueryable<TEntity> Query<TEntity, TRelated>(Expression<Func<TEntity, TRelated>> fetchExpression);
        IQueryable<TEntity> Query<TEntity, TRelated1, TRelated2>(Expression<Func<TEntity, IEnumerable<TRelated1>>> mainFetch, Expression<Func<TRelated1, TRelated2>> childFetch);

        IList<T> QuerySqlPassthrough<T>(string sql) where T : class;
        IList<T> QueryPassthrough<T>(string sql) where T : class;

        //pass through members
        void SqlExecuteNonQuery(IDbCommand cmd);

        /// <summary>
        /// Fix:  Issue with changes to the repository leaving a null Session object.  Corrected with work around called 
        /// refreshSession.  Creates a new session object if the existing session has been disposed of.
        /// </summary>
        /// <param name="connectionString">Connection string for the SessionHelper object to create</param>
        void restoreSession(string conString);
    }
}
