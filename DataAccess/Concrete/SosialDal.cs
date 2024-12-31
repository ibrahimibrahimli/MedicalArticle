using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SosialDal: IBaseRepository<Sosial, ApplicationDbContext>, ISosialDal
    {
        private readonly ApplicationDbContext? _context;

        public SosialDal(ApplicationDbContext? context)
        {
            _context = context;
        }
    }
}
