using Core.Entities.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class ServiceAbout : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public ICollection<ServiceAboutItemsDto> ServiceAboutItems { get; set; }
    }
}
