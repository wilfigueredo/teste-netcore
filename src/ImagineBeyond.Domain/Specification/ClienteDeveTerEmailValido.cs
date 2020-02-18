using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Validate;
using ImagineBeyond.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Specification
{
    public class ClienteDeveTerEmailValido : ISpecification<CustomerEntity>
    {
        public bool IsSatisfiedBy(CustomerEntity customer)
        {
            return Email.Validar(customer.Email);
        }
    }
}
