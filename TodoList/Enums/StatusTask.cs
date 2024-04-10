using System.ComponentModel;

namespace TodoList.Enums
{
    public enum StatusTask
    {
        [Description("Todo")]
        Todo = 1,
        [Description("InProgress")]
        InProgress = 2,
        [Description("Paused")]
        Paused = 3,
        [Description("Completed")]
        Completed = 4,
    }
}
