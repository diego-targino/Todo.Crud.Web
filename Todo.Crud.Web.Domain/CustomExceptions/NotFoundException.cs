namespace Todo.Crud.Web.Domain.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message) { }
    }
}
