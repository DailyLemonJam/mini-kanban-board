using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MiniKanbanBoard.Entities;

public class KanbanColumn
{
    public string Name { get; set; } = string.Empty;

    public ObservableCollection<KanbanCard> KanbanCards { get; set; } = [];

    public Brush ContentColor { get; set; } = Brushes.Aquamarine;

    public Brush HeaderColor { get; set; } = Brushes.Aqua;
}
