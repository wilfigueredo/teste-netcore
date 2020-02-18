using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.ValueObject;
using System;
using Xunit;

namespace ImagineBeyound.Domain.Testes
{
    public class EmailTest
    {        
        [Theory(DisplayName = "Validação de Email")]
        [Trait("Prioridade", "Media")]
        [InlineData("teste")]
        [InlineData("teste1")]
        [InlineData("1111111111")]
        [InlineData("teste@")]
        [InlineData("teste@teste")]        
        [InlineData("testeteste.com.br")]        
        public void Email_ValidarEmail_RecusarEmailsInvalidos(string email)
        {
            Assert.False(Email.Validar(email));
        }

        [Theory(DisplayName = "Validação de Email")]
        [Trait("Prioridade", "Media")]        
        [InlineData("teste@teste.com")]
        [InlineData("teste@teste.com.br")]        
        public void Email_ValidarEmail_AprovaEmailsValidos(string email)
        {
            Assert.True(Email.Validar(email));
        }
    }
}
