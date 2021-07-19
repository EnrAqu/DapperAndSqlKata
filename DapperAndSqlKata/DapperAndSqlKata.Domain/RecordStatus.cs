using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAndSqlKata.Domain
{
    public enum RecordStatus
    {
        [Description("Active")]
        Active = 1,
        [Description("In active")]
        InActive = 2
    }
}
