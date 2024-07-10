namespace MiniKanbanBoard.Entities;

public class SerializationTemplate(KanbanColumn toDoColumn, KanbanColumn doingColumn, KanbanColumn doneColumn)
{
    public KanbanColumn ToDoColumn { get; set; } = toDoColumn;
    public KanbanColumn DoingColumn { get; set; } = doingColumn;
    public KanbanColumn DoneColumn { get; set; } = doneColumn;
}
