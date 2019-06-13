using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Bo.Entities
{
    [Table("Autor")]
    public class Autor
    {
        //[Key]
        public int AutorId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Geburtsdatum { get; set; }
        public List<Spruch> Sprueche { get; set; }

        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
    }
}
