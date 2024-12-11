﻿using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsHomePage { get; set; }
        public string TeamboardName { get; set; }
        public string TeamboardSurname { get; set; }
        public int TeamboardId { get; set; }
    }
}
