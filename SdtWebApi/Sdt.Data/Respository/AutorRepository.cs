using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdt.Bo.Entities;
using Sdt.Data.Context;

namespace Sdt.Data.Respository
{
    public class AutorRepository : IAutorRespository
    {
        private readonly SdtDataContext _context;

        public AutorRepository()
        {
            _context = new SdtDataContext();
        }

        public void Add(Autor entity)
        {
            _context.Autoren.Add(entity);
        }

        public void Delete(Autor entity)
        {
            _context.Autoren.Remove(entity);
        }

        public IQueryable<Autor> GetAll()
        {
            return _context.Autoren.Include(c => c.Sprueche);
        }

        public Autor GetById(int id)
        {
            return _context.Autoren.Include(c => c.Sprueche).SingleOrDefault(c => c.AutorId == id);
        }

        public IQueryable<Autor> GetOnlyAutoren()
        {
            return _context.Autoren;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(Autor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AutorRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
