using System.Collections.Generic;
using System.Linq;
using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SqlUserData : IUserData
    {
        private IMToolContext _context;

        public SqlUserData(IMToolContext context)
        {
            _context = context;
        }

        // Niet in gebruik voor opdracht
        public IEnumerable<User> GetAll()
        {
            return _context.Users.OrderBy(u => u.UserId).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }
        public User GetByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        // Niet in gebruik voor opdracht
        public void Add(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Update(int oldUserId, User newUser)
        {
            _context.Users.Where(u => u.UserId == oldUserId)
                          .ToList()
                          .ForEach(u => u = newUser);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Delete(int id)
        {
            _context.Users.Where(u => u.UserId == id)
                          .ToList()
                          .RemoveAll(u => u.UserId == id);
            _context.SaveChanges();
        }
    }
}
