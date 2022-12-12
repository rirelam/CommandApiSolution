
using CommandApi.Models;

namespace CommandAPI.Tests;

public class CommandTests : IDisposable
{
    readonly Command testCommand;
    private bool disposed = false;
    public CommandTests()
    {
        testCommand = new Command
        {
            HowTo = "Do something awesome",
            Platform = "xUnit",
            CommandLine = "dotnet test"
        };
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Check to see if Dispose has already been called.
        if (!this.disposed)
        {
            disposed = true;
        }
    }

    [Fact]
    public void CanChangeHowTo()
    {
        //Act
        testCommand.HowTo = "Execute Unit Tests";
        //Assert
        Assert.Equal("Execute Unit Tests", testCommand.HowTo);
    }

    [Fact]
    public void CanChangePlatform()
    {
        //Act
        testCommand.Platform = "MSTest";
        //Assert
        Assert.Equal("MSTest", testCommand.Platform);

    }

    [Fact]
    public void CanChangeCommandLine()
    {
        //Act
        testCommand.CommandLine = "MSTest";
        //Assert
        Assert.Equal("MSTest", testCommand.CommandLine);

    }
}
