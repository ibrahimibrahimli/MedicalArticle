﻿using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class About : BaseEntity
    {
        public string Title {  get; set; }
        public string Description { get; set; } 
        public string PhotoUrl { get; set; }
    }
}
