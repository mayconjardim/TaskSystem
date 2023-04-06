using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {

        [Description("Pending")]
        Pending = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("In Completed")]
        Completed = 3

    }
}
