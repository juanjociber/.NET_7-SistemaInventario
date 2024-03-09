using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Utilidades
{
    public class ErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresLower),
                Description = "El password debe tener al menos una letra Minúscula"
            };    
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "El password debe tener al menos una letra mayúscula"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError() { 
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "El password debe tener un alfanumérico"
            };
        }
    }
}
