using Microsoft.Win32;
using MiniKanbanBoard.DTOs;
using MiniKanbanBoard.Entities;
using MiniKanbanBoard.Enums;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace MiniKanbanBoard.Models;

public class HostWindowModel
{
    private string CurrentFile = string.Empty; // string.Empty == not saved yet; otherwise contains full path to file

    public HostWindowModel()
    {

    }

    public void FileNew()
    {
        CurrentFile = string.Empty;
    }

    public FileOpenResponse FileOpen()
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "JSON|*.json";

        bool? dialogResponse = dialog.ShowDialog();
        if (dialogResponse == false)
        {
            return new FileOpenResponse(false, new(), new(), new());
        }

        try
        {
            string jsonString = File.ReadAllText(dialog.FileName);
            var template = JsonSerializer.Deserialize<SerializationTemplate>(jsonString);
            if (template != null)
            {
                CurrentFile = dialog.FileName;
                return new FileOpenResponse(true, template.ToDoColumn, template.DoingColumn, template.DoneColumn);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Couldn't read file", "Error", MessageBoxButton.OK);
        }

        return new FileOpenResponse(false, new(), new(), new());
    }
    
    public FileSaveResponse FileSave(SaveBoardRequest request)
    {
        var template = new SerializationTemplate(request.ToDoColumn, request.DoingColumn, request.DoneColumn);
        string serializedData = JsonSerializer.Serialize(template);

        if (request.RequestType == SaveRequestType.Save)
        {
            if (CurrentFile != string.Empty)
            {
                File.WriteAllText(CurrentFile, serializedData);
                return new FileSaveResponse(true);
            }
        }

        var dialog = new SaveFileDialog();
        dialog.Filter = "JSON|*.json";

        bool? dialogResponse = dialog.ShowDialog();
        if (dialogResponse == false)
        {
            return new FileSaveResponse(false);
        }

        File.WriteAllText(dialog.FileName, serializedData);
        CurrentFile = dialog.FileName;
        return new FileSaveResponse(true);
    }
}
