using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamQuestion.Repository.Repositories
{
    public interface IUser
    {
        /*string AddUser(RegistrationModel registrationModel);*/
        bool AddUser(RegistrationModel match);
        List<Country> GetALLCountry();
        List<State> GetAllState(int CountryId);
        List<City> GetAllCity(int StateId);
        string LoginUser(RegistrationModel registrationModel);
/*        List<RegistrationModel> GetAllUser();*/

        RegistrationModel ShowUser(int id);
    }
}
