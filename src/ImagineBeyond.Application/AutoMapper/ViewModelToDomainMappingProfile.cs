using AutoMapper;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Customer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, CustomerEntity>()
                .ConstructUsing(c => new CustomerEntity(c.FirstName,c.LastName,c.Email, c.DateOfBird));            
        }
    }
}
