using System;

class Puzzle{
	public string[][] _puzzle;
	private static string[][] finishedPuzzle = new string[][]{
		new string[] {" 1"," 2"," 3"," 4"},
		new string[] {" 5"," 6"," 7"," 8"}, 
		new string[] {" 9","10","11","12"},
		new string[] {"13","14","15","  "}
	};
	
	public Puzzle(){
		_puzzle = new string[][]{
			new string[4],
			new string[4],
			new string[4],
			new string[4]
		};
	}
	
	public Puzzle(string[][] newPuzzle){
		_puzzle = newPuzzle;
	}
	
	public void Display(){
		Console.WriteLine(" 1 |  2 |  3 |  4");
		Console.WriteLine("----------------------");
		Console.WriteLine($"1 | {_puzzle[0][0]} | {_puzzle[0][1]} | {_puzzle[0][2]} | {_puzzle[0][3]}");
		Console.WriteLine("----------------------");
		Console.WriteLine($"2 | {_puzzle[1][0]} | {_puzzle[1][1]} | {_puzzle[1][2]} | {_puzzle[1][3]}");
		Console.WriteLine("----------------------");
		Console.WriteLine($"3 | {_puzzle[2][0]} | {_puzzle[2][1]} | {_puzzle[2][2]} | {_puzzle[2][3]}");
		Console.WriteLine("----------------------");
		Console.WriteLine($"4 | {_puzzle[3][0]} | {_puzzle[3][1]} | {_puzzle[3][2]} | {_puzzle[3][3]}");
		Console.WriteLine("----------------------");
	}
	
	public bool canMoveRow(int rowNum){
		bool check = false;
		
		for(int i = 0; i < _puzzle[rowNum].Length; i++){
			if(_puzzle[rowNum][i] == "  "){
				check = true;
			}
		}
		return check;
	}
	
	public bool canMoveCol(int colNum){
		bool check = false;
		
		for(int i = 0; i < _puzzle.Length; i++){
			if(_puzzle[i][colNum] == "  "){
				check = true;
			}
		}
		return check;
	}
	
	//parameter: row number (1-4), string (right R or left L)
	public void moveRow(int num, string RL){
		//check if empty tile is in the row
		bool movePossible = canMoveRow(num-1);
		
		//move the given row to right
		if(movePossible && RL == "R"){
			int emptyIdx = Array.IndexOf(_puzzle[num-1],"  ");
			for(int i = emptyIdx; i > 0; i--){
				_puzzle[num-1][i] = _puzzle[num-1][i-1];
			}
			_puzzle[num-1][0] = "  ";
		}
		//move the given row to left
		if(movePossible && RL == "L"){
			int emptyIdx = Array.IndexOf(_puzzle[num-1],"  ");
			for(int i = emptyIdx; i < _puzzle[num-1].Length-1; i++){
				_puzzle[num-1][i] = _puzzle[num-1][i+1];
			}
			_puzzle[num-1][3] = "  ";
		}
	}
	
	public void moveCol(){
		
	}
	
	public bool checkWin(){
		bool check = true;
		
		for(int i = 0; i < _puzzle.Length; i++){
			for(int j = 0; j < _puzzle[0].Length; j++){
				if(_puzzle[i][j] != finishedPuzzle[i][j]){
					check = false;
				}
			}
		}
		
		return check;
	}
}


class PuzzleGame{
	public Puzzle _newPuzzle;
	
	public PuzzleGame(Puzzle newPuzzle){
		_newPuzzle = newPuzzle;
	}
	
	public void AskMovement(){
		Console.Write("where to move?: ");
	}
}

class PuzzleTest{
	static void Main(string[] args){
		
		string[][] newGame = new string[][]{
			new string[] {" 1"," 3","10","13"}, 
			new string[] {" 6"," 4"," 2","12"}, 
			new string[] {"11"," 8"," 7","  "}, 
			new string[] {" 9","14"," 5","15"}
		};
		
		Puzzle puz15 = new Puzzle(newGame);
		puz15.Display();
		
		puz15.moveRow(2,"L");
		puz15.Display();
		
		/*
		puz15.moveRow(2,"L");
		puz15.Display();*/
	}
}