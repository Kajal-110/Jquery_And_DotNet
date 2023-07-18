using Krunal_Final_Test_Model.Context;
using Krunal_Final_Test_Model.Model;
using Krunal_Final_Test_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krunal_Final_Test_Repository.Services
{
    public class UserServices : IUser
    {
        KrunalFinalTestEntities _DbContext = new KrunalFinalTestEntities();
        public List<CityTable> getCityList()
        {
            try
            {
                return _DbContext.CityTable.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CountryTable> getCountryList()
        {
            try
            {
                return _DbContext.CountryTable.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<StateTable> getStateList()
        {
            try
            {
                return _DbContext.StateTable.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<City_Model> GetCityByStateId(int StateId)
        {
            try
            {
                List<City_Model> CityModelList = new List<City_Model>();
                foreach (CityTable city in _DbContext.CityTable.Where(x => x.StateId == StateId).ToList())
                {
                    CityModelList.Add(
                        new City_Model()
                        {
                            id = city.id,
                            CityName = city.CityName,
                            StateId = city.StateId,
                            CountryId = (int)city.CountryId
                        }
                        );
                }

                return CityModelList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<State_Model> GetStateByCountryId(int CountryId)
            {
            try
            {
                List<State_Model> StateModelList = new List<State_Model>();
                foreach (StateTable state in _DbContext.StateTable.Where(x => x.CountryId == CountryId).ToList())
                {
                    StateModelList.Add(
                        new State_Model()
                        {
                            StateName = state.StateName,
                            id = state.id,
                            CountryId = (int)state.CountryId
                        }
                        );
                }

                return StateModelList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AddUserInDB(User_Registration_Model user_Registration_Model)
        {
            var check = _DbContext.User_Registration.Any(x => x.Email.ToUpper().ToString() == user_Registration_Model.Email.ToUpper().ToString());
            if(!check)
            {
                User_Registration userData = new User_Registration();
                userData.id = user_Registration_Model.id;
                userData.FirstName = user_Registration_Model.FirstName;
                userData.LastName = user_Registration_Model.LastName;
                userData.Email = user_Registration_Model.Email;
                userData.Password = user_Registration_Model.Password;
                userData.DOB = user_Registration_Model.DOB;
                userData.Address = user_Registration_Model.Address;
                userData.CountryId = user_Registration_Model.CountryId;
                userData.StateId = user_Registration_Model.StateId;
                userData.CityId = user_Registration_Model.CityId;
                userData.PhotoPath = user_Registration_Model.PhotoPath;
                userData.Docpath = user_Registration_Model.Docpath;
                userData.Gender = user_Registration_Model.Gender;
                userData.Hobbies = user_Registration_Model.Hobbies;
                _DbContext.User_Registration.Add(userData);
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public User_Registration CheckEmail_Password(User_Registration_Model user_Registration_Model)
        {
            try
            {
                if (_DbContext.User_Registration.Any(u => u.Email.ToString().ToUpper() == user_Registration_Model.Email.ToString().ToUpper() && u.Password == user_Registration_Model.Password))
                {
                    return _DbContext.User_Registration.Where(u => u.Email.ToString().ToUpper() == user_Registration_Model.Email.ToString().ToUpper() && u.Password == user_Registration_Model.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User_Registration_Model ShowUser(int id)
        {
            User_Registration_Model userdata = new User_Registration_Model();
            var match = _DbContext.User_Registration.Where(x => x.id == id).FirstOrDefault();
            foreach(User_Registration user in _DbContext.User_Registration.Where(x => x.id == id).ToList())
            {
                userdata.id = match.id;
                userdata.FirstName = match.FirstName;
                userdata.LastName = match.LastName;
                userdata.Email = match.Email;
                userdata.Password = match.Password;
                userdata.DOB = match.DOB;
                userdata.Address = match.Address;
                userdata.CountryId = match.CountryId;
                userdata.StateId = match.StateId;
                userdata.CityId = match.CityId;
                userdata.PhotoPath = match.PhotoPath;
                userdata.Docpath = match.Docpath;
                userdata.Gender = match.Gender;
                userdata.Hobbies = match.Hobbies;
            }
            return userdata;
        }

        public bool UpdateUser(int id, User_Registration_Model user_Registration_Model)
        {
            try
            {

                var SelectedUser = _DbContext.User_Registration.Find(id);
                SelectedUser.FirstName = user_Registration_Model.FirstName;
                SelectedUser.LastName = user_Registration_Model.LastName;
                SelectedUser.Email = user_Registration_Model.Email;
                SelectedUser.Password = user_Registration_Model.Password;
                SelectedUser.DOB = user_Registration_Model.DOB;
                SelectedUser.Address = user_Registration_Model.Address;
                SelectedUser.CountryId = user_Registration_Model.CountryId;
                SelectedUser.StateId = user_Registration_Model.StateId;
                SelectedUser.CityId = user_Registration_Model.CityId;
                SelectedUser.PhotoPath = user_Registration_Model.PhotoPath;
                SelectedUser.Docpath = user_Registration_Model.Docpath;
                SelectedUser.Gender = user_Registration_Model.Gender;
                SelectedUser.Hobbies = user_Registration_Model.Hobbies;
                _DbContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public User_Registration_Model GetUserById(int id)
        {
            try
            {
                var user = _DbContext.User_Registration.Find(id);
                return new User_Registration_Model()
                {
                    id = user.id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    DOB = user.DOB,
                    Address = user.Address,
                    CountryId = user.CountryId,
                    StateId = user.StateId,
                    CityId = user.CityId,
                    PhotoPath = user.PhotoPath,
                    Docpath = user.Docpath,
                    Gender = user.Gender,
                    Hobbies = user.Hobbies                    
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*public List<User_Registration> ShowUser(int id)
        {
            try
            {
                List<User_Registration> UserModelList = new List<User_Registration>();
                foreach (User_Registration users in _DbContext.User_Registration.Where(x => x.id == id).ToList())
                {
                    UserModelList.Add(
                        new User_Registration()
                        {
                            id = users.id,
                            FirstName = users.FirstName,
                            LastName = users.LastName,
                            Email = users.LastName,
                            Password = users.Password,
                            DOB = users.DOB,
                            Address = users.Address,
                            CountryId = users.CountryId,
                            StateId = users.StateId,
                            CityId = users.CityId,
                            PhotoPath = users.PhotoPath,
                            Docpath = users.Docpath,
                            Gender = users.Gender,
                            Hobbies = users.Hobbies
                        }
                        );
                }

                return UserModelList;
            }
        }*/
    }

}
