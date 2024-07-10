using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MiniKanbanBoard.Entities;

public class KanbanColumn
{
    public string Name { get; set; } = string.Empty;

    public ObservableCollection<KanbanCard> KanbanCards { get; set; } = [];

    public Color ContentColor { get; set; } = Colors.Aquamarine;

    public Color HeaderColor { get; set; } = Colors.Aqua;
}
