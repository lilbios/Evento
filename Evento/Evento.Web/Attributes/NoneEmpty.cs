using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Attributes
{
    public class NoneEmpty: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ICollection == false) return false;
            return ((ICollection)value).Count > 0;
        }
    }
}
