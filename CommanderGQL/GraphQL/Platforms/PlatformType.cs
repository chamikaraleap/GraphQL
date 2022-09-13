using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType:ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor
            .Field(f => f.Commands)
            .ResolveWith<Resolvers>(r => r.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>();
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext appDbContext)
            {
                return appDbContext.Commands.Where(c => c.PlatformId == platform.Id);
            }
        }

    }

}