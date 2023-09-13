using HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;
using HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IAccountRepository _accountRepository;

    private readonly LiveEventBuilder _liveEventBuilder;

    /// <summary>
    /// コンストラクター
    /// </summary>
    public MainWindow()
    {
        _accountRepository = new MockAccountRepository();
        _liveEventBuilder = new LiveEventBuilder();

        InitializeComponent();

        ContentRendered += async (s, e) => await GetAccount();

        NameTextBox.Text = "test";
        BandNameTextBox.Text = "test";
        NumberOfBandMemberTextBox.Text = "3";

        // 画面中央に表示
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
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

            _liveEventBuilder.Start(now);
        }
        catch (Exception ex)
        {
            _liveEventBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void SetNameButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string name = NameTextBox.Text;

            _liveEventBuilder.SetName(name);
        }
        catch (Exception ex)
        {
            _liveEventBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void AddBandButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string bandName = BandNameTextBox.Text;
            int numberOfBandMember = int.Parse(NumberOfBandMemberTextBox.Text);
            Band band = new(bandName, numberOfBandMember);

            _liveEventBuilder.AddBand(band);
        }
        catch (Exception ex)
        {
            _liveEventBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void EndButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DateTimeOffset now = DateTimeOffset.Now;

            _liveEventBuilder.End(now);

            LiveEvent liveEvent = _liveEventBuilder.Build();
            string bandNames = liveEvent.Bands.Count <= 0
                ? "Empty"
                : liveEvent.Bands.Select(x => x.Name).Aggregate((x, y) => x + "," + y);
            string message =
$@"{liveEvent.StartDateTime}
{liveEvent.EndDateTime}
{liveEvent.Name}
{bandNames}";

            MessageBox.Show(message);

            _liveEventBuilder.Clear();
        }
        catch (Exception ex)
        {
            _liveEventBuilder.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void NumberOfBandMemberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        // 0-9のみ
        e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
    }

    private void NumberOfBandMemberTextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        // 貼り付けを許可しない
        if (e.Command == ApplicationCommands.Paste)
        {
            e.Handled = true;
        }
    }
}
