﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Infra.Contracts.Rotinas.Sistema
{
    public interface IRotinaInjection : IRotinaComum
    {
        string Run();
    }
}