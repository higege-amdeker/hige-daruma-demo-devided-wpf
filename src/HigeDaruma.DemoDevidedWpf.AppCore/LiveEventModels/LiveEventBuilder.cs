﻿namespace HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

/// <summary>
/// <see cref="LiveEvent"/> の構築ロジックを提供します
/// </summary>
public sealed class LiveEventBuilder
{
    // 一時的に保持しておくパラメーター
    private DateTimeOffset _startDateTime = DateTimeOffset.MinValue;
    private DateTimeOffset _endDateTime = DateTimeOffset.MinValue;
    private string? _name;
    private readonly List<Band> _bands = new();

    /// <summary>
    /// コンストラクター
    /// </summary>
    public LiveEventBuilder()
    {
    }

    /// <summary>
    /// 開始日を設定します
    /// </summary>
    /// <param name="start"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public void Start(DateTimeOffset start)
    {
        if (start == DateTimeOffset.MinValue)
            throw new ArgumentOutOfRangeException(nameof(start), "最小値は設定できません。");

        if (_startDateTime != DateTimeOffset.MinValue)
            throw new InvalidOperationException("開始日は既に設定されています。");

        _startDateTime = start;
    }

    /// <summary>
    /// 終了日を設定します
    /// </summary>
    /// <param name="end"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public void End(DateTimeOffset end)
    {
        if (end == DateTimeOffset.MinValue)
            throw new ArgumentOutOfRangeException(nameof(end), "最小値は設定できません。");

        if (_endDateTime != DateTimeOffset.MinValue)
            throw new InvalidOperationException("終了日は既に設定されています。");

        _endDateTime = end;
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
    /// <param name="band"></param>
    /// <exception cref="ArgumentException"></exception>
    public void AddBand(Band band)
    {
        if (band is null)
            throw new ArgumentNullException(nameof(band));

        _bands.Add(band);
    }

    /// <summary>
    /// <see cref="LiveEvent"/> を構築します
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public LiveEvent Build()
    {
        if (_startDateTime == DateTimeOffset.MinValue)
            throw new InvalidOperationException($"{nameof(_startDateTime)} が設定されていません。");

        if (_endDateTime == DateTimeOffset.MinValue)
            throw new InvalidOperationException($"{nameof(_endDateTime)} が設定されていません。");

        if (_name is null)
            throw new InvalidOperationException($"{nameof(_name)} が設定されていません。");

        LiveEvent liveEvent = new(
            _startDateTime,
            _endDateTime,
            _name,
            _bands);

        return liveEvent;
    }

    /// <summary>
    /// 現在の <see cref="LiveEvent"/> インスタンスからすべての要素を削除します
    /// </summary>
    public void Clear()
    {
        _startDateTime = DateTimeOffset.MinValue;
        _endDateTime = DateTimeOffset.MinValue;
        _name = null;
        _bands.Clear();
    }
}
