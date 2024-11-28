using ORM.Core;

namespace ORM.Model {
    public abstract class Model<T> : Query<T> where T : Model<T>, new() {

        protected string? modelName;

        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }  = DateTime.Now;


    }
}
