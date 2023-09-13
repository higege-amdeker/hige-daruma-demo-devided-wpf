using System.Collections.ObjectModel;

namespace HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

/// <summary>
/// ライブイベントを表現する DomainObject です
/// </summary>
public sealed class LiveEvent
{
    /// <summary>
    /// イベントの開始日時
    /// </summary>
    public DateTimeOffset StartDateTime { get; }

    /// <summary>
    /// イベントの終了日時
    /// </summary>
    public DateTimeOffset EndDateTime { get; }

    /// <summary>
    /// イベントの名前
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// イベントに参加するバンド名の一覧の実態
    /// </summary>
    private readonly List<Band> _bands;

    /// <summary>
    /// コンストラクター
    /// </summary>
    /// <param name="startDateTime"></param>
    /// <param name="endDateTime"></param>
    /// <param name="name"></param>
    /// <param name="bands"></param>
    internal LiveEvent(
        DateTimeOffset startDateTime,
        DateTimeOffset endDateTime,
        string name,
        List<Band> bands)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Name = name;
        _bands = bands;
    }

    /// <summary>
    /// ライブイベントに参加するバンド名の一覧の公開用プロパティ
    /// </summary>
    public ReadOnlyCollection<Band> Bands => _bands.AsReadOnly();
}
