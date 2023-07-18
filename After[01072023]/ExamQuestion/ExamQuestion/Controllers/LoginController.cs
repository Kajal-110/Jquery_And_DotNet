using ExamQuestion.Models.Model;
using ExamQuestion.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamQuestion.Controllers
{
    public class LoginController : Controller
    {
        ILogin LoginInterface;
        public LoginController(ILogin LoginInterface)
        {
            this.LoginInterface = LoginInterface;
        }
       
    }
}