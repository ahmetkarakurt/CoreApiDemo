namespace Core.Entitiy.Concrete
{
    public class UserOparationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OparationClaimId { get; set; }
    }
}
