﻿using System.Data.Common;
using System.Data.SqlClient;
using SystemDot.Serialisation;
using SystemDot.Storage.Changes.Sql;
using SystemDot.Storage.Changes.Upcasting;

namespace SystemDot.Storage.Changes.SqlServer
{
    public class SqlChangeStore : DbChangeStore
    {
        public SqlChangeStore(ISerialiser serialiser, ChangeUpcasterRunner changeUpcasterRunner)
            : base(serialiser, changeUpcasterRunner) { }

        protected override string GetInitialisationSql()
        {
            return
@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ChangeStore') AND type in (N'U'))
    CREATE TABLE ChangeStore(
        ChangeRootId nvarchar(1000) NOT NULL,
        Sequence int IDENTITY(1, 1) NOT NULL,
        Change varbinary(max) NULL)";
        }

        protected override void AddParameter(DbParameterCollection collection, string name, object value)
        {
            collection.Add(new SqlParameter(name, value));
        }

        protected override DbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }

}

