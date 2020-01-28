using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Customer.Entity;

namespace ImagineBeyond.Application.Customer.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<IEnumerable<CustomerViewModel>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public async Task CreateCostumer(CustomerViewModel costumerViewModel)
        {
            var costumer = new CustomerEntity(costumerViewModel.FirstName, costumerViewModel.LastName, costumerViewModel.Email);
            await _customerRepository.Create(costumer);
        }

        public async Task UpdateCostumer(CustomerViewModel costumerViewModel)
        {
            var customer = await _customerRepository.GetById(costumerViewModel.Id);
            customer.Update(costumerViewModel.FirstName, costumerViewModel.LastName, costumerViewModel.Email);
            await _customerRepository.Update(customer);
        }

        public async Task DeleteCostumer(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            await _customerRepository.Delete(customer);
        }
    }
}