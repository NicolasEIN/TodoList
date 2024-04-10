using TodoList.Enums;

namespace TodoList.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }

        public int? UserId { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
