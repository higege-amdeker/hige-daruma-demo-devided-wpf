using System.Collections.ObjectModel;

namespace HigeDaruma.DemoDevidedWpf.AppCore.EventNotificationModels;

/// <summary>
/// イベント通知を表現する DomainObject です
/// </summary>
public sealed class EventNotification
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
    private readonly List<string> _bandNames;

    /// <summary>
    /// コンストラクター
    /// </summary>
    /// <param name="startDateTime"></param>
    /// <param name="endDateTime"></param>
    /// <param name="name"></param>
    /// <param name="bandNames"></param>
    internal EventNotification(
        DateTimeOffset startDateTime,
        DateTimeOffset endDateTime,
        string name,
        List<string> bandNames)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Name = name;
        _bandNames = bandNames;
    }

    /// <summary>
    /// イベントに参加するバンド名の一覧の公開用プロパティ
    /// </summary>
    public ReadOnlyCollection<string> BandNames => _bandNames.AsReadOnly();
}
