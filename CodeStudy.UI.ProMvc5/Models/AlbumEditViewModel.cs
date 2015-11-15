using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeStudy.UI.ProMvc5.Models
{
    public class AlbumEditViewModel
    {
        public Album AlbumToEdit { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Artists { get; set; }
    }
}