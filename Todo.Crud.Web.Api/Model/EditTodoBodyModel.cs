using System.ComponentModel.DataAnnotations;

namespace Todo.Crud.Web.Api.Model;

public class EditTodoBodyModel
{
    [Required(ErrorMessage = "O campo \'Description\' é obrigatório")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O campo \'Completed\' é obrigatório")]
    public bool? Completed { get; set; }
}
