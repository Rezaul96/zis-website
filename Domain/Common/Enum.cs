using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public enum ActivityStatus
    {
        Pend=0,
        Ready = 1,
        Active = 2,
        Complete = 3,
    }
    public enum Roles
    {
        SuperAdmin,
        Admin,
        Facilitator,
        Basic
    }
    public enum EventStatus
    {
        Active = 0,
        Running = 1,
        Complete = 2,
    }
}
