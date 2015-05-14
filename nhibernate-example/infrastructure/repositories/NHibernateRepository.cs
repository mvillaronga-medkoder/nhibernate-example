using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

using infrastructure.interfaces;


namespace infrastructure.repositories
{
    public class NHibernateRepository : IRepository, IDisposable
    {
        #region Members

        protected ISession _session = null;
        protected ITransaction _transaction = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NHibernateRepository(string connectionString)
        {
            _session = new SessionHelper(connectionString).OpenSession();
        }

        /// <summary>
        /// Used to construct the repository with a passed session helper.  Primaryly used to construct a repostiory isntance with
        /// an in memory DB for testing
        /// </summary>
        /// <param name="sessionHelp">The SessionHelper to use for this repository instance</param>
        /// <param name="log">A logging service to use</param>
        public NHibernateRepository(SessionHelper sessionHelp)
        {
            _session = sessionHelp.OpenSession();
        }

        #endregion

        #region Transaction and Session Management Methods

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            // _transaction will be replaced with a new transaction
            // by NHibernate, but we will close to keep a consistent state.
            _transaction.Commit();

            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                // _session must be closed and disposed after a transaction
                // rollback to keep a consistent state.
                _transaction.Rollback();

                CloseTransaction();
                CloseSession();
            }
        }

        public void Flush()
        {
            _session.Flush();
        }

        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }


        #endregion

        #region IRepository Members

        public virtual void Save(object obj)
        {
            _session.SaveOrUpdate(obj);
        }

        public virtual void Delete(object obj)
        {
            _session.Delete(obj);
        }

        public virtual object GetById(Type objType, object objId)
        {
            return _session.Load(objType, objId);
        }
        public virtual EntityType GetById<EntityType>(object objId, bool force)
        {
            if (force)
                return (EntityType)_session.Get(typeof(EntityType), objId);
            else
                return (EntityType)_session.Load(typeof(EntityType), objId);
        }

        public virtual IQueryable<TEntity> Query<TEntity>()
        {
            return _session.Query<TEntity>();
        }

        public virtual IQueryable<TEntity> Query<TEntity, TRelated>(Expression<Func<TEntity, TRelated>> fetchExpression)
        {
            return _session.Query<TEntity>()
                    .Fetch<TEntity, TRelated>(fetchExpression);
        }

        public virtual IQueryable<TEntity> Query<TEntity, TRelated1, TRelated2>(Expression<Func<TEntity, IEnumerable<TRelated1>>> mainFetch, Expression<Func<TRelated1, TRelated2>> childFetch)
        {
            return _session.Query<TEntity>()
                    .FetchMany<TEntity, TRelated1>(mainFetch)
                    .ThenFetch<TEntity, TRelated1, TRelated2>(childFetch);
        }

        public virtual void SqlExecuteNonQuery(IDbCommand cmd)
        {
            using(ITransaction transaction = _session.BeginTransaction())
            {
                cmd.Connection = _session.Connection;
                transaction.Enlist(cmd);
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }
        }

        public virtual IList<T> QuerySqlPassthrough<T>(string sql) where T : class
        {
            return _session.CreateSQLQuery(sql)
                    .SetResultTransformer(Transformers.AliasToBean<T>())
                    .List<T>();
        }

        public virtual IList<T> QueryPassthrough<T>(string sql) where T : class
        {
            return _session.CreateQuery(sql)
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .List<T>();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,
                // comment out the line below.
                CommitTransaction();
            }

            if (_session != null)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }

        #endregion

        #region Helper Members

        public void restoreSession(string conString)
        {
            if (null == _session)
            {
                _session = new SessionHelper(conString).OpenSession();
            }
            else
            {
                if (!_session.IsOpen)
                {
                    _session = new SessionHelper(conString).OpenSession();
                }

            }

        }

        public void restoreSession(SessionHelper sesHelp)
        {
            if (null == _session)
                _session = sesHelp.OpenSession();
        }


        #endregion
    }
}
