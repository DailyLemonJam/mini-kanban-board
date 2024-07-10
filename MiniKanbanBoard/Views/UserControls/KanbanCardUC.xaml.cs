using MiniKanbanBoard.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MiniKanbanBoard.Views.UserControls;

public partial class KanbanCardUC : UserControl
{
    private bool SettingsRowVisible = false;

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

    private void Settings_Click(object sender, RoutedEventArgs e)
    {
        if (SettingsRowVisible)
        {
            SettingsRowVisible = false;
            SettingsRow.Visibility = Visibility.Collapsed;
            SettingsImage.RenderTransform = new RotateTransform(0);
        }
        else
        {
            SettingsRowVisible = true;
            SettingsRow.Visibility = Visibility.Visible;
            SettingsImage.RenderTransform = new RotateTransform(180);
        }
    }

    private void HeaderColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        var dataContext = (KanbanCard)DataContext;
        if (e.NewValue != null)
        {
            //dc.HeaderColor = new SolidColorBrush(e.NewValue.Value);
            dataContext.HeaderColor = e.NewValue.Value;
            TopRow.Background = new SolidColorBrush(e.NewValue.Value);
            SettingsRow.Background = new SolidColorBrush(e.NewValue.Value);
        }
    }

    private void ContentColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        var dataContext = (KanbanCard)DataContext;
        if (e.NewValue != null)
        {
            //dc.ContentColor = new SolidColorBrush(e.NewValue.Value);
            dataContext.ContentColor = e.NewValue.Value;
            MainContent.Background = new SolidColorBrush(e.NewValue.Value);
        }
    }
}
