using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniKanbanBoard.DTOs;
using MiniKanbanBoard.Entities;
using MiniKanbanBoard.Enums;
using MiniKanbanBoard.Models;
using System.Windows;
using System.Windows.Media;

namespace MiniKanbanBoard.ViewModels;

public partial class HostWindowViewModel : ObservableObject
{
    private readonly HostWindowModel _model;

    [ObservableProperty]
    public KanbanColumn todoColumn;

    [ObservableProperty]
    public KanbanColumn doingColumn;

    [ObservableProperty]
    public KanbanColumn doneColumn;

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
            HeaderColor = Colors.Aquamarine,
            ContentColor = Colors.Bisque,
        };
        DoingColumn = new KanbanColumn
        {
            Name = "Doing",
            KanbanCards = [],
            HeaderColor = Colors.LightBlue,
            ContentColor = Colors.Pink,
        };
        DoneColumn = new KanbanColumn
        {
            Name = "Done",
            KanbanCards = [],
            HeaderColor = Colors.IndianRed,
            ContentColor = Colors.CadetBlue,
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
        newCard.HeaderColor = new Color
        {
            R = (byte)r.Next(0, 255),
            G = (byte)r.Next(0, 255),
            B = (byte)r.Next(0, 255),
            ScA = 1.0f
        };
        newCard.ContentColor = new Color
        {
            R = (byte)r.Next(0, 255),
            G = (byte)r.Next(0, 255),
            B = (byte)r.Next(0, 255),
            ScA = 1.0f
        };
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
        var userResponse = MessageBox.Show("Save board?", "New", MessageBoxButton.YesNoCancel);
        if (userResponse == MessageBoxResult.Cancel)
        {
            return;
        }
        if (userResponse == MessageBoxResult.Yes)
        {
            var saveResponse = Save(SaveRequestType.Save);
            if (!saveResponse.Success)
            {
                return;
            }
        }

        _model.FileNew();
        TodoColumn.KanbanCards.Clear();
        DoingColumn.KanbanCards.Clear();
        DoneColumn.KanbanCards.Clear();
    }

    [RelayCommand]
    private void FileOpen()
    {
        var userResponse = MessageBox.Show("Save board?", "Open", MessageBoxButton.YesNoCancel);
        if (userResponse == MessageBoxResult.Cancel)
        {
            return;
        }
        if (userResponse == MessageBoxResult.Yes)
        {
            var saveResponse = Save(SaveRequestType.Save);
            if (!saveResponse.Success)
            {
                return;
            }
        }

        var response = _model.FileOpen();
        if (response.IsSuccess)
        {
            TodoColumn = response.ToDoColumn;
            DoingColumn = response.DoingColumn;
            DoneColumn = response.DoneColumn;
        }
    }

    [RelayCommand]
    private void FileSave()
    {
        Save(SaveRequestType.Save);
    }

    [RelayCommand]
    private void FileSaveAs()
    {
        Save(SaveRequestType.SaveAs);
    }

    private FileSaveResponse Save(SaveRequestType saveRequestType)
    {
        var request = new SaveBoardRequest(saveRequestType, TodoColumn, DoingColumn, DoneColumn);
        var response = _model.FileSave(request);
        return response;
    }

}
