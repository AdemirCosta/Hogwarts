using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Test.Settings.Seeds;

namespace Test.Settings.Factories
{
    public static class DbContextFactory
    {
        static HogwartsContext _dbContext;

        public static HogwartsContext Create()
        {
            var options = new DbContextOptionsBuilder<HogwartsContext>()
                            .UseInMemoryDatabase("HogwartsTest")
                            .Options;

            _dbContext = new HogwartsContext(options);

            SeedDbContext(_dbContext);

            return _dbContext;
        }

        private static void SeedDbContext(HogwartsContext context)
        {
            context.Characters.AddRange(CharacterSeed.Seeds());

            context.SaveChanges();
        }

        public static void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
