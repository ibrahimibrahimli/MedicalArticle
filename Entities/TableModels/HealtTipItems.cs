using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class HealtTipItems : BaseEntity
    {
        public int HealtTipId { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual HealtTip HealtTip { get; set; }
    }
}
