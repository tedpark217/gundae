using System;

class Color{
	public float R;
	public float G;
	public float B;
	
	public static Color white {get;} = new Color(255,255,255);
	public static Color black {get;} = new Color(0,0,0);
	public static Color red {get;} = new Color(255,0,0);
	public static Color orange {get;} = new Color(255,165,0);
	public static Color yellow {get;} = new Color(255,255,0);
	public static Color green {get;} = new Color(0,128,0);
	public static Color blue {get;} = new Color(0,0,255);
	public static Color purple {get;} = new Color(128,0,128);
	
	public Color(){
		R = 0;
		G = 0;
		B = 0;
	}
	
	public Color(float red, float green, float blue){
		R = red;
		G = green;
		B = blue;
	}
	
	public Color((float red, float green, float blue) rgb){
		R = rgb.red;
		G = rgb.green;
		B = rgb.blue;
	}
}

class ColorTest{
	static void Main(string[] args){
		Color black = new Color();
		Console.WriteLine($"Black is ({black.R},{black.G},{black.B}).");
		
		Color black2 = Color.black;
		Console.WriteLine($"Black is ({black2.R},{black2.G},{black2.B}).");
		
		Color purple = Color.purple;
		Console.WriteLine($"Purple is ({purple.R},{purple.G},{purple.B}).");
	}
}