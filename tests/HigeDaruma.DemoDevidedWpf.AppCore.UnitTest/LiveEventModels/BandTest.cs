using HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

namespace HigeDaruma.DemoDevidedWpf.AppCore.UnitTest.LiveEventModels;

/// <summary>
/// <see cref="Band"/> の UnitTest です
/// </summary>
public sealed class BandTest
{
    // Ctor()

    [Fact]
    public void Ctor_ReturnsOk()
    {
        Band result = new();

        Assert.NotNull(result);
    }
}
