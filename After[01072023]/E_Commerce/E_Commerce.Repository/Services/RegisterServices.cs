using E_Commerce.Helpers.Helper;
using E_Commerce.Models.DbContext;
using E_Commerce.Models.Model;
using E_Commerce.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Services
{
    public class RegisterServices: IRegister
    {
        Kajal_PatelEntities db = new Kajal_PatelEntities();
        public bool AddUser(RegistrationModel registrationModel)
        {
            Registration registration = new Registration();

             registration = UserHelper.convertToCustom(registrationModel);

            if(registration != null)
            {
                db.Registration.Add(registration);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
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

        public List<Country> GetALLCountry()
        {
            List<Country> countries = db.Country.ToList();
            return (countries);
        }

        public List<State> GetAllState(int CountryId)
        {
            List<State> states = db.State.Where(x => x.countryId == CountryId).ToList();
            return states;
        }

        public List<City> GetAllCity(int StateId)
        {
            List<City> cities = db.City.Where(x => x.stateId == StateId).ToList();
            return cities;
        }
    }
}
