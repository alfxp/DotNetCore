using DotNetCore.Mapping;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DotNetCore.EntityFrameworkCore.Tests
{
    [TestClass]
    public class EntityFrameworkCoreTests
    {
        private readonly FakeContext _context;
        private readonly IFakeRepository _repository;

        public EntityFrameworkCoreTests()
        {
            var services = new ServiceCollection();

            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Tests;Integrated Security=true;Connection Timeout=5;";

            services.AddDbContextPool<FakeContext>(options => options.UseSqlServer(connectionString));

            _context = services.BuildServiceProvider().GetService<FakeContext>();

            _context.Database.EnsureDeleted();

            _context.Database.EnsureCreated();

            _context.Database.Migrate();

            _repository = new FakeRepository(_context);

            SeedDatabase();
        }

        private static FakeEntity Entity => new FakeEntity
        (
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            new FakeValueObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
        );

        [TestMethod]
        public void Tests()
        {
            var list1 = _repository.Queryable.Project<FakeEntity, FakeEntityModel>().ToListAsync().Result;
            var list2 = _repository.Queryable.Project<FakeEntity, FakeEntityModel>().ListAsync(new PagedListParameters()).Result;
            var result = _repository.Specify(new FakeSpecification());

            Assert.IsNotNull(list1);
            Assert.IsNotNull(list2);
            Assert.IsNotNull(result);
        }

        private void SeedDatabase()
        {
            if (_context.Set<FakeEntity>().Any()) { return; }

            for (var i = 1L; i <= 100; i++)
            {
                _repository.Add(Entity);
            }

            _context.SaveChanges();
        }
    }
}
