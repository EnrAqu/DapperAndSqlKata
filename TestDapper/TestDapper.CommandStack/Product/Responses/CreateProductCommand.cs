using System;
using TestDapper.Domain.Models;

namespace TestDapper.CommandStack
{
    public class CreateProductResponse
    {
        public CreateProductResponse(Guid productID, string productKey, string productName, string productImageUri, Guid productTypeID, RecordStatusEnum recordStatus)
        {
            ProductID = productID;
            ProductKey = productKey;
            ProductName = productName;
            ProductImageUri = productImageUri;
            ProductTypeID = productTypeID;
            RecordStatus = recordStatus;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            UpdatedUser = "Io";
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
}
