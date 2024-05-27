using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Todo.Crud.Web.Api.Model;

public class EditTodoModel
{
    [FromRoute]
    [Required(ErrorMessage = "É obrigatorio informar um \'Id\'")]
    public int Id { get; set; }

    [FromBody]
    [Required]
    public EditTodoBodyModel? Body { get; set; }
}
