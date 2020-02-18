using ImagineBeyond.Domain.Interfaces.Validate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Validation
{
    public class Rule<T> where T : class
    {
        public Rule(ISpecification<T> specification, string message)
        {
            this.Message = message;
            this.Specification = specification;
        }

        public string Message { get; set; }
        public ISpecification<T> Specification { get; set; }
    }
}
