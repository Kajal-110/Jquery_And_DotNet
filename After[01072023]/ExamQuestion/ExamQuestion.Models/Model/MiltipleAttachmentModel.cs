using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExamQuestion.Models.Model
{
    public class MiltipleAttachmentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Attachment { get; set; }
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}
