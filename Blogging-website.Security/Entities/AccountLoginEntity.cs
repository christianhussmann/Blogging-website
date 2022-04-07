namespace Blogging_website.Security.Entities
{
    public class AccountLoginEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public int LoginId { get; set; }
    }
}