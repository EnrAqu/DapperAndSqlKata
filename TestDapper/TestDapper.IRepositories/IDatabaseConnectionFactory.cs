using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace TestDapper.IRepositories
{
    public interface IDatabaseConnectionFactory
    {
        Task<DbConnection> CreateConnectionAsync();
    }
}
