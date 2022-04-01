using System;

class GamePlay{
	public static void Main(string[] args){
		GameManager newGame = new GameManager();
		newGame.Run();
	}
}

class GameManager{
	public World GameWorld {get;}
	public Player GamePlayer {get;}
	public bool FountainOnOff {get; set;}
	private ISense[] _senses;
	
	public GameManager(World newWorld, Player newPlayer){
		GameWorld = newWorld;
		GamePlayer = newPlayer;
		
		_senses = new ISense[]{
			new EntranceSense(),
			new FountainSense()
		};
	}
	
	public void DisplayStatus(){
		Console.WriteLine("-------------------");
		Console.WriteLine($"You are in room at (Row={GamePlayer.Position.Row}, Column={GamePlayer.Position.Col}).");
		foreach(ISense sense in _senses){
			if(sense.CanSense(this)){
				sense.DisplaySense(this);
			}
		}
	}
	
	public void Run(){
		while(!HasWon){
			DisplayStatus();
		}
	}
	
	
}

class World{
	private RoomType[][] _grid;
	public int Rows {get;}
	public int Cols {get;}
	
	public World(int rows, int cols){
		Rows = rows;
		Cols = cols;
		_grid = new RoomType[][]{};
	}
	
	public RoomType GetCurrentRoom(Position currPosition){
		if(onMap(currPosition)){
			return _grid[currPosition.Row][currPosition.Col];
		}
	}
	
	public bool onMap(Position currPosition){
		if(Position.Row >= 0 && Position.Row < Rows && Position.Col >= 0 && Position.Col < Cols){
			return true;
		}
		else{
			return false;
		}
	}
}

//player within the game
class Player{
	// current position
	public Position CurrPosition {get; set;}
	
	public Player(Position startPos){
		CurrPosition = startPos;
	}
}

//interface for commands in the game
public interface ICommand{
	void Execute(GameManager game);
}

//command to move the player
public class MoveCommand : ICommand{
	//get direction to move
	public Direction DirToMove {get;}
	
	//constructor to move command
	public MoveCommand(Direction newDirection){
		DirToMove = newDirection;
	}
	
	void Execute(GameManager game){
		Position current = game.GamePlayer.Position;
		Position newPosition = new Position();
		
		switch (DirToMove){
			case Direction.North:
				newPosition = new Position(current.Row - 1, current.Col);
				break;
			case Direction.South:
				newPosition = new Position(current.Row + 1, current.Col);
				break;
			case Direction.West:
				newPosition = new Position(current.Row, current.Col - 1);
				break;
			case Direction.East:
				newPosition = new Position(current.Row, current.Col + 1);
				break;	
		}
		
		if(game.World.IsOnMap(newPosition)){
			game.Player.CurrPosition = newPosition;
		}
		else{
			Console.WriteLine("can't move there");
		}
	}
}

//command to enable the fountain
public class EnableFountainCommand : ICommand{
	void Execute(GameManager game){
		RoomType currentRoom = game.GetCurrentRoom();
		if(currentRoom == RoomType.Fountain){
			game.FountainOnOff = true;
		}
		else{
			Console.WriteLine("not at fountain");
		}
	}
}

//interface to different senses
public interface ISense{
	bool CanSense(GameManager game);
	
	void DisplaySense(GameManager game);
}

//sense when in entrance
public class EntranceSense : ISense{
	bool CanSense(GameManager game){
		if(game.World.GetCurrentRoom(game.GamePlayer.Position) == RoomType.Entrance){
			return true;
		}
		else{
			return false;
		}
	}
	
	void DisplaySense(GameManager game){
		Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
	}
}

//sense when in fountain
public class FountainSense : ISense{
	bool CanSense(GameManager game){
		if(game.World.GetCurrentRoom(game.GamePlayer.Position) == RoomType.Fountain){
			return true;
		}
		else{
			return false;
		}
	}
	
	void DisplaySense(GameManager game){
		if(!FountainOnOff){
			Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
		}
		else{
			Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
		}
	}
}

//to keep track of positions
public record Position(int Row, int Col);

//direction of movement
enum Direction {North, South, East, West}
enum RoomType {Empty, Fountain, Entrance}