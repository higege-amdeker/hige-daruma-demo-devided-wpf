using HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

namespace HigeDaruma.DemoDevidedWpf.AppCore.UnitTest.LiveEventModels;

/// <summary>
/// <see cref="LiveEventBuilder"/> の UnitTest です
/// </summary>
public sealed class LiveEventBuilderTest
{
    // Ctor()

    [Fact]
    public void Ctor_ReturnsOk()
    {
        LiveEventBuilder result = new();

        Assert.NotNull(result);
    }

    // Start(DateTimeOffset)

    [Fact]
    public void Start_ThrowsArgumentOutOfRangeException_WhenInputStartIsMinValue()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            DateTimeOffset start = DateTimeOffset.MinValue;
            instance.Start(start);
        }

        Assert.Throws<ArgumentOutOfRangeException>(testCode);
    }

    [Fact]
    public void Start_ThrowsInvalidOperationException_WhenInputStartIsOkButInstanceIsAlreadySetStart()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            DateTimeOffset start = new(2023, 9, 9, 12, 0, 0, new TimeSpan(0));
            instance.Start(start);
            instance.Start(start);
        }

        Assert.Throws<InvalidOperationException>(testCode);
    }

    // End(DateTimeOffset)

    [Fact]
    public void End_ThrowsArgumentOutOfRangeException_WhenInputEndIsMinValue()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            DateTimeOffset end = DateTimeOffset.MinValue;
            instance.End(end);
        }

        Assert.Throws<ArgumentOutOfRangeException>(testCode);
    }

    [Fact]
    public void End_ThrowsInvalidOperationException_WhenInputStartIsOkButInstanceIsAlreadySetStart()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            DateTimeOffset end = new(2023, 9, 9, 12, 0, 0, new TimeSpan(0));
            instance.End(end);
            instance.End(end);
        }

        Assert.Throws<InvalidOperationException>(testCode);
    }

    // SetName(string)

    [Fact]
    public void SetName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsNull()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            string? name = null;
            instance.SetName(name!);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    [Fact]
    public void SetName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsEmpty()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            string name = string.Empty;
            instance.SetName(name);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    [Fact]
    public void SetName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsWhiteSpace()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            string name = " ";
            instance.SetName(name);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    // AddBand(string)

    [Fact]
    public void AddBand_ThrowsArgumentException_WhenInstanceIsOkButInputBandIsNull()
    {
        static void testCode()
        {
            LiveEventBuilder instance = new();
            Band? band = null;
            instance.AddBand(band!);
        }

        Assert.Throws<ArgumentNullException>(testCode);
    }

    // Build()

    [Fact]
    public void Build_ReturnsOk_WhenInstanceIsOk()
    {
        DateTimeOffset start = new(2023, 9, 9, 12, 0, 0, new TimeSpan(0));
        DateTimeOffset end = new(2023, 9, 10, 12, 0, 0, new TimeSpan(0));
        string name = "test";
        Band band = new("test", 3);
        LiveEventBuilder instance = new();
        instance.Start(start);
        instance.End(end);
        instance.SetName(name);
        instance.AddBand(band);

        LiveEvent result = instance.Build();

        Assert.NotNull(result);
        Assert.Equal(start, result.StartDateTime);
        Assert.Equal(end, result.EndDateTime);
        Assert.Equal(name, result.Name);
        Assert.Equal(band, result.Bands.First());
    }

    [Fact]
    public void Build_InvalidOperationException_WhenInstanceHasNotSetStartDateTime()
    {
        static void testCode()
        {
            DateTimeOffset end = new(2023, 9, 10, 12, 0, 0, new TimeSpan(0));
            string name = "test";
            Band band = new("test", 3);
            LiveEventBuilder instance = new();
            instance.End(end);
            instance.SetName(name);
            instance.AddBand(band);

            LiveEvent result = instance.Build();
        }

        Assert.Throws<InvalidOperationException>(testCode);
    }

    [Fact]
    public void Build_InvalidOperationException_WhenInstanceHasNotSetEndDateTime()
    {
        static void testCode()
        {
            DateTimeOffset start = new(2023, 9, 9, 12, 0, 0, new TimeSpan(0));
            string name = "test";
            Band band = new("test", 3);
            LiveEventBuilder instance = new();
            instance.Start(start);
            instance.SetName(name);
            instance.AddBand(band);

            LiveEvent result = instance.Build();
        }

        Assert.Throws<InvalidOperationException>(testCode);
    }

    [Fact]
    public void Build_InvalidOperationException_WhenInstanceHasNotSetName()
    {
        static void testCode()
        {
            DateTimeOffset start = new(2023, 9, 9, 12, 0, 0, new TimeSpan(0));
            DateTimeOffset end = new(2023, 9, 10, 12, 0, 0, new TimeSpan(0));
            Band band = new("test", 3);
            LiveEventBuilder instance = new();
            instance.Start(start);
            instance.End(end);
            instance.AddBand(band);

            LiveEvent result = instance.Build();
        }

        Assert.Throws<InvalidOperationException>(testCode);
    }

    // Clear()

    [Fact]
    public void Clear_OperationIsOk_WhenInstanceIsOk()
    {
        static void testCode()
        {
            DateTimeOffset start = new(2023, 9, 9, 12, 0, 0, new TimeSpan(0));
            DateTimeOffset end = new(2023, 9, 10, 12, 0, 0, new TimeSpan(0));
            string name = "test";
            Band band = new("test", 3);
            LiveEventBuilder instance = new();
            instance.Start(start);
            instance.End(end);
            instance.SetName(name);
            instance.AddBand(band);

            instance.Clear();

            LiveEvent result = instance.Build();
        }

        Assert.Throws<InvalidOperationException>(testCode);
    }

}
