using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniKanbanBoard.Views.UserControls;

public partial class KanbanCardUC : UserControl
{
    public KanbanCardUC()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty RemoveThisCardCommandProperty = DependencyProperty.Register(nameof(RemoveThisCardCommand),
        typeof(ICommand), typeof(KanbanCardUC));

    public ICommand RemoveThisCardCommand
    {
        get { return (ICommand)GetValue(RemoveThisCardCommandProperty); }
        set { SetValue(RemoveThisCardCommandProperty, value); }
    }

    private void RemoveThisCard(object sender, RoutedEventArgs e)
    {
        RemoveThisCardCommand?.Execute(DataContext);
    }
}
