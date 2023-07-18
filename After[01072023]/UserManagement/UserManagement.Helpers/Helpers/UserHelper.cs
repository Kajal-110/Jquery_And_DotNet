using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Context;
using UserManagement.Models.Models;

namespace UserManagement.Helpers.Helpers
{
    public class UserHelper
    {
        public static User BindUserToUserModel(UserModel userModel)
        {
            User user = new User();
            user.Id = userModel.Id;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.DOB = userModel.DOB;
            user.Address = userModel.Address;
            user.CountryId = userModel.CountryId;
            user.StateId = userModel.StateId;
            user.CityId = userModel.CityId;
            user.Attachment = userModel.Attachment;
            user.Gender = userModel.Gender;
            user.Hobbies = userModel.Hobbies;
            user.Profile = userModel.Profile;
            return user;
        }
    }
}
