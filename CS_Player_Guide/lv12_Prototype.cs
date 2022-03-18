using System;

class lv12_Prototype{
    static void Main(string[] args)
    {
		//ask user 1
		int input;
		
		do{
			Console.Write("User 1, enter a number between 0 and 100: ");
			input = Convert.ToInt32(Console.ReadLine());
		}
		while(input < 0 || input > 100);

		Console.Clear();	
		
		//ask user 2
		int guess;
		Console.Write("User 2, guess the number. ");
		guess = Convert.ToInt32(Console.ReadLine());
		
		while(guess != input){
			if(guess > input){
				Console.WriteLine($"{guess} is too high.");
			}
			else{
				Console.WriteLine($"{guess} is too low.");
			}
			
			Console.Write("What is your next guess? ");
			guess = Convert.ToInt32(Console.ReadLine());
		}
		
		Console.WriteLine("You guessed the number!");
    }
}