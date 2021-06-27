using HotChocolate.Types;
using GrapqlDotnetPostgree.Models;
using HotChocolate;
using GrapqlDotnetPostgree.Data;
using System.Linq;

namespace GrapqlDotnetPostgree.GraphQL.Platform
{
    public class PlatformType : ObjectType<Platforms>
    {
        protected override void Configure(IObjectTypeDescriptor<Platforms> descriptor)
        {
            descriptor.Description("Represents any software or service that has command line interface");
            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolver>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is list of avaible commands for this platform");
        }

        private class Resolver
        {

            public IQueryable<Commands> GetCommands(Platforms platforms, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(p => p.PlatformsId == platforms.Id);
            }
        }
    }
}
