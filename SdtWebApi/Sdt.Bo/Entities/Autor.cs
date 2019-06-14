using Sdt.Web.Common.Validation;
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
    public class Autor //: IValidatableObject
    {
        //[Key]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
        [NoAdmin]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Beschreibung { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Geburtsdatum { get; set; }
        public List<Spruch> Sprueche { get; set; }

        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //   List<ValidationResult> errors = new List<ValidationResult>();

        //   var blackList = new[] { "admin", "administrator" };

        //   if (blackList.Any(c => c == Name))
        //   {
        //       errors.Add(new ValidationResult("Der Name darf nicht Admin, Administrator oder Root sein"));
        //   }

        //   return errors;
        //}
    }
}
