﻿using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class WhyChooseUsItems : BaseEntity
    {
        public int WhyChooseUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual WhyChooseUs WhyChooseUs { get; set; }
    }
}
