using MiniKanbanBoard.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;

namespace MiniKanbanBoard.Views;

public partial class HostWindowView : Window
{
    public HostWindowView(HostWindowViewModel hostWindowViewModel)
    {
        DataContext = hostWindowViewModel;

        StateChanged += RepairWindowChrome;
        RepairWindowChrome(this, new EventArgs());

        InitializeComponent();
    }

    private void RepairWindowChrome(object? sender, EventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowChrome.SetWindowChrome(this, null);
        }
        else if (WindowState == WindowState.Normal)
        {
            var chrome = new WindowChrome
            {
                GlassFrameThickness = new Thickness(),
                CornerRadius = new CornerRadius(),
                CaptionHeight = 0
            };
            WindowChrome.SetWindowChrome(this, chrome);
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Maximize_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
        else
        {
            WindowState = WindowState.Maximized;
        }
    }

    private void Minimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void DragWindow(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void CustomDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
        {
            Maximize_Click(sender, e);
        }
    }
}