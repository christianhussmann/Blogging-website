namespace Blogging_website.Security.Models
{
    public class AccountLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int LoginId { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}