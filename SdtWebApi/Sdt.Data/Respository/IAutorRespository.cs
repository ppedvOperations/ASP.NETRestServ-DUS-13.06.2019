using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdt.Bo.Entities;

namespace Sdt.Data.Respository
{
    public interface IAutorRespository : IRepository<Autor, int>
    {
        IQueryable<Autor> GetOnlyAutoren();
    }
}
