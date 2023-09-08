namespace HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;

/// <summary>
/// <see cref="Account"/> の永続化を実現します
/// </summary>
public sealed class MockAccountRepository : IAccountRepository
{
    /// <summary>
    /// コンストラクター
    /// </summary>
    public MockAccountRepository()
    {
    }

    /// <inheritdoc/>
    public async Task<Account> ReadAsync(Guid id)
    {
        string name = "MockName";
        Account account = new(id, name);

        return await Task.FromResult(account);
    }
}
