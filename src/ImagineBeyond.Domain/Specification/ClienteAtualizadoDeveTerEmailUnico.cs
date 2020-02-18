using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Domain.Interfaces.Validate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Specification
{
    public class ClienteAtualizadoDeveTerEmailUnico : ISpecification<CustomerEntity>
    {

        private readonly ICustomerRepository _CustomerRepository;

        public ClienteAtualizadoDeveTerEmailUnico(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        public bool IsSatisfiedBy(CustomerEntity entity)
        {
            var cliente = _CustomerRepository.GetById(entity.Id);
            if (entity.Email != cliente.Result.Email) return _CustomerRepository.GetByEmail(entity.Email).Result == null;
            else return true;
        }
    }
}
