using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Helpers.Helpers;
using UserManagement.Models.Context;
using UserManagement.Models.Models;
using UserManagement.Repositories.Repositories;

namespace UserManagement.Repositories.Services
{
    public class UserServices : IUserInterface
    {
        Pooja326MVC3Entities entities = new Pooja326MVC3Entities();

     

        public IEnumerable<Country> SelectCountries()
        {
            return entities.Country.ToList();
        }

     

        public int SignIn(UserModel userModel)
        {
            try
            {
                var EmailCheck = entities.User.Where(m => m.Email == userModel.Email).FirstOrDefault();
                var checkValid = entities.User.Where(m => m.Email == userModel.Email && m.Password == userModel.Password).FirstOrDefault();
                if (EmailCheck != null)
                {
                    if (checkValid != null)
                    {
                        return EmailCheck.Id;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 00;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

  
    }
}
