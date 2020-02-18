using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineBeyond.Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected ImagineBeyondContext Db;
        protected DbSet<CustomerEntity> DbSet;

        public CustomerRepository(ImagineBeyondContext context)
        {
            Db = context;
            DbSet = Db.Set<CustomerEntity>();
        }
        public async Task Create(CustomerEntity customer)
        {
            await DbSet.AddAsync(customer);
        }

        public async Task Update(CustomerEntity customer)
        {
            DbSet.Update(customer);
        }

        public async Task Delete(CustomerEntity customer)
        {
            DbSet.Remove(DbSet.Find(customer.Id));
        }

        public async Task<IEnumerable<CustomerEntity>> Get()
        {
            return DbSet.ToList();
        }

        public async Task<CustomerEntity> GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public async Task<CustomerEntity> GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Email == email);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }        
    }
}
