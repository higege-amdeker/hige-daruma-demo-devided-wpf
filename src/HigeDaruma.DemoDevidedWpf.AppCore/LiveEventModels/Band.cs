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
        Name = name;
        NumberOfMembers = numberOfMembers;
    }
}
