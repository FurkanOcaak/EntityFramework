using Core.Entites;

namespace Core.Entities.Concrete
{
    class UserOperationClaim :IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Operation { get; set; }
    }

}
