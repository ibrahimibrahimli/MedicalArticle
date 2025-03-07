﻿using Entities.TableModels;

namespace Entities.Dtos
{
    public class WhyChooseUsUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int LanguageId { get; set; }

        public static WhyChooseUs ToWhyChooseUs(WhyChooseUsUpdateDto dto)
        {
            WhyChooseUs whyChooseUs = new WhyChooseUs()
            {
                Id = dto.Id,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                LanguageId = dto.LanguageId
            };
            return whyChooseUs;
        }
    }
}
