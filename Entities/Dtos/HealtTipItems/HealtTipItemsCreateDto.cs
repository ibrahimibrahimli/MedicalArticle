using Entities.TableModels;

namespace Entities.Dtos
{
    public class HealtTipItemsCreateDto
    {

        public int HealtTipId { get; set; }
        public string Text { get; set; }

        public static HealtTipItems ToHealtTipItems(HealtTipItemsCreateDto dto)
        {
            HealtTipItems healtTipItems = new HealtTipItems()
            {
                HealtTipId = dto.HealtTipId,
                Text = dto.Text
            };
            return healtTipItems;
        }
    }
}
