using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImagineBeyound.Domain.Testes
{
    public class CustomerTest
    {

        CustomerEntity Customer;

        public CustomerTest()
        {
            Customer = new CustomerEntity("williame", "williame figueiredo", "williamefigueredo@outlook.com", DateTime.Parse("1988-06-01T00:00:00"));
        }

        [Fact(DisplayName = "Cadastra Cliente")]
        public void Customer_RegisterIsValid_DeveRetornarTrueParaCadastroDeCliente() 
        {          

            var repo = new Mock<ICustomerRepository>();
            repo.Setup(r => r.GetByEmail(Customer.Email)).ReturnsAsync((CustomerEntity)null);                       
            
            Assert.True(Customer.RegisterIsValid(repo.Object));
            repo.Verify(r => r.GetByEmail(Customer.Email), Times.AtLeastOnce);

        }

        [Fact(DisplayName = "Atualiza Cliente")]
        public void Customer_UpdateIsValid_DeveRetornarTrueParaUpdateDeCliente()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(r => r.GetByEmail(Customer.Email)).ReturnsAsync((CustomerEntity)null);
            repo.Setup(r => r.GetById(Customer.Id)).ReturnsAsync((CustomerEntity)Customer);

            Assert.True(Customer.UpdateIsValid(repo.Object));          
        }
    }
}
