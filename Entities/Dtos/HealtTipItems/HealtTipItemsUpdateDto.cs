using Entities.TableModels;

namespace Entities.Dtos
{
    public class HealtTipItemsUpdateDto
    {

        public int Id { get; set; }

        public int HealtTipId { get; set; }
        public string Text { get; set; }

        public static HealtTipItems ToHealtTipItems(HealtTipItemsUpdateDto dto)
        {
            HealtTipItems healtTipItems = new HealtTipItems()
            {
                Id = dto.Id,
                Text = dto.Text,
                HealtTipId = dto.HealtTipId
            };
            return healtTipItems;
        }
    }
}
