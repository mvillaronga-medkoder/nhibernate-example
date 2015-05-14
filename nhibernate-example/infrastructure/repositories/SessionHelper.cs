using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

using maps.domain;

namespace infrastructure.repositories
{
    public class SessionHelper
    {
        #region Members

        private static ISessionFactory c_sessionFactory;
        private string _connectionString;
        private static SessionType c_sessionType = SessionType.Sql_Physical;

        #endregion

        #region Constructors

        public SessionHelper(string connectionString, SessionType type = SessionType.Sql_Physical)
        {
            SessionType = type;
            _connectionString = connectionString;
        }

        #endregion

        #region Attributes

        private ISessionFactory SessionFactory
        {
            get
            {
                lock (this)
                {
                    if (c_sessionFactory == null)
                        InitializeSessionFactoryMethod(_connectionString);
                }
                return c_sessionFactory;
            }
        }

        public static SessionType SessionType { get { return c_sessionType; } set { c_sessionType = value; } }

        #endregion

        #region Methods

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Factory method to choose which version of the ISession to instanciate.  Used to 
        /// distinguish between testing and 
        /// </summary>
        /// <param name="conStr"></param>
        private static void InitializeSessionFactoryMethod(string conStr)
        {
            switch (SessionHelper.SessionType)
            {
                case SessionType.MySql:
                    InitializeSessionFactory_MySql(conStr);
                    break;
                //case SessionType.SqlLite_Memory:
                //    InitializeSessionFactory_SqlLite_Memory();
                //    break;
                default:
                    throw new ApplicationException(string.Format("Unable to initialize SessionFactory.  Unknown SessionType passed: {0}",
                                                                    Enum.GetName(typeof(SessionType), SessionHelper.SessionType)));
            }
        }

        /// <summary>
        /// Creates a session linked to a physical DB described by the connection string parameter
        /// </summary>
        /// <param name="connectionString">DB connection string</param>
        private static void InitializeSessionFactory_MySql(string connectionString)
        {
            c_sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(connectionString)
                    //.ShowSql()
                )

                // reference the assembly of a class that will pull in all the mappings
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<ItemMap>()
                   )

                // Will drop and re-create tables
                //.ExposeConfiguration(cfg => new SchemaExport(cfg)
                //    .Create(true, true))

                .BuildSessionFactory();
        }

        #endregion
    }

    public enum SessionType
    {
        Sql_Physical,
        SqlLite_Memory,
        MySql
    }

}
