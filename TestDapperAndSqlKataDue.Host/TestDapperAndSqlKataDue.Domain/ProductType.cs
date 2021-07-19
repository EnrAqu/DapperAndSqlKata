using System;
using System.Collections.Generic;

namespace TestDapperAndSqlKataDue.Domain
{
    public class ProductType
    {
        public ProductType(Guid productTypeID, string productTypeKey, string productTypeName, RecordStatusEnum recordStatus, string updatedUser)
        {
            ProductTypeID = productTypeID;
            ProductTypeKey = productTypeKey;
            ProductTypeName = productTypeName;
            ProductTypeID = productTypeID;
            RecordStatus = recordStatus;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            UpdatedUser = updatedUser;
            Products = new List<Product>();
        }

        public ProductType(Guid productTypeID, string productTypeKey, string productTypeName, RecordStatusEnum recordStatus, DateTime createdDate, DateTime updatedDate, string updatedUser)
        {
            ProductTypeID = productTypeID;
            ProductTypeKey = productTypeKey;
            ProductTypeName = productTypeName;
            ProductTypeID = productTypeID;
            RecordStatus = recordStatus;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedUser = updatedUser;
            Products = new List<Product>();
        }

        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}

