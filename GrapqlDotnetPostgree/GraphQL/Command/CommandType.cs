using GrapqlDotnetPostgree.Data;
using GrapqlDotnetPostgree.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapqlDotnetPostgree.GraphQL.Command
{
    public class CommandType : ObjectType<Commands>
    {
        protected override void Configure(IObjectTypeDescriptor<Commands> descriptor)
        {
            descriptor.Description("Respesents any executable command");

            descriptor
                .Field(c => c.Platforms)
                .ResolveWith<Resolvers>(c => c.GetPlatforms(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform to which the command belongs");
        }

        private class Resolvers
        {
            public Platforms GetPlatforms(Commands commands, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == commands.PlatformsId);
            }
        }
    }
}
