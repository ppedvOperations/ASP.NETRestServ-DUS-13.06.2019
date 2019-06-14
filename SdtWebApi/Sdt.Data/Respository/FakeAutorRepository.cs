using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sdt.Bo.Entities;

namespace Sdt.Data.Respository
{
    public class FakeAutorRepository : IAutorRespository
    {
        private static readonly List<Autor> _autoren;

        static FakeAutorRepository()
        {
            _autoren = new List<Autor>()
            {
                new Autor()
                {
                    AutorId = 1,
                    Name = "Albert Einstein Fake",
                    Beschreibung = "Physiker FAKE",
                    Geburtsdatum = new DateTime(1899, 1, 2),
                    Sprueche = new List<Spruch>()
                    {
                        new Spruch()
                        {
                            //Autor = _autoren[0], 
                            AutorId = 1,
                            SpruchId = 1,
                            SpruchText =
                                "Ich bin nicht sicher, mit welchen Waffen der dritte Weltkrieg ausgetragen wird, aber im vierten Weltkrieg werden sie mit Stöcken und Steinen kämpfen."
                        },
                        new Spruch()
                        {
                            AutorId = 1,
                            SpruchId = 2,
                            SpruchText = "Phantasie ist wichtiger als Wissen, denn Wissen ist begrenzt."
                        }
                    }
                },
                new Autor()
                {
                    AutorId = 2,
                    Name = "Mark Twain",
                    Beschreibung = "Philosoph",
                    Geburtsdatum = new DateTime(1835, 11, 30),
                    Sprueche = new List<Spruch>
                    {
                        new Spruch()
                        {
                            AutorId = 2,
                            SpruchId = 3,
                            SpruchText =
                                "Gott hat den Menschen erschaffen, weil er vom Affen enttäuscht war. Danach hat er auf weitere Experimente verzichtet."
                        },
                        new Spruch()
                        {
                            AutorId = 2,
                            SpruchId = 4,
                            SpruchText = "Man könnte viele Beispiele für unsinnige Ausgaben nennen, aber keines ist treffender als die Errichtung einer Friedhofsmauer. Die, die drinnen sind, können sowieso nicht hinaus, und die, die draußen sind, wollen nicht hinein."
                        },
                        new Spruch()
                        {
                            AutorId = 2,
                            SpruchId = 5,
                            SpruchText = "Man vergisst vielleicht, wo man die Friedenspfeife vergraben hat. Aber man vergisst niemals, wo das Beil liegt."
                        }
                    }
                },
                new Autor()
                {
                    AutorId = 3,
                    Name = "Oscar Wilde",
                    Beschreibung = "Schriftsteller",
                    Geburtsdatum = new DateTime(1854, 10, 16),
                    Sprueche = new List<Spruch>
                    {
                        new Spruch()
                        {
                            AutorId = 3,
                            SpruchId = 6,
                            SpruchText ="Gesegnet seien jene, die nichts zu sagen haben und den Mund halten."
                        },
                        new Spruch()
                        {
                            AutorId = 3,
                            SpruchId = 7,
                            SpruchText = "Ein Zyniker ist ein Mensch, der von jedem Ding den Preis und von keinem den Wert kennt."
                        },
                        new Spruch()
                        {
                            AutorId = 3,
                            SpruchId = 8,
                            SpruchText = "Die Ehe ist ein Versuch, zu zweit wenigstens halb so glücklich zu werden, wie man allein gewesen ist."
                        }
                    }
                }
            };
        }

        public void Add(Autor entity)
        {
            _autoren.Add(entity);
        }

        public void Delete(Autor entity)
        {
            Autor autor = _autoren.Find(c => c.AutorId == entity.AutorId);
            _autoren.Remove(autor);
        }

        public IQueryable<Autor> GetAll()
        {
            return _autoren.AsQueryable();
        }

        public bool Exists(int id)
        {
            return _autoren.FirstOrDefault(c => c.AutorId == id) != null;
        }

        public Autor GetById(int id)
        {
            return _autoren.Find(c => c.AutorId == id);
        }

        public Task<Autor> GetByIdAsync(int id)
        {
            return Task.FromResult(_autoren.Find(c=> c.AutorId == id));
        }

        public IQueryable<Autor> GetOnlyAutoren()
        {
            return _autoren.AsQueryable();
        }

        public bool Save()
        {
            return true;
        }

        public Task<bool> SaveAsync()
        {
            return Task.FromResult(true);
        }

        public IQueryable<Autor> SearchFor(Expression<Func<Autor, bool>> predicate)
        {
            return _autoren.AsQueryable().Where(predicate);
        }

        public void Update(Autor entity)
        {
            int autor = _autoren.FindIndex(c => c.AutorId.Equals(entity.AutorId));
            _autoren[autor] = entity;
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FakeAutorRepository() {
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
