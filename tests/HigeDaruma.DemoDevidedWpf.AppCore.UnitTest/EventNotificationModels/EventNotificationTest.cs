using HigeDaruma.DemoDevidedWpf.AppCore.EventNotificationModels;

namespace HigeDaruma.DemoDevidedWpf.AppCore.UnitTest.EventNotificationModels;

/// <summary>
/// <see cref="EventNotification"/> の UnitTest です
/// </summary>
public sealed class EventNotificationTest
{
    // Ctor()

    [Fact]
    public void Ctor_ReturnsOk_WhenInputIsOk()
    {
        DateTimeOffset startDateTime = DateTimeOffset.Now;
        DateTimeOffset endDateTime = startDateTime.AddDays(1);
        string name = "Live 2023";
        List<string> bandNames = new()
        {
            "test",
            "FixedCycles",
        };

        EventNotification result = new(startDateTime, endDateTime, name, bandNames);

        Assert.NotNull(result);
        Assert.Equal(startDateTime, result.StartDateTime);
        Assert.Equal(endDateTime, result.EndDateTime);
        Assert.Equal(name, result.Name);
        Assert.Equal(bandNames, result.BandNames);
    }
}
