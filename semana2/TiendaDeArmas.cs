using System;
using System.Collections.Generic;
					
public class Program
{
	/*
	 Como mínimo debe haber una espada, un arco, una pistola, una flecha y una bala.
	 El sistema debe funcionar de la siguiente forma:
	 El usuario debe poder seleccionar un arma, indicar el nombre, el daño que causan, la velocidad de 
	ataque y el precio. En caso el arma sea a distancia se debe indicar el proyectil que usa con sus 
	datos.
	 Al seleccionar un arma, esta debe ser agregada a una lista.
	 El usuario debe poder seleccionar si quiere introducir otra arma, si quiere ver todos lo elementos de 
	la lista, eliminar algún elemento de la lista o terminar el programa
	*/
	public static void Main()
	{
		string continuar = "sí";
		
		Projectile flecha = new Projectile("Flecha",1,2, "Arco");
		Projectile bala = new Projectile("Bala",1,2, "Arma de fuego");
		
		List<Item>  tienda = new List<Item>();
		tienda.Add(new Weapon("Espada de entrenamiento",5,3,1));
		tienda.Add(new RangedWeapon("Arco Ligero",10,5,1,flecha));
		tienda.Add(new RangedWeapon("Pistola",10,5,1,bala));
		tienda.Add(flecha);
		tienda.Add(bala);
		
 		string operacion = "";
		
		int tipo;
		string name;
		float price;
		float damage;
		float atspd;
		int detail;
		string balaOflecha;
		string projectileWeaponType;
		
		while(continuar == "sí"){
			Console.WriteLine("Bienvenido a la tienda. Elije una opción: ");
			Console.WriteLine("1. Ver lista de items.");
			Console.WriteLine("2. Crear un ítem.");
			Console.WriteLine("3. Salir.");
			
			operacion = Console.ReadLine();
			
			switch(operacion){
				case "1":
					Console.WriteLine("Mostrando la lista de items:");
					for (int i = 0; i<tienda.Count; i++){
						int pos = 1+i;
						Console.WriteLine(pos +". "+ tienda[i].GetName() + " ($"+ tienda[i].GetPrice() + ")");
					}
					//ver a detalle
					Console.WriteLine("Deseas ver a detalle alguno de los items:");
					detail = int.Parse(Console.ReadLine()) -1;
					if(detail>0 && detail<tienda.Count){
						Console.WriteLine(tienda[detail].GetDetail());
						Console.WriteLine("-------------------------------");
					} else {
						Console.WriteLine("Ese ítem no está disponible:");
					}
				break;

				case "2":
						Console.WriteLine("Escribe el tipo de ítem:");
						Console.WriteLine("1. Arma cuerpo a cuerpo.");
						Console.WriteLine("2. Arma a distancia.");
						Console.WriteLine("3. Proyectil.");
						Console.WriteLine("(próximamente nuevos ítems)");

						tipo = int.Parse(Console.ReadLine());
						if (tipo == 4){

						} else {
						Console.WriteLine("Creando un ítem:");
						Console.WriteLine("Escribe el nombre del nuevo ítem:");
						name = Console.ReadLine();

						Console.WriteLine("Escribe el precio del nuevo ítem:");
						price = float.Parse(Console.ReadLine());

							switch(tipo){
								case 1:
									Console.WriteLine("Escribe el daño del nuevo ítem:");
									damage = float.Parse(Console.ReadLine());
									
									Console.WriteLine("Escribe la velocidad de ataque del nuevo ítem:");
									atspd = float.Parse(Console.ReadLine());
									
									tienda.Add(new Weapon(name,price,damage,atspd));
								break;

								case 2:
									Console.WriteLine("Escribe el daño del nuevo ítem:");
									damage = float.Parse(Console.ReadLine());
									
									Console.WriteLine("Escribe la velocidad de ataque del nuevo ítem:");
									atspd = float.Parse(Console.ReadLine());
									
									Console.WriteLine("Qué proyectil usa el nuevo ítem:");
									Console.WriteLine("1. balas");
									Console.WriteLine("2. flechas");
									balaOflecha = Console.ReadLine();
									if (balaOflecha == "1"){
										tienda.Add(new RangedWeapon(name,price,damage,atspd,bala));
									} else {
										tienda.Add( new RangedWeapon(name,price,damage,atspd,flecha));
									}
								break;

								case 3:
									Console.WriteLine("Escribe el daño del nuevo proyectil:");
									damage = float.Parse(Console.ReadLine());
									
									Console.WriteLine("Con qué tipo de arma funciona el nuevo proyectil:");
									projectileWeaponType = Console.ReadLine();
									
									tienda.Add(new Projectile(name,price,damage,projectileWeaponType));
								break;
							}
						}
					Console.WriteLine("Se ha creado el nuevo item");
				break;
				case "3":
					Console.WriteLine("Hasta pronto");
					continuar = "no";	
				break;
				default:
					Console.WriteLine("Esa operación no está disponible");	
				break;
			}
			if (continuar=="no"){
				Console.WriteLine("Deseas elegir una nueva figura?");
				continuar = Console.ReadLine();
			}
		}
	}
}

public class Item{
	private string name;
	private float price;

	public string GetName(){
		return name;
	}
	public void SetName(string name){
		this.name = name;
	}
	public float GetPrice(){
		return price;
	}
	public void SetPrice(float price){
		this.price = price;
	}
	public virtual string GetDetail(){
		return "";
	}
}
public class Weapon:Item
{
	private float damage;
	private float attackSpeed;
	
	public Weapon()
	{
	}
	public Weapon(string name, float price, float dmg, float attackSpeed){
		SetName(name);
		SetPrice(price);
		this.damage = dmg;
		this.attackSpeed = attackSpeed;
	}
	
	public virtual float GetDPS(){
		return damage/attackSpeed; 
	}
	public float GetDamage(){
		return damage;
	}
	
	public void SetDamage(float damage){
		this.damage = damage;
	}
	public float GetAttackSpeed(){
		return attackSpeed;
	}
	public void SetAttackSpeed(float attackSpeed){
		this.attackSpeed = attackSpeed;
	}

	public override string GetDetail(){
		return "Nombre: "+GetName()+"\nDaño:"+GetDamage().ToString()+
		"\nVelocidad de ataque:"+GetAttackSpeed().ToString()+
		"\nDPS:"+GetDPS().ToString();
	}
}

public class RangedWeapon:Weapon
{
	private Projectile projectile;
	
	public RangedWeapon (string name, float price, float dmg, float attackSpeed, Projectile projectile){
		SetName(name);
		SetPrice(price);
		SetDamage(dmg);
		SetAttackSpeed(attackSpeed);
		this.projectile = projectile;
	}
	
	public Projectile GetProjectile(){
		return projectile;
	}
	public override float GetDPS(){
		return (this.GetDamage() + projectile.GetDamage())/ this.GetAttackSpeed();
	}

	public float GetProjectileDamage(){
		return GetProjectile().GetDamage();
	}

	public override string GetDetail(){
		return "Nombre: "+GetName()+"\nDaño:"+GetDamage().ToString()+
		"\nVelocidad de Ataque:"+GetAttackSpeed().ToString()+
		"\nDaño de proyectil:"+GetProjectileDamage().ToString()+
		"\nDPS:"+GetDPS().ToString();
	}
}

public class Projectile:Item
{
	private float damage;
	private string weaponType;
	public Projectile (string name, float price, float dmg, string weaponType){
		SetName(name);
		SetPrice(price);
		this.damage = dmg;
		this.weaponType = weaponType;
	}
	public float GetDamage(){
		return damage;
	}
	public string GetWeaponType(){
		return weaponType;
	}
	public override string GetDetail(){
		return "Nombre: "+GetName()+"\nDaño:"+GetDamage().ToString()+
		"\nArma compatible: " + GetWeaponType();
	}
	
}