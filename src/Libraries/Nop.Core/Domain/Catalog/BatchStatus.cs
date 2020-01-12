using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Catalog
{
    public enum BatchStatus
    {
        Awaiting = 0,

        Scheduling = 1,

        Scheduled = 2,

        Executing = 3,

        Complete = 4,
    }
}
