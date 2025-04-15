namespace ExampleGame2000UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(true);
        Assert.Equal(3, ExampleGame.GameMath.Add(1, 2));
    }
}