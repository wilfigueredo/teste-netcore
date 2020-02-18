using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagineBeyond.Customer.Entity;

namespace ImagineBeyond.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task Create(CustomerEntity customer);

        Task Update(CustomerEntity customer);

        Task Delete(CustomerEntity customer);

        Task<IEnumerable<CustomerEntity>> Get();

        Task<CustomerEntity> GetById(Guid id);

        Task<CustomerEntity> GetByEmail(string email);
    }
}