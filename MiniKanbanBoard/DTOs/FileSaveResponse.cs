namespace MiniKanbanBoard.DTOs;

public class FileSaveResponse(bool success)
{
    public bool Success { get; set; } = success;
}
