using MiniKanbanBoard.Entities;
using MiniKanbanBoard.Enums;

namespace MiniKanbanBoard.DTOs;

public class SaveBoardRequest(SaveRequestType requestType, KanbanColumn toDoColumn, KanbanColumn doingColumn, KanbanColumn doneColumn)
{
    public SaveRequestType RequestType { get; set; } = requestType;
    public KanbanColumn ToDoColumn { get; set; } = toDoColumn;
    public KanbanColumn DoingColumn { get; set; } = doingColumn;
    public KanbanColumn DoneColumn { get; set; } = doneColumn;
}
