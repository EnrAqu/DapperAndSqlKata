using SqlKata;
using SqlKata.Compilers;
using System;
using Dapper;
using TestDapperAndSqlKataDue.Domain;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper.FluentMap;

namespace TestDapperAndSqlKataDue.Host
{
    static class Program
    {
        const string connectionString = "Server = localhost,1433; Database = DapperAndSqlKata; User Id = sa; Password = Password1!;";

        static void Main(string[] args)
        {
            //SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
            //SqlMapper.RemoveTypeMap(typeof(Guid));
            //SqlMapper.RemoveTypeMap(typeof(Guid?));

            var compiler5 = new SqlServerCompiler();
            var query5 = new Query("dbo.test").AsInsert(new
            {
                id = Guid.NewGuid(),
                name = "zvc",
                surname = "asvsdfgs"
            });
            SqlResult result5 = compiler5.Compile(query5);
            var resultString5 = result5.ToString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result25 = connection.Execute(result5.Sql, result5.NamedBindings);
                Console.WriteLine(result25.ToString());
            }

            var queryGet = new Query("dbo.ProductType")
                .Where("ProductTypeID", "=", Guid.Parse("F45252ED-DA71-42CE-AE4A-DFDF8BFD8EE4"))
                .Select("ProductTypeID","ProductTypeKey","ProductTypeName","RecordStatus", "CreatedDate","UpdatedDate","UpdatedUser");

            var queryGetInclude = new Query("dbo.Product")
                .Where("ProductTypeID", "=", Guid.Parse("F45252ED-DA71-42CE-AE4A-DFDF8BFD8EE4"))
                .Select("ProductID", "ProductKey", "ProductName", "ProductImageUri", "ProductTypeID", "RecordStatus", "CreatedDate", "UpdatedDate", "UpdatedUser");

            SqlResult resultGet = compiler5.Compile(queryGet);

            SqlResult resultGet2 = compiler5.Compile(queryGetInclude);
            var resultGet5 = resultGet.ToString();

            IEnumerable<ProductType> products;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var psc = connection.Query(resultGet.Sql, resultGet.NamedBindings);
                var p = psc.FirstOrDefault();
                var tes = new ProductType(p.ProductTypeID, p.ProductTypeKey, p.ProductTypeName, (RecordStatusEnum)p.RecordStatus, p.CreatedDate, p.UpdatedDate, p.UpdatedUser);

                var psc2 = connection.Query(resultGet2.Sql, resultGet2.NamedBindings);
                var p3 = psc2.Select(prod => new Product(
                    productID: prod.ProductID,
                    productKey: prod.ProductKey,
                    productName: prod.ProductName,
                    productImageUri: prod.ProductImageUri,
                    productTypeID: prod.ProductTypeID,
                    recordStatus: (RecordStatusEnum)prod.RecordStatus,
                    updatedUser: prod.UpdatedUser)).ToList();

                var p2123 = p3.FirstOrDefault();
                //result25.FirstOrDefault<ProductType>();


                Console.WriteLine(tes.ToString());
            }


            string totalQuery = "";
            var productType = new ProductType(Guid.Parse("F45252ED-DA71-42CE-AE4A-DFDF8BFD8EE4"), "AK12", "Detersivo", RecordStatusEnum.Active, "Io");
            var product1 = new Product(Guid.NewGuid(), "DH23", "Dash", null, productType.ProductTypeID, RecordStatusEnum.Discount, "Altri");
            var product2 = new Product(Guid.NewGuid(), "DH25", "Dixan", null, productType.ProductTypeID, RecordStatusEnum.Inactive, "Altri");

            productType.Products.Add(product1);
            productType.Products.Add(product2);

            var queries = new List<SqlResult>();

            var compiler = new SqlServerCompiler();
            var query = new Query("dbo.ProductType").Where("ProductTypeID", "=", productType.ProductTypeID).AsUpdate(new
            {
                ProductTypeID = productType.ProductTypeID,
                ProductTypeKey = productType.ProductTypeKey,
                ProductTypeName = productType.ProductTypeName,
                RecordStatus = productType.RecordStatus,
                CreatedDate = productType.CreatedDate,
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = productType.UpdatedUser
            }
            );
            SqlResult result = compiler.Compile(query);
            queries.Add(result);

            

            foreach (var prod in productType.Products)
            {
                query = new Query("Product").AsInsert(new
                {
                    ProductID = prod.ProductID,
                    ProductKey = prod.ProductKey,
                    ProductName = prod.ProductName,
                    ProductImageUri = prod.ProductImageUri,
                    ProductTypeID = prod.ProductTypeID,
                    RecordStatus = prod.RecordStatus,
                    CreatedDate = prod.CreatedDate,
                    UpdatedDate = DateTime.UtcNow,
                    UpdatedUser = prod.UpdatedUser
                });
                queries.Add(compiler.Compile(query));
            }

            
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var que in queries)
                    connection.Execute(que.Sql, que.NamedBindings);
            }


            //var query1 = new Query("Product").WhereDatePart("day", "CreatedAt", 1);


            //SqlResult result2 = compiler.Compile(query1);
            //Console.WriteLine(result2.ToString());

            Console.ReadLine();
        }

    }
}
