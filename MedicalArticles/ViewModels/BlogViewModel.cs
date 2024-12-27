using Business.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class BlogViewModel
    {
        public List<BlogDto> Blogs { get; set; }
        public List<Sosial> Sosials { get; set; }
    }
}
