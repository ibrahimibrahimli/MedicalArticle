using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class ContactViewModel
    {
        public List<Adress> Adresses { get; set; }
        public ContactCreateDto Contact { get; set; }
    }
}
