/*An easy version for a Guess The Number game. It features 4 difficulty levels.
Version 1.0
Version 1.5 Adjusted overall difficulty. Added Switch construction in Main method
Versión 1.6 Little tweaks to the code. Changed the number range for difficulty 3.
Created by OuterGazer*/

using System;

class GuessTheNumber
{
	static int intNumber;
	static string inputString;
	static int difficultyLevel;
	static void ProgramEnd()
	{
		Console.WriteLine("\nPress Enter to exit to Windows.");
		Console.ReadLine();
	}
	static void CatchParseException(string inputNumber)
	{
		try
		{
			intNumber = int.Parse(inputNumber);
			inputString = null;
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	static void ReadInt(string prompt, int min, int max)
	{
		do
		{
			do
			{
				Console.WriteLine(prompt);
				inputString = Console.ReadLine();
				CatchParseException(inputString);

			} while (inputString != null);

			if ((intNumber < min) || (intNumber > max))
			{
				Console.WriteLine("The number is invalid.\nWrite a number between " +
					min + " and " + max + ".");
			}
			else
				break;
		} while (true);
	}
	static void GuessNumber(int minRange, int maxRange, int Turnnumber)
	{
		int chosenNumber;
		int writtenNumber;

		Console.WriteLine("You have chosen the difficulty level number " + difficultyLevel + ". Now I will think" +
			" a number between " + minRange + " and " + maxRange + ".\nYou have a maximum of " + Turnnumber + " attempts" +
			" to guess it.");

		Random rnd = new Random();
		chosenNumber = rnd.Next(minRange, (maxRange + 1));

		int i;
		for (i = 0; i < Turnnumber; i++)
		{
			if (i == (Turnnumber - 1))
			{
				Console.WriteLine();
				Console.WriteLine("This is your last attempt.");
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("This is the attempt number {0}.", (i + 1));
			}

			ReadInt("Choose a number between " + minRange + " and " + maxRange + ".", minRange, maxRange);
			writtenNumber = intNumber;

			if (writtenNumber == chosenNumber)
			{
				Console.WriteLine("\nCongratulations! You have correctly guessed the number. It was the " + chosenNumber + ".");
				break;
			}
			if (writtenNumber < chosenNumber)
			{
				Console.WriteLine("\nIncorrect. The solution is a higher number.");
			}
			if (writtenNumber > chosenNumber)
			{
				Console.WriteLine("\nIncorrect. The solution is a lower number.");
			}
		}
		if (i == Turnnumber)
		{
			Console.WriteLine("\nUnfortunately you no attempts left. The number I had" +
				" thought was the " + chosenNumber + "." + "\n¡Better luck next time!");
		}
	}
	static void Main()
	{
		string repeatGame = null;

		do
		{
			Console.Clear();
			Console.WriteLine("¡Welcome to \"Guess The Number\"!\n" +
				"\nThis is a straightforward game where I think a number and you try to guess it within " +
				"the allowed number of attempts." +
				"\n\nThe different difficulty levels are as follows:");
			Console.WriteLine("1. Easy\t\tThe range is from 0 to 10\t\tYou ave 4 tries\n2. Medium" +
				"\tThe range is from 0 to 100\t\tYou have 6 tries\n3. Hard\t\t" +
				"The range goes from -100 to 100\t\tYou have 8 tries\n4. Very hard" +
				"\tThe range goes from 0 to 1000\t\tYou have 10 tries");

			ReadInt("\nChoose your desired difficulty level:", 1, 4);
			difficultyLevel = intNumber;
			Console.Clear();

			switch (difficultyLevel)
			{
				case (1):
					GuessNumber(0, 10, 4);
					break;
				case (2):
					GuessNumber(0, 100, 6);
					break;
				case (3):
					GuessNumber(-100, 100, 8);
					break;
				case (4):
					GuessNumber(0, 1000, 10);
					break;
				default:
					continue;
			}

			do
			{
				Console.Write("\nDo you wish to play again? (S/N) ");
				repeatGame = Console.ReadLine().Trim().ToUpper();
				if ((repeatGame != "S") && (repeatGame != "N"))
				{
					Console.WriteLine("Please, write exclusively S/N");
				}
				else
					break;
			} while (true);

		} while (repeatGame == "S");

		ProgramEnd();
	}
}