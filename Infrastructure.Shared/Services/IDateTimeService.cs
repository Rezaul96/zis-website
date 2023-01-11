using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
