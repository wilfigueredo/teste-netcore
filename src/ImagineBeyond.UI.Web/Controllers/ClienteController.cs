using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.Services;
using ImagineBeyond.Application.Customer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagineBeyond.UI.Web
{
    [Produces("application/json")]
    public class ClienteController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public ClienteController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [Route("customer")]        
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            return await _customerAppService.Get();
        }

        [HttpGet]        
        [Route("customer/{id:guid}")]
        public async Task<CustomerViewModel> Get(Guid id)
        {
            return await _customerAppService.GetById(id); 
        }

        [HttpPost]
        [Route("customer")]        
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    msg = "Não foi possivel cadastrar o cliente!"
                });
            }

            _customerAppService.CreateCostumer(customerViewModel);

            if (customerViewModel.OperacaoEhValida)

                return Ok(new
                {
                    success = true,
                    msg = "Cliente cadastrado com sucesso!"
                });

            else
                return BadRequest(new
                {
                    success = false,
                    msg = "Não foi possivel atualizar o cliente!"
                });
        }

        [HttpPut]
        [Route("customer")]        
        public IActionResult Put([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    msg = "Não foi possivel atualizar o cliente!"
                });
            }

            _customerAppService.UpdateCostumer(customerViewModel);

           if(customerViewModel.OperacaoEhValida)

            return Ok(new
            {
                success = true,
                msg = "Cliente atualizado com sucesso!"
            });

           else
                return BadRequest(new
                {
                    success = false,
                    msg = "Não foi possivel atualizar o cliente!"
                });
        }

        [HttpDelete]
        [Route("customer/{id:guid}")]       
        public IActionResult Delete(Guid id)
        {
            _customerAppService.DeleteCostumer(id);
            return Ok(new
            {
                success = true,
                msg = "Cliente atualizado com sucesso!"
            });
        }

    }
}
