using E_Commerce.Models.DbContext;
using E_Commerce.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Helpers.Helper
{
    public static class UserHelper
    {
        public static Registration convertToCustom(RegistrationModel registrationModel)
        {
            Registration registration = new Registration();
            registration.UserId = registrationModel.UserId;
            registration.FirstName = registrationModel.FirstName;
            registration.LastName = registrationModel.LastName;
            registration.Email = registrationModel.Email;
            registration.Password = registrationModel.Password;
            registration.Address = registrationModel.Address;
            registration.CountryId = registrationModel.CountryId;
            registration.StateId = registrationModel.StateId;
            registration.CityId = registrationModel.CityId;
            registration.Profile_Picture = registrationModel.Profile_Picture;
            registration.Gender = registrationModel.Gender;
            return registration;
        }
    }
}