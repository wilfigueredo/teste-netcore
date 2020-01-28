using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagineBeyond.Application.Customer.ViewModel;

namespace ImagineBeyond.Application.Customer.Interfaces
{
    public interface ICustomerAppService
    {
         Task CreateCostumer(CustomerViewModel costumerViewModel);

         Task UpdateCostumer(CustomerViewModel costumerViewModel);

         Task DeleteCostumer(Guid id);

         Task<IEnumerable<CustomerViewModel>> Get();

         Task<CustomerViewModel> GetById(Guid id);
    }
}