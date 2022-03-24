using System;

class Point{
	public float X {get; set;}
	public float Y {get; set;}
	
	public Point(){
		X = 0;
		Y = 0;
	}
	
	public Point(float x, float y){
		X = x;
		Y = y;
	}
}

class PointTest{
	static void Main(string[] args){
		Point origin = new Point();
		Console.WriteLine($"Origin is at ({origin.X},{origin.Y}).");
		
		Point point1 = new Point(2,3);
		Console.WriteLine($"Point1 is at ({point1.X},{point1.Y}).");
		
		Point point2 = new Point(-4,0);
		Console.WriteLine($"Point2 is at ({point2.X},{point2.Y}).");
	}
}