using System;

class Program {
	public static void Main() {
		while (true) {
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.Clear();

			Console.CursorTop = Console.WindowHeight - 1;
			Console.BackgroundColor = ConsoleColor.Gray;
			ClearLine();

			Console.CursorTop = 0;
			Console.CursorLeft = 0;

			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.ForegroundColor = ConsoleColor.White;
			
			Console.WriteLine(" BMI Calculator");
			Console.WriteLine("================");
			Console.WriteLine();
			
			// gereftan ghad va vazn az vorodi
			var h = GetDoubleFromInput("height (m)");
			var w = GetDoubleFromInput("weight (kg)");
			Console.WriteLine();

			// mohasebeye BMI tebghe formul dade shode
			var result = w / (h*h);

			// chap BMI dar khoroji
			Console.WriteLine($"BMI: {result}");
			Console.WriteLine();

			// namayesh vaziat jesmi karbar dar khoroji ba rang monaseb
			if (result < 18.5) { // kambod vazn
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("You are underweight");
			}
			else if (result < 25) { // vazn adi
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("You are normal");
			}
			else if (result < 30) { // ezafe vazn
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("You are overweight");
			}
			else { // chagh
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You are FAT!");
			}

			Console.ResetColor();

			// agar karbar khast, barname yek bar diger hm ejra shavad
			if (!AskAgain())
				return; // agar nakhast az barname kharej shavad
		}
	}

	// gereftan yek double az vorodi, ba label delkhah
	public static double GetDoubleFromInput(string name) {
		var line = Console.CursorTop;
		var defaultColor = Console.ForegroundColor;
		while (true) {
			Console.Write($"Enter {name}: ");
			Console.ForegroundColor = ConsoleColor.Gray;
			var input = Console.ReadLine();
			Console.ForegroundColor = defaultColor;
			Console.WriteLine();
			try {
				return Convert.ToDouble(input);
			}
			catch (FormatException) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid input, try again!");
				Console.ForegroundColor = defaultColor;
				Console.CursorTop = line;
				ClearLine();
			}
		}
	}

	// az karbar miporsad ke aya mikhahad baz hm barname ejra shavad ya kheir
	public static bool AskAgain() {
		Console.CursorTop = Console.WindowHeight - 1;
		Console.CursorLeft = 0;
		Console.BackgroundColor = ConsoleColor.Gray;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Write("Press [1] to calculate again, Press [0] to exit...");
		Console.ResetColor();
		while (true) {
			var c = Console.ReadKey(true);
			if (c.KeyChar == '1') // agar karbar 1 ra feshar dad baz hm barname ejra shavad
				return true;
			if (c.KeyChar == '0') // agar karbar 0 ra feshar dad barname baste shaved
				return false;
		}
	}

	public static void ClearLine() {
		Console.CursorLeft = 0;
		for (var i = 0; i < Console.WindowWidth - 1; i++) {
			Console.Write(" ");
		}
		Console.CursorLeft = 0;
	}
}
