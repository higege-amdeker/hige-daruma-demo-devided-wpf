using System.Windows;
using System.Windows.Controls;

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp.Models;

internal static class ExceptionDialog
{
    public static void ShowDialog(string message, string title)
    {
        Window dialog = new()
        {
            Title = title,
            Content = new TextBox()
            {
                Text = message,
                Margin = new Thickness(10),
                IsReadOnly = true,
            },
        };

        dialog.ShowDialog();
    }
}
