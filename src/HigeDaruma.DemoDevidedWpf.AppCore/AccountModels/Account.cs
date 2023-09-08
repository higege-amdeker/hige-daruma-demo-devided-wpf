namespace HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;

/// <summary>
/// アカウントを表現する DomainObject です
/// </summary>
public sealed class Account
{
    /// <summary>
    /// ID
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// 名前
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// コンストラクター
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <exception cref="ArgumentException"></exception>
    public Account(Guid id, string name)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Guid.Empty ではいけません。", nameof(id));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("null, string.Empty, white space ではいけません。", nameof(name));

        Id = id;
        Name = name;
    }
}
