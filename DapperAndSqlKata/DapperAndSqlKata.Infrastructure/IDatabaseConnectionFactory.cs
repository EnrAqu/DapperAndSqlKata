using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndSqlKata.Infrastructure
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsynch();
    }
}
