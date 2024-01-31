using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CustomerComplaintQuery
    {
        public int QueryId { get; set; }

        public string Description { get; set; }

        public int QueryStatus {  get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Products Products { get; set; }
    }
}
