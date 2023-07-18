using ExamQuestion.Helper.Helpers;
using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using ExamQuestion.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamQuestion.Repository.Services
{
    public class UserService: IUser
    {
        
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
        public bool AddUser(RegistrationModel match)
        {
            try
            {
                var check = db.Registration.Any(x => x.Email.ToUpper().ToString() == match.Email.ToUpper().ToString());
                if (!check)
                {
                    Registration userdata = new Registration();
                    userdata.UserId = match.UserId;
                    userdata.FirstName = match.FirstName;
                    userdata.LastName = match.LastName;
                    userdata.Email = match.Email;
                    userdata.Password = match.Password;
                    userdata.Date_of_birth = match.Date_of_birth;
                    userdata.Address = match.Address;
                    userdata.CountryId = match.CountryId;
                    userdata.StateId = match.StateId;
                    userdata.CityId = match.CityId;
                    userdata.Profile_photo = match.Profile_photo;
                    userdata.Attachment = match.Attachment;
                    userdata.Gender = match.Gender;
                    userdata.Hobbies = match.Hobbies;
                    db.Registration.Add(userdata);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                              
                /*Registration registration = new Registration();
                registration = UserHelper.ConvertToCustomModel(registrationModel);               
                if (registration != null)
                {
                    db.Registration.Add(registration);
                    db.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Fail";
                }*/
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<Country> GetALLCountry()
        {
            List<Country> countries = db.Country.ToList();
            return (countries);
        }

        public List<State> GetAllState(int CountryId)
        {
            List<State> states = db.State.Where(x => x.CountryId == CountryId).ToList();
            return states;
        }

        public List<City> GetAllCity(int StateId)
        {
            List<City> cities = db.City.Where(x => x.StateId == StateId).ToList();
            return cities;
        }

        public string LoginUser(RegistrationModel registrationModel)
        {
            try
            {
                var email = db.Registration.Where(x => x.Email == registrationModel.Email).FirstOrDefault();
                var pass = db.Registration.Where(x => x.Password == registrationModel.Password).FirstOrDefault();
                if (email == null && pass == null)
                {
                    return "Invalid Email and Password";

                }
                else if (email != null)
                {
                    if (email.Password != registrationModel.Password)
                    {
                        return "Invalid Password";
                    }
                    else
                    {
                        return email.Email;
                    }
                }
                else
                {
                    return "Invalid Email";
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        } 

        /*public List<RegistrationModel> GetAllUser()
        {
            try
            {
                List<Registration> registrations = new List<Registration>();
                List<RegistrationModel> registrationModels = new List<RegistrationModel>();

                registrations = db.Registration.ToList(); 
                if(registrations != null && registrations.Count > 0)
                {
                    registrationModels = UserHelper.ForList(registrations);
                }
                return registrationModels ;

            }
            catch (Exception e)
            {

                throw e; 
            }
        }*/

        public RegistrationModel ShowUser(int id)
        {
            RegistrationModel userdata = new RegistrationModel();
            var match = db.Registration.Where(x => x.UserId == id).FirstOrDefault();
            foreach(Registration user in db.Registration.Where(x => x.UserId == id).ToList())
            {
                userdata.UserId = match.UserId;
                userdata.FirstName = match.FirstName;
                userdata.LastName = match.LastName;
                userdata.Email = match.Email;
                userdata.Password = match.Password;
                userdata.Date_of_birth = match.Date_of_birth;
                userdata.Address = match.Address;
                userdata.CountryId = match.CountryId;
                userdata.StateId = match.StateId;
                userdata.CityId = match.CityId;
                userdata.Profile_photo = match.Profile_photo;
                userdata.Attachment = match.Attachment;
                userdata.Gender = match.Gender;
                userdata.Hobbies = match.Hobbies;
            }
            return userdata;
        }

    }
}
