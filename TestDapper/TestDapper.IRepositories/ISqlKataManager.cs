using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDapper.IRepositories
{
    public interface ISqlKataManager
    {
        string GetCommandInsertProduct(Product command);
    }
}
