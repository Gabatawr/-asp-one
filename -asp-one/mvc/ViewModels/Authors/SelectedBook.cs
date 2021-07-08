using mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.ViewModels.Authors
{
    public class SelectedBook
    {
        public Book Book { get; set; }
        public bool IsSelected { get; set; }
    }
}
