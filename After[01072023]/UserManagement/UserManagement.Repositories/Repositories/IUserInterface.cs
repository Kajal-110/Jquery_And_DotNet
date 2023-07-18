using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Context;
using UserManagement.Models.Models;

namespace UserManagement.Repositories.Repositories
{
   public interface IUserInterface
    {
        int SignIn(UserModel userModel);

       

        IEnumerable<Country> SelectCountries();


    }
}
