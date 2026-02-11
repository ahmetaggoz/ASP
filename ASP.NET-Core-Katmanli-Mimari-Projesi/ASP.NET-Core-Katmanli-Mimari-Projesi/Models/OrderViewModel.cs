using Entities.Dtos;
using static Entities.Models.Order;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Models
{
    public class OrderViewModel
    {
        public class OrderListViewModel
        {
            public IEnumerable<OrderDto> Orders { get; set; } = new List<OrderDto>();
            public OrderStatus? FilterStatus { get; set; }
            public int? FilterCustomerId { get; set; }
            public DateTime? FilterDateFrom { get; set; }
            public DateTime? FilterDateTo { get; set; }
        }

        public class OrderCreateViewModel
        {
            public CreateOrderDto Order { get; set; } = new CreateOrderDto();
            public IEnumerable<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
            public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        }

        public class OrderDetailsViewModel
        {
            public OrderDto Order { get; set; }
            public bool CanUpdateStatus { get; set; }
            public IEnumerable<OrderStatus> AvailableStatuses { get; set; } = new List<OrderStatus>();
        }
    }
}
