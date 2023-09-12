namespace HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

/// <summary>
/// バンドを表現する DomainObject です
/// </summary>
public sealed class Band
{
    /// <summary>
    /// バンド名
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// メンバーの人数
    /// </summary>
    public int NumberOfMembers { get; }

    /// <summary>
    /// コンストラクター
    /// </summary>
    /// <param name="name"></param>
    /// <param name="numberOfMembers"></param>
    public Band(string name, int numberOfMembers)
    {
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Empty, White space ではいけません。", nameof(name));

        if (numberOfMembers <= 0)
            throw new ArgumentOutOfRangeException(nameof(numberOfMembers));

        Name = name;
        NumberOfMembers = numberOfMembers;
    }
}
