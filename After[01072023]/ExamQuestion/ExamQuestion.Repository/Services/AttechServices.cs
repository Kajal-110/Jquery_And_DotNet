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
    public class AttechServices: IAttech
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();

        public bool AddUserInDB(MiltipleAttachmentModel miltipleAttachmentModel)
        {

                MiltipleAttachment userData = new MiltipleAttachment();
                userData.Id = miltipleAttachmentModel.Id;
                userData.Title = miltipleAttachmentModel.Title;

                userData.Attachment = miltipleAttachmentModel.Attachment;               
                db.MiltipleAttachment.Add(userData);
                db.SaveChanges();
                return true;          

        }
    }
}
