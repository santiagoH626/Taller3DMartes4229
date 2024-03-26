using System;
					
public class Program
{
	public static void Main()
	{
		string r0 = "sí";
		while (r0 == "sí"){
		Console.WriteLine("¿Qué figura quieres crear? (círculo, triángulo, rectángulo)");
		
		string r1 = Console.ReadLine();
		string r2 = "";
		
		float arg1 = 0;
		float arg2 = 0;
		
		switch (r1){
			case "círculo":
				
				Console.WriteLine("Escribe el radio del círculo:");
				arg1 = float.Parse(Console.ReadLine());

				Console.WriteLine("¿Qué cálculo quisieras realizar? (área, perímetro)");
				r1 = Console.ReadLine();
				if (r1=="área"){
					double areaCirculo = Math.PI * arg1 * arg1;
					Console.WriteLine("El área del círculo es: "+ areaCirculo.ToString() );
				} else if (r1=="perímetro"){
					double perimetroCirculo = Math.PI * arg1 * 2;
					Console.WriteLine("El perímetro del círculo es: "+ perimetroCirculo.ToString() );
				} else {
					Console.WriteLine("Esa operación no está disponible.");
				}
				
				break;
				
			case "triángulo":
				Console.WriteLine("Escribe la base del triángulo:");
				arg1 = float.Parse(Console.ReadLine());
				
				Console.WriteLine("Escribe la altura del triángulo:");
				arg2 = float.Parse(Console.ReadLine());
				
				Console.WriteLine("¿Qué cálculo quisieras realizar? (área)");
				r1 = Console.ReadLine();
				if (r1=="área"){
					double areaTriangulo = (arg1 * arg1)/2 ;
					Console.WriteLine("El área del triángulo es: "+ areaTriangulo.ToString() );
				} else {
					Console.WriteLine("Esa operación no está disponible.");
				}
				break;
				
			case "rectángulo":
				Console.WriteLine("Escribe la base del rectángulo:");
				arg1 = float.Parse(Console.ReadLine());
				
				Console.WriteLine("Escribe la altura del rectángulo:");
				arg2 = float.Parse(Console.ReadLine());
				
				Console.WriteLine("¿Qué cálculo quisieras realizar? (área, perímetro)");
				r1 = Console.ReadLine();
				if (r1=="área"){
					double areaRectangulo = arg1 * arg2;
					Console.WriteLine("El área del círculo es: "+ areaRectangulo.ToString() );
				} else if (r1=="perímetro"){
					double perimetroRectangulo = (arg1 + arg2) * 2;
					Console.WriteLine("El perímetro del círculo es: "+ perimetroRectangulo.ToString() );
				} else {
					Console.WriteLine("Esa operación no está disponible.");
				}
				
				break;
			default:
				Console.WriteLine("Esa figura no está disponible.");
				break;
		}
		Console.WriteLine("¿Quieres realizar otra operación? (sí/no)");
		r0 = Console.ReadLine();
		}
	}
}