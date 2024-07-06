using System.Windows.Media;

namespace MiniKanbanBoard.Entities;

public class KanbanCard
{
    public string Name { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public Brush ContentColor { get; set; } = Brushes.Aquamarine;

    public Brush HeaderColor { get; set; } = Brushes.Aqua;

}
