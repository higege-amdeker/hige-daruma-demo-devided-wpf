using HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

namespace HigeDaruma.DemoDevidedWpf.AppCore.UnitTest.LiveEventModels;

/// <summary>
/// <see cref="LiveEvent"/> の UnitTest です
/// </summary>
public sealed class LiveEventTest
{
    // Ctor()

    [Fact]
    public void Ctor_ReturnsOk_WhenInputIsOk()
    {
        DateTimeOffset startDateTime = DateTimeOffset.Now;
        DateTimeOffset endDateTime = startDateTime.AddDays(1);
        string name = "Live 2023";
        List<Band> bands = new()
        {
            new Band("test", 3),
            new Band("FixedCycles", 2),
        };

        LiveEvent result = new(startDateTime, endDateTime, name, bands);

        Assert.NotNull(result);
        Assert.Equal(startDateTime, result.StartDateTime);
        Assert.Equal(endDateTime, result.EndDateTime);
        Assert.Equal(name, result.Name);
        Assert.Equal(bands, result.Bands);
    }
}
