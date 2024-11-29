using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class ServiceAboutItems : BaseEntity
    {
        public int ServiceAboutId { get; set; }
        public string Text { get; set; }
        public virtual ServiceAbout ServiceAbout { get; set; }
    }
}
