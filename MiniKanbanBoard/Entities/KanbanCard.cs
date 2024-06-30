using System.Windows.Media;

namespace MiniKanbanBoard.Entities;

public class KanbanCard
{
    public string Name { get; set; } = "Card Name";

    public string Content { get; set; } = "Card Content";

    public Brush ContentColor { get; set; } = Brushes.Aquamarine;

    public Brush HeaderColor { get; set; } = Brushes.Aqua;

}
