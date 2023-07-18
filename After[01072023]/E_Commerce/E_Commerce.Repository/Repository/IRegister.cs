using E_Commerce.Models.DbContext;
using E_Commerce.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public interface IRegister
    {
        bool AddUser(RegistrationModel registrationModel);
        List<Country> GetALLCountry();

        List<State> GetAllState(int CountryId);

        List<City> GetAllCity(int StateId);

        string LoginUser(RegistrationModel registrationModel);
    }
}
