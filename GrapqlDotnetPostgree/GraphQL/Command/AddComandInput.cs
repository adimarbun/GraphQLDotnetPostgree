﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapqlDotnetPostgree.GraphQL.Command
{
    public record AddCommandInput(string HowTo, string CommandLine, int PlatformsId);
} 
