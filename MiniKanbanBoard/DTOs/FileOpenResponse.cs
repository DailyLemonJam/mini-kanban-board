using MiniKanbanBoard.Entities;

namespace MiniKanbanBoard.DTOs;

public class FileOpenResponse(bool isSuccess, KanbanColumn toDoColumn, KanbanColumn doingColumn, KanbanColumn doneColumn)
{
    public bool IsSuccess { get; set; } = isSuccess;

    public KanbanColumn ToDoColumn { get; set; } = toDoColumn;
    public KanbanColumn DoingColumn { get; set; } = doingColumn;
    public KanbanColumn DoneColumn { get; set; } = doneColumn;
}
