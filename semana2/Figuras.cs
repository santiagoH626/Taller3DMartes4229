using System;
					
public class Program
{
	public static void Main()
	{
		string continuar = "sí";
		
		float arg1 = 0;
		float arg2 = 0;
		float area = 0;
		
		Shape figura;
		
		string fig = "";
		
		while(continuar == "sí"){
			Console.WriteLine("Elige qué figura quieres operar: ");
			fig = Console.ReadLine();
			switch(fig){
				case "círculo":
					Console.WriteLine("Escribe el radio del círculo:");
					arg1 = float.Parse(Console.ReadLine());
					figura = new Circle(arg1);
					area = figura.GetArea();
					Console.WriteLine("El área del " + fig + " es " + area.ToString() );
				break;
					
				case "triángulo":
					Console.WriteLine("Escribe la base del triángulo:");
					arg1 = float.Parse(Console.ReadLine());
					
					Console.WriteLine("Escribe la altura del triángulo:");
					arg2 = float.Parse(Console.ReadLine());
					
					figura = new Triangle(arg1,arg2);
					area = figura.GetArea();
					Console.WriteLine("El área del " + fig + " es " + area.ToString() );
				break;
					
				case "rectángulo":
					Console.WriteLine("Escribe la base del triángulo: rectángulo:");
					arg1 = float.Parse(Console.ReadLine());
					
					Console.WriteLine("Escribe la altura del rectángulo:");
					arg2 = float.Parse(Console.ReadLine());
					
					figura = new Rectangle(arg1,arg2);
					area = figura.GetArea();
					Console.WriteLine("El área del " + fig + " es " + area.ToString() );
				break;
				default:
					Console.WriteLine("Esa figura no está disponible");	
				break;
			}
			Console.WriteLine("Deseas elegir una nueva figura?");
			continuar = Console.ReadLine();
			
		}
	}
}

public class Shape{
	public virtual float GetArea(){
		return 0;
	}
}

public class Rectangle:Shape{
	private float w;
	private float h;
	
	public Rectangle (float w, float h){
		this.w = w;
		this.h = h;
	}
	public override float GetArea(){
		return w*h;
	}
}

public class Circle:Shape{
	private float r;
	
	public Circle(float r){
		this.r = r;
	}
	
	public override float GetArea(){
		return r * r * 3.14f;
	}
}

public class Triangle:Shape{
	private float b;
	private float h;
	
	public Triangle(float b, float h){
		this.b = b;
		this.h = h;
	}
	
	public override float GetArea(){
		return (b*h)/2;
	}
}