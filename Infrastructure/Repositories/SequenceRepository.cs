using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SequenceRepository : GenericRepository<Sequence>, ISequenceRepository
    {
        public SequenceRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
