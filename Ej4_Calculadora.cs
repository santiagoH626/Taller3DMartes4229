using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Bienvenidx a \"Calculadora\"");
		string continuar = "sí";
		float arg1 = 0;
		float arg2 = 0;
		float resultado = 0;
		string op = "";
		while(continuar == "sí" || continuar == "repetir"){
			if (continuar == "repetir"){
				arg1 = resultado;
			} else {
				Console.WriteLine("Escribe dos números y luego la operación que quieres realizar.");
				arg1 = float.Parse(Console.ReadLine());
				Console.WriteLine("Escribe un número más:");
				arg2 = float.Parse(Console.ReadLine());

				Console.WriteLine("Ahora indica la operación a realizar: ( + , - , / , * )");
				op = Console.ReadLine();
			}
			switch (op){
				case "+":
					resultado = arg1 + arg2;
					Console.WriteLine("La suma de " + arg1.ToString() + " y " + arg2.ToString() + " es: " + resultado.ToString() );
				break;

				case "-":
					resultado = arg1 - arg2;
					Console.WriteLine("La diferencia entre " + arg1.ToString() + " y " + arg2.ToString() + " es: " + resultado.ToString() );
				break;

				case "/":
					resultado = arg1 / arg2;
					Console.WriteLine("El cociente de " + arg1.ToString() + " entre " + arg2.ToString() + " es: " + resultado.ToString() );
				break;

				case "*":
					resultado = arg1 * arg2;
					Console.WriteLine("El producto de " + arg1.ToString() + " por " + arg2.ToString() + " es: " + resultado.ToString() );
				break;

				default:
					Console.WriteLine("Esa operación no está disponible");
				break;
			}
			Console.WriteLine("¿Deseas realizar otra operación? (sí/no/repetir)");
			continuar = Console.ReadLine();
		}
		Console.WriteLine("Gracias por usar \"Calculadora\".");
	}
}