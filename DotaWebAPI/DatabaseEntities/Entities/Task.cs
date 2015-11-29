using System;

namespace DatabaseEntities.Entities
{
    public enum TaskPriorityEnum
    {
        Low = 10,
        Normal = 20,
        High = 30,
        VeryHigh = 50,
        Superior = 100,
    }
    public enum TaskTypeEnum
    {
        FindMatch = 1,
        FindMatchList = 2,
    }
    public class Task : ObjectBase, ICloneable
    {
        public int RequestID { get; set; }
        public int? HeroID { get; set; }
        public int? EnemyHeroID { get; set; }
        public int? RequestFrom { get; set; }
        public int? Count { get; set; }
        public TaskTypeEnum TaskType { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public bool Finished { get; set; }
        public object Clone()
        {
            return new Task
            {
                RequestID = RequestID,
                Count = Count,
                EnemyHeroID = EnemyHeroID,
                Finished = Finished,
                HeroID = HeroID,
                Priority = Priority,
                RequestFrom = RequestFrom,
                TaskType = TaskType
            };
        }
    }
}
