using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Validation
{
    public class ClienteAptoParaCadastroValidation : Validator<CustomerEntity>
    {
        public ClienteAptoParaCadastroValidation(ICustomerRepository customerRepository)
        {
            var emailUnico = new ClienteDeveTerEmailUnico(customerRepository);
            var emailValido = new ClienteDeveTerEmailValido();

            base.Add(new Rule<CustomerEntity>(emailUnico, "Email já cadastrado na base, informe um email valido"));
            base.Add(new Rule<CustomerEntity>(emailValido, "O email está em formato invalido, por favor informe um email valido"));
        }
    }
}
