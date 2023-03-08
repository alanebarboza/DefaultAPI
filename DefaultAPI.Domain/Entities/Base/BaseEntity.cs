namespace DefaultAPI.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime InsertedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
