using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Server
{
    public class AuthContext: IdentityDbContext<IdentityUser>
    {
        public AuthContext(): base("AuthContext")
        {

        }
    }
}
