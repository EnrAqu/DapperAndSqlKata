using System;

namespace TestDapper.Domain.Models
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
        }

        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}
