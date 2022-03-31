using System;

public abstract class RobotCommand{
	public abstract void Run(Robot robot);
}

public class Robot{
	public int X {get; set;}
	public int Y {get; set;}
	public bool IsPowered {get; set;}
	public RobotCommand[] Commands {get;} = new RobotCommand[3];
	public void Run(){
		foreach (RobotCommand command in Commands){
			command.Run(this);
			Console.WriteLine($"[{X} {Y} {IsPowered}]");
		}
	}
}

class Test{
	public static void Main(string[] args){
		
	}
}