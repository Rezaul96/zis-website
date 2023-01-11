using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IndustryRepository : GenericRepository<Industry>, IIndustryRepository
    {
        public IndustryRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
