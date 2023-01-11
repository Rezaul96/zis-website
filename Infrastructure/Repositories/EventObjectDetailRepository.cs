using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventObjectDetailRepository : GenericRepository<EventObjectDetail>, IEventObjectDetailRepository
    {
        public EventObjectDetailRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
