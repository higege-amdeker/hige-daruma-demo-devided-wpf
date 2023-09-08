using HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace HigeDaruma.DemoDevidedWpf.UI.WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IAccountRepository _accountRepository;

    public MainWindow()
    {
        _accountRepository = new MockAccountRepository();

        InitializeComponent();

        ContentRendered += async (s, e) => await GetAccount();
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
}
