using System;

namespace Models
{
    public sealed class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        
        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is TodoItem other && Equals(other);
        }

        private bool Equals(TodoItem other)
        {
            return Id == other.Id && Name == other.Name && IsComplete == other.IsComplete;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsComplete);
        }
    }
}
