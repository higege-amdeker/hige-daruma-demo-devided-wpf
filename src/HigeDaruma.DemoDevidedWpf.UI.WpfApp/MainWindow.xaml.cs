﻿using HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;
using HigeDaruma.DemoDevidedWpf.AppCore.EventNotificationModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IAccountRepository _accountRepository;

    private readonly EventNotificationBuilder _eventNotificationBuilder;

    private readonly DispatcherTimer _visibleTimer = new();

    /// <summary>
    /// コンストラクター
    /// </summary>
    public MainWindow()
    {
        _accountRepository = new MockAccountRepository();
        _eventNotificationBuilder = new EventNotificationBuilder();

        InitializeComponent();

        ContentRendered += async (s, e) => await GetAccount();

        NameTextBox.Text = "test";
        BandNameTextBox.Text = "test";

        // 画面中央に表示
        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        // 非表示で開始
        Visibility = Visibility.Hidden;

        // 起動から一定時間経過後に表示するためのタイマー
        _visibleTimer.Interval = TimeSpan.FromSeconds(5);
        _visibleTimer.Tick += OnVisibleTimer;
        _visibleTimer.Start();
    }

    /// <summary>
    /// アカウント情報を取得します
    /// </summary>
    /// <returns></returns>
    private async Task GetAccount()
    {
        Guid id = new("ffffffff-ffff-ffff-ffff-ffffffffffff");
        Account account = await _accountRepository.ReadAsync(id);

        Id.Text = account.Id.ToString();
        Name.Text = account.Name;
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DateTimeOffset now = DateTimeOffset.Now;

            _eventNotificationBuilder.Start(now);
        }
        catch (Exception ex)
        {
            _eventNotificationBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void SetNameButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string name = NameTextBox.Text;

            _eventNotificationBuilder.SetName(name);
        }
        catch (Exception ex)
        {
            _eventNotificationBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void AddBandNameButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string bandName = BandNameTextBox.Text;

            _eventNotificationBuilder.AddBandName(bandName);
        }
        catch (Exception ex)
        {
            _eventNotificationBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void EndButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DateTimeOffset now = DateTimeOffset.Now;

            _eventNotificationBuilder.End(now);

            EventNotification eventNotification = _eventNotificationBuilder.Build();
            string bandNames = eventNotification.BandNames.Count <= 0
                ? "Empty"
                : eventNotification.BandNames.Aggregate((x, y) => x + "," + y);
            string message =
$@"{eventNotification.StartDateTime}
{eventNotification.EndDateTime}
{eventNotification.Name}
{bandNames}";

            MessageBox.Show(message);

            _eventNotificationBuilder.Clear();
        }
        catch (Exception ex)
        {
            _eventNotificationBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void OnVisibleTimer(object? sender, EventArgs e)
    {
        Visibility = Visibility.Visible;

        _visibleTimer.Stop();
    }
}
