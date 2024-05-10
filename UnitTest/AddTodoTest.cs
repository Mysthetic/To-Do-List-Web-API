using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApiDemo.Models;
using WebApplication1.Models;
using WebApplication1.Services;

namespace UnitTest
{
    public class AddTodoTest
    {
        private readonly DbContextOptions<WebApiDemoContext> _contextOptions;

        WebApiDemoContext CreateContext() => new WebApiDemoContext(_contextOptions);
        public AddTodoTest() {
            _contextOptions = new DbContextOptionsBuilder<WebApiDemoContext>()
                .UseInMemoryDatabase("TodoEntries")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using var context = new WebApiDemoContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                //new User { Id = 1, Name = "John" },
                //new User { Id = 2, Name = "Jane" });
                new TodoEntry { Title = "A", Description = "1", DueDate = new DateTime(2024, 05, 10), CreateDate = new DateTime(2024, 05, 10), UpdateDate = new DateTime(2024, 05, 10) },
                new TodoEntry { Title = "B", Description = "2", DueDate = new DateTime(2024, 05, 11), CreateDate = new DateTime(2024, 05, 10), UpdateDate = new DateTime(2024, 05, 10) },
                new TodoEntry {Title = "C", Description = "3", DueDate = new DateTime(2024,05,12), CreateDate = new DateTime(2024, 05, 10), UpdateDate = new DateTime(2024, 05, 10) });

            context.SaveChanges();
        }

        [Fact]
        public void TestGetUserById_UserIsExist_ReturnUser()
        {
            TodoService todoService = new TodoService(null, CreateContext());
            int expectUserId = 1;

            var result = todoService.GetAll().Result;

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void TestGetUserById()
        {
            TodoService todoService = new TodoService(null, CreateContext());
            int expectUserId = 1;

            var result = todoService.GetAll().Result;

            Assert.Equal(3, result.Count);
        }
        //[Fact]
        //public void TestCreateUser()
        //{
        //    UserRepository userService = new UserRepository(CreateContext());
        //    User newUser = new()
        //    {
        //        Name = "Test"
        //    }

        //    Assert.True(newUser.Id == 0);
        //}
    }
}
