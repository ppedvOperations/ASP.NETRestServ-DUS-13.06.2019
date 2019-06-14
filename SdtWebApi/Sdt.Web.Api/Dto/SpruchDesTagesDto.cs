using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sdt.Web.Api.Dto
{
    public class SpruchDesTagesDto
    {
        public int SpruchId { get; set; }
        public string SpruchText { get; set; }
        public string AutorName { get; set; }
        public string AutorBeschreibung { get; set; }
        public DateTime? AutorGeburtsdatum { get; set; }
        public byte[] AutorBild { get; set; }
        public string AutorBildType { get; set; }

    }
}