using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImagineBeyondContext _context;

        public UnitOfWork(ImagineBeyondContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex) { return false; }
        }
    }
}
