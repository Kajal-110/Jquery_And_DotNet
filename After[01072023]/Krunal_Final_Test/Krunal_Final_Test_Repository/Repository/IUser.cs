using Krunal_Final_Test_Model.Context;
using Krunal_Final_Test_Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krunal_Final_Test_Repository.Repository
{
    public interface IUser
    {
        User_Registration CheckEmail_Password(User_Registration_Model user_Registration_Model);

        List<CountryTable> getCountryList();

        List<StateTable> getStateList();

        List<CityTable> getCityList();

        List<State_Model> GetStateByCountryId(int CountryId);

        List<City_Model> GetCityByStateId(int StateId);

        bool AddUserInDB(User_Registration_Model user_Registration_Model);


        User_Registration_Model ShowUser(int id);

        User_Registration_Model GetUserById(int id);

        bool UpdateUser(int id, User_Registration_Model user_Registration_Model);

    }
}
