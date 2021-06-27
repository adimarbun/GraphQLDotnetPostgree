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
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platforms> GetPlatforms([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }


        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Commands> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
