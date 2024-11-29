using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealtTipItemsDto
    {
        public int Id { get; set; }
        public int HealtTipId { get; set; }
        public string Text { get; set; }
    }
}
