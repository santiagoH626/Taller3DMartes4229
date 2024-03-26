using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Escribe la base del triángulo");
		float _base = float.Parse(Console.ReadLine());

		Console.WriteLine("Escribe la altura del triángulo");
		float _altura = float.Parse(Console.ReadLine());
		
		float _area = (_base * _altura) / 2;
		
		Console.WriteLine("El área del triángulo es: "+ _area);
	}
}