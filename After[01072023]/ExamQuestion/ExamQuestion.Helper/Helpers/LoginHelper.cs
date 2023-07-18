using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamQuestion.Helper.Helpers
{
    public class LoginHelper
    {
        public static RegistrationModel ConvertToDB(Registration registration)
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.UserId = registration.UserId;
            registrationModel.FirstName = registration.FirstName;
            registrationModel.LastName = registration.LastName;
            registrationModel.Email = registration.Email;
            registrationModel.Password = registration.Password;
            registrationModel.Date_of_birth = registration.Date_of_birth;
            registrationModel.Country = registration.Country;
            registrationModel.State = registration.State;
            registrationModel.City = registration.City;
            registrationModel.Profile_photo = registration.Profile_photo;
            registrationModel.Attachment = registration.Attachment;
            registrationModel.Gender = registration.Gender;
            registrationModel.Hobbies = registration.Hobbies;
            return registrationModel;
        }

        public static Registration ConvertToCustomModel(RegistrationModel registration)
        {
            Registration registrationModel = new Registration();
            registrationModel.UserId = registration.UserId;
            registrationModel.FirstName = registration.FirstName;
            registrationModel.LastName = registration.LastName;
            registrationModel.Email = registration.Email;
            registrationModel.Password = registration.Password;
            registrationModel.Date_of_birth = registration.Date_of_birth;
            registrationModel.Address = registration.Address;
            registrationModel.CountryId = registration.CountryId;
            registrationModel.StateId = registration.StateId;
            registrationModel.CityId = registration.CityId;
            registrationModel.Profile_photo = registration.Profile_photo;
            registrationModel.Attachment = registration.Attachment;
            registrationModel.Gender = registration.Gender;
            registrationModel.Hobbies = registration.Hobbies;
            registrationModel.IsIntrestedInDanching = registration.IsIntrestedInDanching;
            registrationModel.IsIntrestedInReading = registration.IsIntrestedInReading;
            registrationModel.IsIntrestedInCooking = registration.IsIntrestedInDanching;

            return registrationModel;
        }


        public static List<RegistrationModel> ForList(List<Registration> registrations)
        {
            try
            {
                List<RegistrationModel> registrationModelList = new List<RegistrationModel>();
                foreach (var item in registrations)
                {
                    RegistrationModel registrationModel = new RegistrationModel();
                    registrationModel.UserId = item.UserId;
                    registrationModel.FirstName = item.FirstName;
                    registrationModel.LastName = item.LastName;
                    registrationModel.Email = item.Email;
                    registrationModel.Password = item.Password;
                    registrationModel.Date_of_birth = item.Date_of_birth;
                    registrationModel.Address = item.Address;
                    registrationModel.CountryId = item.CountryId;
                    registrationModel.CountryName = item.Country.CountryName;
                    registrationModel.StateId = item.StateId;
                    registrationModel.StateName = item.State.StateName;
                    registrationModel.CityId = item.CityId;
                    registrationModel.CityName = item.City.CityName;
                    registrationModel.Profile_photo = item.Profile_photo;
                    registrationModel.Attachment = item.Attachment;
                    registrationModel.Gender = item.Gender;
                    registrationModel.Hobbies = item.Hobbies;
                    registrationModel.IsIntrestedInDanching = item.IsIntrestedInDanching;
                    registrationModel.IsIntrestedInReading = item.IsIntrestedInReading;
                    registrationModel.IsIntrestedInCooking = item.IsIntrestedInDanching;
                    registrationModelList.Add(registrationModel);


                }
                return registrationModelList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
