using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDapperAndSqlKataDue.Domain;

namespace TestDapperAndSqlKataDue.Host
{
    public class ProductTypeMap : EntityMap<ProductType>
    {
        public ProductTypeMap()
        {
            Map(p => p.ProductTypeID).ToColumn("ProductTypeID");
            Map(p => p.ProductTypeKey).ToColumn("ProductTypeKey");
            Map(p => p.ProductTypeName).ToColumn("ProductTypeName");
            Map(p => p.RecordStatus).ToColumn("RecordStatus");
            Map(p => p.CreatedDate).ToColumn("CreatedDate");
            Map(p => p.UpdatedDate).ToColumn("UpdatedDate");
            Map(p => p.UpdatedUser).ToColumn("UpdatedUser");
        }
    }
}
