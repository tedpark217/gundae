using System;

class Testing{
	static void Main(string[] args){
		int[,] test = new int[4,4] {{1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,0}};
		
		int[][] testing = new int[][]{
			new int[] {1,2,3,4},
			new int[] {5,6,7,8}, 
			new int[] {9,10,11,12},
			new int[] {13,14,15,0}
		};
		
		/*
		Console.WriteLine(testing[0].Length);
		//Console.WriteLine(testing.GetLength(1));
		
		//Console.WriteLine(testing[0].Length);
		for(int i = 0; i < testing[0].Length; i++){
			Console.WriteLine(testing[2][i]);
		}*/
		
		int[][] empty = new int[][]{
			new int[4],
			new int[4],
			new int[4],
			new int[4]
		};
		for(int i = 0; i < empty[0].Length; i++){
			Console.WriteLine(empty[2,i]);
		}
	}
}