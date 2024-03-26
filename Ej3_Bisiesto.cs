using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Escribe el año:");
		int _year = int.Parse(Console.ReadLine());
		
		string _verbo = "es";
		if (_year = 2024){
			_verbo = "es";
		} else if (_year > 2024){
			_verbo = "será";
		} else {
			_verbo = "fue";
		}

		if (_year%4 == 0){
			Console.WriteLine("El año " + _year.ToString() + _verbo " bisiesto.");
		} else {
			Console.WriteLine("El año " + _year.ToString() + " no " + _verbo +" bisiesto.");
		}
	}
}