using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}