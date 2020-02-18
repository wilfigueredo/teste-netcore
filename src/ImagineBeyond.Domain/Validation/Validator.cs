using ImagineBeyond.Domain.Interfaces.Validate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Validation
{
    public class Validator<T> where T: class
    {

        public Validator()
        {
            this.Rules = new List<Rule<T>>();
            this.IsValid = true;
        }

        public int Errors { get; set; }
        public bool IsValid { get; set; }
        public IList<Rule<T>> Rules { get; set; }

        protected void Add(Rule<T> rule) 
        {             
            this.Rules.Add(rule);   
        }

        public Validator<T> Validate(T entity) 
        {
            foreach (var item in Rules)
            {
                if (!item.Specification.IsSatisfiedBy(entity)) 
                {
                    this.IsValid = false;
                    this.Errors++;
                }
            }
            return this;
        }
    }   
}
