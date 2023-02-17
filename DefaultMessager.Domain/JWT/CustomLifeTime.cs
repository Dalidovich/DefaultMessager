using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.JWT
{
    public class CustomLifeTime
    {
        public static bool CustomLifeTimeValidator(DateTime? nbf, DateTime? exp,SecurityToken tokenToValidate,TokenValidationParameters @param) 
        {
            return exp != null ? exp > DateTime.UtcNow : false;
        }
    }
}
