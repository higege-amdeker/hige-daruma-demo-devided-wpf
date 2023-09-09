using HigeDaruma.DemoDevidedWpf.AppCore.EventNotificationModels;

namespace HigeDaruma.DemoDevidedWpf.AppCore.UnitTest.EventNotificationModels;

/// <summary>
/// <see cref="EventNotificationBuilder"/> の UnitTest です
/// </summary>
public sealed class EventNotificationBuilderTest
{
    // Ctor()

    [Fact]
    public void Ctor_ReturnsOk()
    {
        EventNotificationBuilder result = new();

        Assert.NotNull(result);
    }

    // SetName(string)

    [Fact]
    public void SetName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsNull()
    {
        static void testCode()
        {
            EventNotificationBuilder instance = new();
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
            EventNotificationBuilder instance = new();
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
            EventNotificationBuilder instance = new();
            string name = " ";
            instance.SetName(name);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    // AddBandName(string)

    [Fact]
    public void AddBandName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsNull()
    {
        static void testCode()
        {
            EventNotificationBuilder instance = new();
            string? bandName = null;
            instance.AddBandName(bandName!);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    [Fact]
    public void AddBandName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsEmpty()
    {
        static void testCode()
        {
            EventNotificationBuilder instance = new();
            string bandName = string.Empty;
            instance.AddBandName(bandName);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    [Fact]
    public void AddBandName_ThrowsArgumentException_WhenInstanceIsOkButInputNameIsWhiteSpace()
    {
        static void testCode()
        {
            EventNotificationBuilder instance = new();
            string bandName = " ";
            instance.AddBandName(bandName);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    // Build()

    [Fact]
    public void Build_ReturnsOk_WhenInstanceIsOk()
    {
        EventNotificationBuilder instance = new();
        instance.SetName("test");
        instance.AddBandName("test");

        EventNotification result = instance.Build();

        Assert.NotNull(result);
        Assert.Equal("test", result.Name);
        // TODO: 他のプロパティのテスト
    }

}
