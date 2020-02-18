using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Customer.Entity;
using AutoMapper;

namespace ImagineBeyond.Application.Customer.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        public CustomerAppService(ICustomerRepository customerRepository, 
                                  IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitofwork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.Get());
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
           return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id));           
        }

        public async Task CreateCostumer(CustomerViewModel costumerViewModel)
        {
            var customer = _mapper.Map<CustomerEntity>(costumerViewModel);
            if (!customer.RegisterIsValid(_customerRepository)) return; 

            await _customerRepository.Create(customer);

            if (_unitofwork.Commit()) costumerViewModel.OperacaoEhValida = true;
        }

        public async Task UpdateCostumer(CustomerViewModel costumerViewModel)
        {
            var customerUpdate = _mapper.Map<CustomerEntity>(costumerViewModel);
            if (!customerUpdate.UpdateIsValid(_customerRepository)) return;

            var customer = await _customerRepository.GetById(costumerViewModel.Id);
            customer.Update(costumerViewModel.FirstName, costumerViewModel.LastName, costumerViewModel.Email, costumerViewModel.DateOfBird);
            await _customerRepository.Update(customer);

            if (_unitofwork.Commit()) costumerViewModel.OperacaoEhValida = true;            
        }

        public async Task DeleteCostumer(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            await _customerRepository.Delete(customer);
        }
    }
}