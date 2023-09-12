﻿using HigeDaruma.DemoDevidedWpf.AppCore.LiveEventModels;

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
        string name = "test";
        int numberOfMembers = 3;

        Band result = new(name, numberOfMembers);

        Assert.NotNull(result);
        Assert.Equal(name, result.Name);
        Assert.Equal(numberOfMembers, result.NumberOfMembers);
    }
}
