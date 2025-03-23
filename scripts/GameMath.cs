using Godot;
using System;

namespace ExampleGame;

public partial class GameMath
{
	public static int Add(int a, int b) {
		return a + b;
	}

	public static float Divide(float a, float b) {
		return a / b;
	}

	public static int[] AddArrays(int[] a, int[] b) {
		if (a.Length != b.Length) {
			throw new ArgumentException("Arrays must be same length.");
		}

		int[] arr = new int[a.Length];
		for (int i = 0; i < arr.Length; i++) {
			arr[i] = a[i] + b[i];
		}

		return arr;
	}
}
