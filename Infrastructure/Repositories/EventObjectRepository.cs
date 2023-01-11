using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventObjectRepository : GenericRepository<EventObject>, IEventObjectRepository
    {
        public EventObjectRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
