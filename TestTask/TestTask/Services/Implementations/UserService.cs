using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services.Implementations
{
    public class UserService : Generic<Order>, IUserService
    {
        public UserService(ApplicationDbContext context) : base(context) { }

        public async Task<User> GetUser()
        {
            List<Order> allOrders = _context.Orders.ToList();
            List<User> allUsers = _context.Users.ToList();

            int UserCount = allUsers.Count;
            int uId = 0;
            int MaxOrdersCount = 1;

            foreach (User user in allUsers)
            {
                int counting = 0;
                foreach (Order order in allOrders.Where(o => o.UserId == user.Id))
                {
                    counting++; 
                }
                if (counting > MaxOrdersCount)
                { 
                    uId = user.Id;
                    MaxOrdersCount = counting;
                }
            }
            if (await _context.Users.FindAsync(uId) == null)
            {
                throw new Exception("");
            }
            else return _context.Users.Find(uId);


        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return  (List<User>)users.Where(u => u.Status == UserStatus.Inactive);
        }
    }
}
