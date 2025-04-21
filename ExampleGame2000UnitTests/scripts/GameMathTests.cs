using ExampleGame;
using Godot;

namespace ExampleGame2000UnitTests;

public class GameMathTests {
    
    [Fact]
    public void GameMathAdd_2And2_ShouldReturn4() {
        Assert.Equal(4, GameMath.Add(2, 2));
    }

    [Fact]
    public void GameMathDivide_4By2_ShouldReturn2() {
        Assert.Equal(2, GameMath.Divide(4, 2));
    }

    [Fact]
    public void GameMathDivide_1By3_ShouldReturn0pt333333() {
        Assert.Equal(0.33f, GameMath.Divide(1, 3), 0.01f);
    }

    [Fact]
    public void GameMathDivide_2By0_ShouldReturnSomething() {
        Assert.Equal(Mathf.Inf, GameMath.Divide(2, 0));
    }

    [Fact]
    public void GameMathAddArrays_DifferentSizes_ShouldThrowException() {
        Assert.Throws<ArgumentException>(() => {
            GameMath.AddArrays([1], [2,2]);
        });
    }

    [Fact]
    public void GameMathAddArrays_11Plus22_ShouldReturn33() {
        Assert.Equal([3,3], GameMath.AddArrays([1,1],[2,2]));
    }
}