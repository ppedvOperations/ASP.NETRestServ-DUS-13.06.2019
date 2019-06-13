using System.ComponentModel.DataAnnotations.Schema;

namespace Sdt.Bo.Entities
{
    [Table("Spruch")]
    public class Spruch
    {
        public int SpruchId { get; set; }
        public string SpruchText { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}