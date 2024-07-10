using System.Windows.Media;

namespace MiniKanbanBoard.Entities;

public class KanbanCard
{
    public string Name { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public Color ContentColor { get; set; } = Colors.Aquamarine;

    public Color HeaderColor { get; set; } = Colors.Aqua;

}
