using AutoMapper;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Customer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CustomerEntity, CustomerViewModel>();            
        }
    }
}
