using ExampleGame;

namespace ExampleGame2000UnitTests;

public class SomeGameObjectTests {

    [Fact]
    public void SomeGameObjectIncrement_From0_ShouldBeOne() {
        // ARRANGE
        SomeGameObject obj = new SomeGameObject("Billy", 0, null);
        
        // ACT
        obj.IncrementNumber();

        // ASSERT
        Assert.Equal(1, obj.Number);
    }


    [Fact]
    public void SomeGameObjectChangeName_ToXander_ShouldSucceed() {
        // ARRANGE
        SomeGameObject obj = new SomeGameObject("Billy", 0, null);
        
        // ACT
        obj.ChangeName("Xander");

        // Assert
        Assert.Equal("Xander", obj.Name);
    }
}