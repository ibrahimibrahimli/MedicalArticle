﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class Blog : BaseEntity  
    {
        public int TeamboardId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public List<string>? Comment { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual TeamBoard TeamBoard { get; set; }
    }
}
