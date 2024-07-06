using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniKanbanBoard.Entities;
using MiniKanbanBoard.Models;
using System.Diagnostics;
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
        // TODO Load Columns from Model
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
        };
    }

    [RelayCommand]
    private void AddToDoCard() => AddCard(TodoColumn);

    [RelayCommand]
    private void AddDoingCard() => AddCard(DoingColumn);

    [RelayCommand]
    private void AddDoneCard() => AddCard(DoneColumn);

    private void AddCard(KanbanColumn kanbanColumn)
    {
        var newCard = new KanbanCard
        {
            Name = "Card Name",
            Content = "Card Content"
        };
        if (kanbanColumn.KanbanCards.Count > 0)
        {
            newCard.HeaderColor = kanbanColumn.KanbanCards[^1].HeaderColor;
            newCard.ContentColor = kanbanColumn.KanbanCards[^1].ContentColor;
            kanbanColumn.KanbanCards.Add(newCard);
            return;
        }
        var r = new Random();
        newCard.HeaderColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
        newCard.ContentColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
        kanbanColumn.KanbanCards.Add(newCard);
    }

    [RelayCommand]
    private void RemoveTodoCard(KanbanCard card) => RemoveCard(TodoColumn, card);

    [RelayCommand]
    private void RemoveDoingCard(KanbanCard card) => RemoveCard(DoingColumn, card);

    [RelayCommand]
    private void RemoveDoneCard(KanbanCard card) => RemoveCard(DoneColumn, card);

    private void RemoveCard(KanbanColumn kanbanColumn, KanbanCard card)
    {
        kanbanColumn.KanbanCards.Remove(card);
    }

    // Menu commands
    [RelayCommand]
    private void FileNew()
    {
        Debug.WriteLine("FileNew");
    }

    [RelayCommand]
    private void FileOpen()
    {
        Debug.WriteLine("FileOpen");
    }

    [RelayCommand]
    private void FileSave()
    {
        // Save + Save As (decided in model)
        Debug.WriteLine("FileSave");
    }
}
