using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Models;
using WebApplication1.Models;
using WebApplication1.Services;

namespace UnitTest
{
    public class GetTest
    {
        [Fact]
        public void TestGetUserById_UserIsExist_ReturnUser()
        {
            var mockUserDataService = new Mock<TodoService>();
            mockUserDataService.Setup(x => x.GetUserById(iterator.IsAny<int>()))
                .Returns(new TodoEntry { Title = "A", Description = "1", DueDate = new DateTime(2024, 05, 10), CreateDate = new DateTime(2024, 05, 10), UpdateDate = new DateTime(2024, 05, 10) },
                new TodoEntry { Title = "B", Description = "2", DueDate = new DateTime(2024, 05, 11), CreateDate = new DateTime(2024, 05, 10), UpdateDate = new DateTime(2024, 05, 10) },
                new TodoEntry { Title = "C", Description = "3", DueDate = new DateTime(2024, 05, 12), CreateDate = new DateTime(2024, 05, 10), UpdateDate = new DateTime(2024, 05, 10) });

            TodoService todoService = new TodoService(null, CreateContext());
            int expectUserId = 1;

            var result = todoService.GetAll().Result;

            Assert.Equal(3, result.Count);
        }

        private WebApiDemoContext CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}
