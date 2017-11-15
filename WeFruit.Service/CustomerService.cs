using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeFruit.EFModels;
using WeFruit.IRepository;
using WeFruit.IService;

namespace WeFruit.Service
{
    public class CustomerService:BaseService<Customer>,ICustomerService
    {
        public CustomerService(IBaseRepository<Customer> customerRepository) : base(customerRepository)
        {
        }
    }
}
