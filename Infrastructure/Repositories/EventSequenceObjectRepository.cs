using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventSequenceObjectRepository : GenericRepository<EventSequenceObject>, IEventSequenceObjectRepository
    {
        public EventSequenceObjectRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
