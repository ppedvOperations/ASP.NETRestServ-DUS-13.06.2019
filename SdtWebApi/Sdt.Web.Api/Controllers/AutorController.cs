using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sdt.Bo.Entities;
using Sdt.Data.Context;
using Sdt.Data.Respository;

namespace Sdt.Web.Api.Controllers
{
    [RoutePrefix("api/autors")]  //AutorController erbt BaseConstroller erbt ApiController
    public class AutorController : ApiController
    {
        #region Members/Konstruktoren

        private readonly IAutorRespository _repository;

        public AutorController()
        {
            _repository = new AutorRepository();
            //_repository = new FakeAutorRepository();
        }

        #endregion

        #region GET

        [Route("")]
        public IHttpActionResult GetAutoren()
        {
            var autoren = _repository.GetAll();

            if (!autoren.Any())
            {
                return NotFound();
            }

            return Ok(autoren);
        }

        //[Route("{id:int:min(1)}")]
        [Route("{id:int:positivNonZero}", Name = nameof(GetAutorById))]
        public IHttpActionResult GetAutorById(int id)
        {
            //LinQ -> FirstOrDefault bzw. SingleOrDefault -> SQL: where c.AutorId = @id

            var autor = _repository.GetById(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        #endregion

        #region CREATE

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostAutor([FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
               // ModelState.AddModelError("Fachlicher FN","95736-23");
                return BadRequest(ModelState);
            }

            _repository.Add(autor);
            _repository.Save();

            return CreatedAtRoute(nameof(GetAutorById), new {id = autor.AutorId}, autor);
        }

        #endregion
    }
}
