using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BopHub.Models.Validation
{
    public class FutureDate: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(
                Convert.ToString(value), 
                "d MMM yyyy", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
        //you can actually create a validation that checks for space in what users type in.
    }
}
