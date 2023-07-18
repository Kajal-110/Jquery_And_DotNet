using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamQuestion.Repository.Repositories
{
    public interface ILogin
    {
        ImageModel ShowUser(int id);
        
        bool AddUser(ImageModel imageModel);
    }
}
