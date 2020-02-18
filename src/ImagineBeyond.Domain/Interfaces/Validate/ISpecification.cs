using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Interfaces.Validate
{
    public interface ISpecification<T> where T: class
    {
        bool IsSatisfiedBy(T entity);
    }
}
