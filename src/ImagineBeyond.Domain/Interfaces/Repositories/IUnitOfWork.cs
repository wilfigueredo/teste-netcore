using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
