using ExamQuestion.Helper.Helpers;
using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using ExamQuestion.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamQuestion.Repository.Services
{
    public class LoginServices: ILogin
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();      
               
        public ImageModel ShowUser(int id)
        {
            ImageModel userdata = new ImageModel();
            var match = db.Image.Where(x => x.id == id).FirstOrDefault();
            foreach (Image user in db.Image.Where(x => x.id == id).ToList())
            {
                userdata.id = match.id;
                userdata.Title = match.Title;
                userdata.ImagePath = match.ImagePath;               
            }
            return userdata;
        }
       

        public bool AddUser(ImageModel imageModel)
        {
            try
            {
              
                    Image image = new Image();
                    image.id = imageModel.id;
                    image.Title = imageModel.Title;
                    image.ImagePath = imageModel.ImagePath;                   
                    db.Image.Add(image);
                    db.SaveChanges();
                    return true;                
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
