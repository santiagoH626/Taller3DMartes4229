using System;
					
public class Program
{
	public static void Main()
	{
		string r0 = "sí";
		while (r0 == "sí"){
		Console.WriteLine("¿Qué figura quieres crear? (círculo, triángulo, rectángulo)");
		
		string r1 = Console.ReadLine();
		
		float arg1 = 0;
		float arg2 = 0;
		
		switch (r1){
			case "círculo":
				
				Console.WriteLine("Introduce el radio del círculo:");
				arg1 = float.Parse(Console.ReadLine());
				
				Circle c = new Circle(arg1);

				Console.WriteLine("El área del círculo es: "+ c.GetArea().ToString());
				
				break;
				
			case "triángulo":
				Console.WriteLine("Introduce la base del triángulo:");
				arg1 = float.Parse(Console.ReadLine());
				
				Console.WriteLine("Introduce la altura del triángulo:");
				arg2 = float.Parse(Console.ReadLine());
				
				Triangle t = new Triangle(arg1,arg2);
				Console.WriteLine("El área del triángulo es: "+ t.GetArea().ToString());
				break;
				
			case "rectángulo":
				Console.WriteLine("Introduce la base del rectángulo:");
				arg1 = float.Parse(Console.ReadLine());
				
				Console.WriteLine("Introduce la altura del rectángulo:");
				arg2 = float.Parse(Console.ReadLine());
				
				Rectangle r = new Rectangle(arg1,arg2);
				Console.WriteLine("El área del rectángulo es: "+ r.GetArea().ToString());
				
				break;
		}
		Console.WriteLine("¿Quieres crear otra figura? (sí/no)");
		r0 = Console.ReadLine();
		}
		Console.WriteLine("¡Gracias por usar este programa!");
	}
}

public class Rectangle{
	public float width;
	public float height;
	
	public Rectangle(float _width, float _height){
		width = _width;
		height = _height;
	}
	
	public float GetArea(){
		return width * height;
	}
}

public class Circle{
	public float radius;
	
	public Circle( float _radius){
		radius = _radius;
	}
	
	public double GetArea(){
		return Math.PI * radius * radius;
	}
}

public class Triangle{
	public float width;
	public float height;
	
	public Triangle( float _base, float _height){
		width = _base;
		height = _height;
	}
	
	public float GetArea(){
		return (width*height)/2;
	}
}