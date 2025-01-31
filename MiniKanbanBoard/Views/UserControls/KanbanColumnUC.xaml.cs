﻿using MiniKanbanBoard.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MiniKanbanBoard.Views.UserControls;

public partial class KanbanColumnUC : UserControl
{
    private bool SettingsRowVisible = false;

    public KanbanColumnUC()
    {
        InitializeComponent();
    }

    // Colors
    private void HeaderColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        if (e.NewValue != null)
        {
            SettingsRow.Background = new SolidColorBrush(e.NewValue.Value);
            TopRow.Background = new SolidColorBrush(e.NewValue.Value);
            KanbanColumnEntity.HeaderColor = e.NewValue.Value;
            //KanbanColumnEntity.HeaderColor = new SolidColorBrush(e.NewValue.Value);
        }
    }

    private void ContentColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        if (e.NewValue != null)
        {
            MainContent.Background = new SolidColorBrush(e.NewValue.Value);
            KanbanColumnEntity.ContentColor = e.NewValue.Value;
            //KanbanColumnEntity.ContentColor = new SolidColorBrush(e.NewValue.Value);
        }
    }

    // ColumnEntity
    public static readonly DependencyProperty KanbanColumnEntityProperty = DependencyProperty.Register(nameof(KanbanColumnEntity),
        typeof(KanbanColumn), typeof(KanbanColumnUC));

    public KanbanColumn KanbanColumnEntity
    {
        get { return (KanbanColumn)GetValue(KanbanColumnEntityProperty); }
        set { SetValue(KanbanColumnEntityProperty, value); }
    }

    // AddCardCommand
    public static readonly DependencyProperty AddCardCommandProperty = DependencyProperty.Register(nameof(AddCardCommand),
        typeof(ICommand), typeof(KanbanColumnUC));

    public ICommand AddCardCommand
    {
        get { return (ICommand)GetValue(AddCardCommandProperty); }
        set { SetValue(AddCardCommandProperty, value); }
    }
    
    private void AddCard_Click(object sender, RoutedEventArgs e)
    {
        AddCardCommand.Execute(this);
    }

    // RemoveThisCardCommand
    public static readonly DependencyProperty RemoveThisCardCommandProperty = DependencyProperty.Register(nameof(RemoveThisCardCommand),
        typeof(ICommand), typeof(KanbanColumnUC));

    public ICommand RemoveThisCardCommand
    {
        get { return (ICommand)GetValue(RemoveThisCardCommandProperty); }
        set { SetValue(RemoveThisCardCommandProperty, value); }
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
}
