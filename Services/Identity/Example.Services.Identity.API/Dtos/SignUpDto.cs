namespace Example.Services.Identity.API.Dtos
{
    public class SignUpDto
    {
        public string UserName { get; internal set; }
        public string Email { get; internal set; }
        public string City { get; internal set; }
        public string Password { get; internal set; }
    }
}
