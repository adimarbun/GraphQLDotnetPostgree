using GrapqlDotnetPostgree.Data;
using GrapqlDotnetPostgree.Models;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapqlDotnetPostgree.GraphQL
{
    public class Query
    {
 
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platforms> GetPlatforms([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }


        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Commands> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
