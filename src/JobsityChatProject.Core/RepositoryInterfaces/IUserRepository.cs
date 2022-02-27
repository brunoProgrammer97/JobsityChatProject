using JobsityChatProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChatProject.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task SaveUserAsync(User user);
        Task GetUserAsync(User user);
    }
}
