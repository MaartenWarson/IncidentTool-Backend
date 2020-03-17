using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IUserData
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByName(string name);
        void Add(User newUser);
        void Update(int oldUserId, User newUser);
        void Delete(int id);
    }
}
