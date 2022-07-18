namespace Formation.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}
