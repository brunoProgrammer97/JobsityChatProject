using JobsityChatProject.Core.Models;
using System;
using System.Linq.Expressions;

namespace JobsityChatProject.Infrastructure.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<ChatUser, bool>> GetByUsername(string username)
        {
            return u => u.UserName.Equals(username);
        }

        public static Expression<Func<ChatUser,bool>> GetUserByPasswordAndUsername(string username, string password)
        {
            return u => u.UserName.Equals(username) && u.Password.Equals(password);
        }
    }
}
