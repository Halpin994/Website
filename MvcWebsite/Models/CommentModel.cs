using System;

namespace MvcWebsite.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Webpage { get; set; }
        public string Comment { get; set; }

        public CommentModel(){}

        public CommentModel(String webpage)
        {
            Webpage = webpage;
        }
    }
}