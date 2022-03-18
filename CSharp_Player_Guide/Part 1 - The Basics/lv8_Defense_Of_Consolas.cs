using System;

class lv8_Defense_Of_Consolas{
    static void Main(string[] args){
        int row;
		int col;
		
		Console.Write("Target Row? ");
		row = Convert.ToInt32(Console.ReadLine());
		Console.Write("Target Column? ");
		col = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Deploy to: ");
		
		Console.WriteLine($"({row}, {col-1})");
		Console.WriteLine($"({row-1}, {col})");
		Console.WriteLine($"({row}, {col+1})");
		Console.WriteLine($"({row+1}, {col})");

		Console.Title = "Defense of Consolas";
		Console.Beep();
    }
}