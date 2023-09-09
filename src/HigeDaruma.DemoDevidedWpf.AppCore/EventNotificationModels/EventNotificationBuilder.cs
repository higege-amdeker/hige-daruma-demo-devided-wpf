namespace HigeDaruma.DemoDevidedWpf.AppCore.EventNotificationModels;

/// <summary>
/// <see cref="EventNotification"/> の構築ロジックを提供します
/// </summary>
public sealed class EventNotificationBuilder
{
    private readonly DateTimeOffset _startDateTime;
    private DateTimeOffset _endDateTime;
    private string? _name;
    private readonly List<string> _bandNames = new();

    /// <summary>
    /// コンストラクター
    /// </summary>
    public EventNotificationBuilder()
    {
        _startDateTime = DateTimeOffset.Now;
    }

    /// <summary>
    /// 通知の名前を設定します
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("null, Empty, white space ではいけません。", nameof(name));

        _name = name;
    }

    /// <summary>
    /// イベントの参加バンド名を追加します
    /// </summary>
    /// <param name="bandName"></param>
    /// <exception cref="ArgumentException"></exception>
    public void AddBandName(string bandName)
    {
        if (string.IsNullOrWhiteSpace(bandName))
            throw new ArgumentException("null, Empty, white space ではいけません。", nameof(bandName));

        _bandNames.Add(bandName);
    }

    /// <summary>
    /// <see cref="EventNotification"/> を構築します
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public EventNotification Build()
    {
        if (_name is null)
            throw new InvalidOperationException($"{nameof(_name)} が設定されていません。");

        _endDateTime = DateTimeOffset.Now;

        EventNotification notification = new(
            _startDateTime,
            _endDateTime,
            _name,
            _bandNames);

        return notification;
    }
}
