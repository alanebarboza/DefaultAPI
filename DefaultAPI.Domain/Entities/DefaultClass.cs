using AutoMapper;
using DefaultAPI.Domain.Entities.Base;

namespace DefaultAPI.Domain.Entities
{
    public class DefaultClass : BaseEntity
    {
        public string Description { get; private set; }
        public decimal Value { get; private set; }
    }
}
