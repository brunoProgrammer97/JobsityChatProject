using JobsityChatProject.Core.Models;
using JobsityChatProject.Infrastructure.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsityChatProject.TestData
{
    public static class TestDataHandler
    {
        public static void AddTestData(JobsityChatContext context)
        {
            var testUser1 = new User()
            {
                UserName = "Test1",
                Password = "Pass1"
            };

            context.Users.Add(testUser1);

            var testUser2 = new User()
            {
                UserName = "Test2",
                Password = "Pass2"
            };

            context.Users.Add(testUser2);

            context.SaveChanges();
        }
    }
}
