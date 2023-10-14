using System;
using System.Windows;

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Exception ex = (Exception)e.ExceptionObject;

        // TODO: エラーログの作成・通知・アプリケーションの終了などの処理を追加します
        MessageBox.Show(ex.Message);

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
