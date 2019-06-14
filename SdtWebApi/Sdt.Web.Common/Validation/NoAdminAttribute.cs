using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Web.Common.Validation
{
    public class NoAdminAttribute : ValidationAttribute
    {
        //public override bool IsValid(object value)
        //{
            
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var autor =  (Autor) validationContext.ObjectInstance;
            if (value != null)
            {
                var blackList = new[] {"admin", "administrator"};

                var name = ((string) value).ToLowerInvariant();

                //foreach (string s in blackList)
                //{
                //    if(s == name) return false;
                //}

                if (blackList.Any(c => c == name))
                {
                    return new ValidationResult("Der Name darf nicht Admin, Administrator oder Root sein");
                }
            }

            return ValidationResult.Success;
        }
    }
}
