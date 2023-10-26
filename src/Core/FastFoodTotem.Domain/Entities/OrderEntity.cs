using FastFoodTotem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderedItemEntity> OrderedItems { get; set; } = Enumerable.Empty<OrderedItemEntity>();
        public CustomerEntity Customer { get; set; }

        public bool ValidStatus(OrderStatus orderStatus)
        {
            if (NewStatusIsLowerOrEqualCurrentStatus()) return false;

            if (NewStatusIsSkippingSteps()) return false;

            return true;

            bool NewStatusIsLowerOrEqualCurrentStatus()
            => orderStatus <= Status;

            bool NewStatusIsSkippingSteps()
            => Status + 1 != orderStatus;
        }
    }
}
