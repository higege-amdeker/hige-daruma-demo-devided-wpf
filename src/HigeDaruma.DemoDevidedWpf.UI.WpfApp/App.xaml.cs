using HigeDaruma.DemoDevidedWpf.UI.WpfApp.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        DispatcherUnhandledException += OnDispatcherUnhandledException;

        //AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Exception ex = e.Exception;

        // TODO: エラーログの作成・通知・アプリケーションの終了などの処理を追加します
        StringBuilder sb = new();
        sb.AppendLine(ex.Message);
        sb.AppendLine("---");
        sb.AppendLine(ex.StackTrace);
        string messageBoxText = sb.ToString();
        string title = "Exception!";

        ExceptionDialog.ShowDialog(messageBoxText, title);

        // アプリケーションを終了
        Environment.Exit(1);
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Exception ex = (Exception)e.ExceptionObject;

        // TODO: エラーログの作成・通知・アプリケーションの終了などの処理を追加します
        StringBuilder sb = new();
        sb.AppendLine(ex.Message);
        sb.AppendLine("---");
        sb.AppendLine(ex.StackTrace);
        string messageBoxText = sb.ToString();
        string title = "Exception!";

        ExceptionDialog.ShowDialog(messageBoxText, title);

        //bool shouldExit = true;
        //if (e.IsTerminating)
        //{
        //    shouldExit = true;
        //}

        //if (shouldExit)
        //{
        //    // 0 以外の値を設定することで異常終了を示す
        //    Environment.Exit(1);
        //}
    }
}
