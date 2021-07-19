using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using TestDapper.CommandStack;
using TestDapper.Domain.Models;
using TestDapper.IRepositories;

namespace TestDapper.SqlKataImplementation
{
    public class SqlKataManager : ISqlKataManager
    {
        public SqlKataManager()
        {
        }

        public string GetCommandInsertProduct(Product command)
        {
            CreateProductRequest request = new CreateProductRequest(command.ProductID, command.ProductKey, command.ProductName, command.ProductImageUri, command.ProductTypeID, command.RecordStatus);
            
            var compiler = new SqlServerCompiler();
            var query = new Query("Product").AsInsert(command);
                
            SqlResult result = compiler.Compile(query);
            
            return result.ToString();
        }
    }
}
