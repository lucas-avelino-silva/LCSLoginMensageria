﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IDomainTable : IDomainView, IDisposable
    {
        Guid Id { get; set; }
    }
}
