﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ServiceAboutItemsDal : BaseRepository<ServiceAboutItems, ApplicationDbContext>, IServiceAboutItemsDal
    {
        private readonly ApplicationDbContext? _context;

        public ServiceAboutItemsDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<ServiceAboutItemsDto> GetServiceAboutItemsWidthServiceAbout()
        {
            var result = from serviceAboutItems in _context.ServiceAboutItems
                         where serviceAboutItems.Deleted == 0
                         join serviceAbout in _context.ServiceAbouts on serviceAboutItems.ServiceAboutId equals serviceAbout.Id
                         where serviceAbout.Deleted == 0
                         select new ServiceAboutItemsDto
                         {
                             Id = serviceAboutItems.Id,
                             Text = serviceAboutItems.Text,
                             ServiceAboutTitle = serviceAbout.Title,
                             ServiceAboutDescription = serviceAbout.Description,
                             ServiceAboutPhotoUrl = serviceAbout.PhotoUrl,
                         };
            return [.. result];
        }


        public List<ServiceAboutItems> GetDataByLanguage(string lang)
        {
            var data = _context.ServiceAboutItems
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }
    }
}
