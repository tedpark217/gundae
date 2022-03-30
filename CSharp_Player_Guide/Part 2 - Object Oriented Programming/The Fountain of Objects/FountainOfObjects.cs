using System;

class GameManager{
	
}

class World{
		
}

class Player{
	public string Name {get; set;}
	
}

//to keep track of positions
public struct Position{
	public int Row {get; set;}
	public int Col {get; set;}
	
	public Position(){
		Row = 0;
		Col = 0;
	}
	
	public Position(int newRow, int newCol){
		Row = newRow;
		Col = newCol;
	}
}

//direction of movement
enum Direction {North, South, East, West}