using GrapqlDotnetPostgree.Data;
using GrapqlDotnetPostgree.GraphQL.Command;
using GrapqlDotnetPostgree.GraphQL.Platform;
using GrapqlDotnetPostgree.Models;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapqlDotnetPostgree.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformsPayload> AddPlatform(AddPlatformsInput input, [ScopedService] AppDbContext context)
        {
            var platform = new Platforms
            {
                Name = input.Name
            };

            await context.Platforms.AddAsync(platform);
            await context.SaveChangesAsync();

            return new AddPlatformsPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandsPayLoad> AddCommands(AddCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = new Commands
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformsId = input.PlatformsId
            };

            await context.Commands.AddAsync(command);
            await context.SaveChangesAsync();

            return new AddCommandsPayLoad(command);
        }

    }
}
