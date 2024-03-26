using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Escribe la base del rectángulo");
		float _base = float.Parse(Console.ReadLine());

		Console.WriteLine("Escribe la altura del rectángulo");
		float _altura = float.Parse(Console.ReadLine());
		
		float _area = _base * _altura;
		float _perimetro = (_base + _altura) * 2;
		
		Console.WriteLine("El área del rectángulo es: "+ _area + "y su perímetro es: " + _perimetro);
	}
}