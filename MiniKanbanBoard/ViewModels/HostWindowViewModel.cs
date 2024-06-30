using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniKanbanBoard.Entities;
using MiniKanbanBoard.Models;
using System.Windows.Media;

namespace MiniKanbanBoard.ViewModels;

public partial class HostWindowViewModel : ObservableObject
{
    private readonly HostWindowModel _model;

    public KanbanColumn TodoColumn { get; set; }
    public KanbanColumn DoingColumn { get; set; }
    public KanbanColumn DoneColumn { get; set; }

    public HostWindowViewModel(HostWindowModel model)
    {
        _model = model;

        TodoColumn = new KanbanColumn
        {
            Name = "Todo",
            KanbanCards = 
            [
                new() { Name = "Card 1", Content = "Making this app" }
            ],
            HeaderColor = Brushes.Aquamarine,
            ContentColor = Brushes.Bisque,
        };
        DoingColumn = new KanbanColumn
        {
            Name = "Doing",
            KanbanCards = [],
            HeaderColor = Brushes.LightBlue,
            ContentColor = Brushes.Pink,
        };
        DoneColumn = new KanbanColumn
        {
            Name = "Done",
            KanbanCards = [],
            HeaderColor = Brushes.IndianRed,
            ContentColor = Brushes.CadetBlue,
        };;
    }

    [RelayCommand]
    private void AddToDoCard() => TodoColumn.KanbanCards.Add(new KanbanCard());

    [RelayCommand]
    private void AddDoingCard() => DoingColumn.KanbanCards.Add(new KanbanCard());

    [RelayCommand]
    private void AddDoneCard() => DoneColumn.KanbanCards.Add(new KanbanCard());

    [RelayCommand]
    private void RemoveTodoCard(KanbanCard card) => TodoColumn.KanbanCards.Remove(card);

    [RelayCommand]
    private void RemoveDoingCard(KanbanCard card) => DoingColumn.KanbanCards.Remove(card);

    [RelayCommand]
    private void RemoveDoneCard(KanbanCard card) => DoneColumn.KanbanCards.Remove(card);
}
