﻿using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public string CategoryName { get; set; }
        public string CategoryIconName { get; set; }
        public int LanguageId { get; set; }
    }
}
