﻿namespace Todo.Crud.Web.Domain.DTOs.Response;

public class TodoResponseDTO
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public bool? Completed { get; set; }
}