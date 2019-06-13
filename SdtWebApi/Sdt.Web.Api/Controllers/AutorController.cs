using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sdt.Bo.Entities;
using Sdt.Data.Context;

namespace Sdt.Web.Api.Controllers
{
    [RoutePrefix("api/autors")]
    public class AutorController : ApiController
    {
        #region Members/Konstruktoren

        private readonly SdtDataContext _context;

        public AutorController()
        {
            _context = new SdtDataContext();
        }

        #endregion

        #region GET

        [Route("")]
        public IHttpActionResult GetAutoren()
        {
            var autoren = _context.Autoren.Include(c => c.Sprueche).ToList();

            if (!autoren.Any())
            {
                return NotFound();
            }

            return Ok(autoren);
        }

        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetAutorById(int id)
        {
            var autor = _context.Autoren.Find(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        #endregion
    }
}
