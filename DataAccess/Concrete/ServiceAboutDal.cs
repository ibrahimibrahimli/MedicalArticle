﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class ServiceAboutDal : BaseRepository<ServiceAbout, ApplicationDbContext>, IServiceAboutDal
    {
    }
}