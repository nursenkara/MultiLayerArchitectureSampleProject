using Core.Entities.Abstract;

namespace Entities.Dtos.Admin
{
    public class AdminForRegisterDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}