using JobsityChatProject.Core.Models;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System;
using JobsityChatProject.Infrastructure.Queries;

namespace JobsityChat.Tests.Repository
{
    public class UserRepositoryQuerieTests
    {
        [Fact]
        public void Querie_Shouldent_Find_Any_User_By_Username()
        {
            IEnumerable<ChatUser> chatUsersMock = new List<ChatUser>()
            {
                new ChatUser()
                {
                    UserName = "Test1"
                },
                new ChatUser()
                {
                    UserName = "Test2"
                }
            };
            var expression = UserQueries.GetByUsername("Test3");

            var findedUser = chatUsersMock.AsQueryable().Where(expression).FirstOrDefault();

            Assert.Null(findedUser);
        }

        [Fact]
        public void Querie_Should_Find_A_User_By_Username()
        {
            IEnumerable<ChatUser> chatUsersMock = new List<ChatUser>()
            {
                new ChatUser()
                {
                    UserName = "Test1"
                },
                new ChatUser()
                {
                    UserName = "Test2"
                }
            };
            var expression = UserQueries.GetByUsername("Test1");

            var findedUser = chatUsersMock.AsQueryable().Where(expression).FirstOrDefault();

            Assert.NotNull(findedUser);
        }

        [Fact]
        public void Querie_Shouldent_Find_Any_User_By_Username_And_Pass()
        {
            IEnumerable<ChatUser> chatUsersMock = new List<ChatUser>()
            {
                new ChatUser()
                {
                    UserName = "Test1",
                    Password = "123"
                },
                new ChatUser()
                {
                    UserName = "Test2",
                     Password = "123"
                }
            };
            var expression = UserQueries.GetUserByPasswordAndUsername("Test2", "1234");

            var findedUser = chatUsersMock.AsQueryable().Where(expression).FirstOrDefault();

            Assert.Null(findedUser);
        }

        [Fact]
        public void Querie_Should_Find_Any_User_By_Username_And_Pass()
        {
            IEnumerable<ChatUser> chatUsersMock = new List<ChatUser>()
            {
                new ChatUser()
                {
                    UserName = "Test1",
                    Password = "123"
                },
                new ChatUser()
                {
                    UserName = "Test2",
                     Password = "123"
                }
            };
            var expression = UserQueries.GetUserByPasswordAndUsername("Test2", "123");

            var findedUser = chatUsersMock.AsQueryable().Where(expression).FirstOrDefault();

            Assert.NotNull(findedUser);
        }
    }
}
