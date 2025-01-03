﻿using Entities.TableModels;

namespace Entities.Dtos
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public bool IsAnswered { get; set; }

        public static Contact ToContact (ContactCreateDto dto)
        {
            return new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Message = dto.Comments,
                IsAnswered = dto.IsAnswered,
            };
        }
    }
}
