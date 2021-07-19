using System;

namespace TestDapper.Domain.Models
{
    public class Product
    {
        public Product(Guid productID, string productKey, string productName, string productImageUri, Guid productTypeID, RecordStatusEnum recordStatus, string updatedUser)
        {
            ProductID = productID;
            ProductKey = productKey;
            ProductName = productName;
            ProductImageUri = productImageUri;
            ProductTypeID = productTypeID;
            RecordStatus = recordStatus;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            UpdatedUser = updatedUser;
        }

        public Guid ProductID { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUri { get; set; }
        public Guid ProductTypeID { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }

    public enum RecordStatusEnum
    {
        Active,
        Inactive,
        Discount
    }
}
