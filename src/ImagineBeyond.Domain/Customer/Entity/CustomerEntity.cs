using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Domain.Validation;
using System;

namespace ImagineBeyond.Customer.Entity
{
    public class CustomerEntity
    {
        public CustomerEntity(string firstName, string lastName, string email, DateTime dateOfBird)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBird = dateOfBird;
            this.DateCreate = DateTime.Now;
            this.DateLastUpdate = null;
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public DateTime DateOfBird { get; set; }

        public DateTime DateCreate { get; private set; }

        public DateTime? DateLastUpdate { get; private set; }

        public bool RegisterIsValid(ICustomerRepository customerRepository) 
        {
            var validate = new ClienteAptoParaCadastroValidation(customerRepository).Validate(this);
            return validate.IsValid;
        }

        public bool UpdateIsValid(ICustomerRepository customerRepository)
        {
            var validate = new ClienteAptoParaUpdateValidation(customerRepository).Validate(this);
            return validate.IsValid;
        }

        public CustomerEntity Update(string firstName, string lastName, string email, DateTime dateOfBird)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBird = dateOfBird;
            this.DateLastUpdate = DateTime.Now;
            return this;
        }
    }
}