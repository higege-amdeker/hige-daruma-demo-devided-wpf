namespace HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;

/// <summary>
/// <see cref="Account"/> の永続化インターフェイス
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// ID を指定して <see cref="Account"/> を読みだします
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Account> ReadAsync(Guid id);
}
