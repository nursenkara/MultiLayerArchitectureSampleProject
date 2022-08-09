using Core.Entities.Abstract;

namespace Entities.Dtos.Admin
{
    public class AdminForLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}