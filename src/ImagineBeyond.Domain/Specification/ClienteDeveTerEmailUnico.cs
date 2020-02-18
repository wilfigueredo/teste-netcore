using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Domain.Interfaces.Validate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Specification
{
    public class ClienteDeveTerEmailUnico : ISpecification<CustomerEntity>
    {
        private readonly ICustomerRepository _CustomerRepository;

        public ClienteDeveTerEmailUnico(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        public bool IsSatisfiedBy(CustomerEntity entity)
        {             
            return _CustomerRepository.GetByEmail(entity.Email).Result == null;
        }
    }
}
