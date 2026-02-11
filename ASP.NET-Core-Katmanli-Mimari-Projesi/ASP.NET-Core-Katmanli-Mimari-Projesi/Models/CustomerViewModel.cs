using Entities.Dtos;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Models
{
    public class CustomerViewModel
    {
        public class CustomerListViewModel
        {
            public IEnumerable<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
            public string SearchTerm { get; set; } = string.Empty;
            public int TotalCount { get; set; }
        }

        public class CustomerDetailsViewModel
        {
            public CustomerDto? Customer { get; set; }
            public IEnumerable<OrderDto> RecentOrders { get; set; } = new List<OrderDto>();
        }

        public class CustomerCreateViewModel
        {
            public CreateCustomerDto Customer { get; set; } = new CreateCustomerDto();
            public string? ReturnUrl { get; set; }
        }

        public class CustomerEditViewModel
        {
            public UpdateCustomerDto Customer { get; set; } = new UpdateCustomerDto();
            public string? ReturnUrl { get; set; }
        }
    }
}
