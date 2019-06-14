using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sdt.Data.Context;
using Sdt.Web.Api.Dto;

namespace Sdt.Web.Api.Controllers
{
    [RoutePrefix("api/sprueche")]
    public class SpruchController : ApiController
    {
        private readonly SdtDataContext _context;

        public SpruchController()
        {
            _context = new SdtDataContext();
        }

        [Route("spruchdestages")]
        public IHttpActionResult GetSpruchDesTages()
        {
            var spruecheIds = _context.Sprueche.Select(c => c.SpruchId).ToList();
            var random = new Random();
            var zufallsSpruchId = spruecheIds[random.Next(0, spruecheIds.Count)];

            var spruch = _context.Sprueche.Include(c => c.Autor).SingleOrDefault(c => c.SpruchId == zufallsSpruchId);

            if (spruch == null)
            {
                return NotFound();
            }

            return Ok(new SpruchDesTagesDto
            {
                SpruchId = spruch.SpruchId,
                SpruchText = spruch.SpruchText,
                AutorName = spruch.Autor?.Name,
                AutorBild = spruch.Autor?.Photo,
                AutorBeschreibung = spruch.Autor?.Beschreibung,
                AutorGeburtsdatum = spruch.Autor?.Geburtsdatum,
                AutorBildType = spruch.Autor?.PhotoMimeType
            });
        }
    }
}
