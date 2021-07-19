using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDapper.CommandStack;
using TestDapper.Domain.Models;
using TestDapper.IRepositories;

namespace TestDapper.DapperImplementation.Repository
{
    public class ProductRepository
    {
        private readonly ISqlKataManager sqlKataManager;

        public ProductRepository(ISqlKataManager sqlKataManager)
        {
            this.sqlKataManager = sqlKataManager ?? throw new ArgumentNullException(nameof(sqlKataManager));
        }

        public CreateProductResponse AddProduct(Product request)
        {
            sqlKataManager
        } 
    }
}
