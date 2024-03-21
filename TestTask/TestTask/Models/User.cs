using TestTask.Enums;

namespace TestTask.Models
{
    public class User
    {
        public int Id { get; set; } 

        public string? Email { get; set; }

        public UserStatus Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
