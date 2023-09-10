using HigeDaruma.DemoDevidedWpf.AppCore.AccountModels;

namespace HigeDaruma.DemoDevidedWpf.AppCore.UnitTest.AccountModels;

/// <summary>
/// <see cref="Account"/> の UnitTest です
/// </summary>
public sealed class AccountTest
{
    // Ctor(Guid, string)

    [Fact]
    public void Ctor_ReturnsOk_WhenInputIdIsOkAndInputNameIsOk()
    {
        Guid id = new("ffffffff-ffff-ffff-ffff-ffffffffffff");
        string name = "HigeDaruma";

        Account result = new(id, name);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public void Ctor_ThrowsArgumentException_WhenInputNameIsOkButInputIdIsEmpty()
    {
        static void testCode()
        {
            Guid id = Guid.Empty;
            string name = "HigeDaruma";

            Account result = new(id, name);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    [Fact]
    public void Ctor_ThrowsArgumentException_WhenInputIdIsOkButInputNameIsEmpty()
    {
        static void testCode()
        {
            Guid id = new("ffffffff-ffff-ffff-ffff-ffffffffffff");
            string name = string.Empty;

            Account result = new(id, name);
        }

        Assert.Throws<ArgumentException>(testCode);
    }

    [Fact]
    public void Ctor_ThrowsArgumentException_WhenInputIdIsOkButInputNameIsWhiteSpace()
    {
        static void testCode()
        {
            Guid id = new("ffffffff-ffff-ffff-ffff-ffffffffffff");
            string name = " ";

            Account result = new(id, name);
        }

        Assert.Throws<ArgumentException>(testCode);
    }
}
