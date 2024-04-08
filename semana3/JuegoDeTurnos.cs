using System;

public class Program
{

	public static void Main()
	{
		Game game = new Game();
		
		game.GameState();
	}
	
}

public class Game{

	private bool playGame = true;
	private int score = 0;
	private Player player;
	private bool playerTurn = true;
	
	private int enemiesAmount = 10;
	private Enemy[] enemies;
	private int enemyTurnIndex;
	
	public void GameState(){
		Console.WriteLine("Iniciando juego...");
		FillEnemesArray();
		player = CreatePlayer();
		
		while (playGame){
			TurnManager();
			playGame = player.IsAlive() && (EnemiesLeft()>0);
			Console.WriteLine("Tu salud es: " + player.GetHealth() );
			Console.WriteLine("---------------------------------------------------------------------------------------------------");
		}
		if (player.IsAlive()){
			WinGame();
		} else {
			LoseGame();
		}
		
	}
	private void TurnManager(){
		if (playerTurn){
			PlayerTurn();
		} else {
			EnemyTurn();
		}
		playerTurn = !playerTurn;
	}
	
	private void PlayerTurn(){
		bool correctTarget = false;
		while(!correctTarget){
			Console.WriteLine("Es tu turno, elige tu objetivo:");
			for (int i = 0; i<enemies.Length; i++){
				if (enemies[i].IsAlive()){
					Console.WriteLine(i.ToString() + ". "+enemies[i].GetName()+" "+i.ToString()+", salud restante: " +enemies[i].GetHealth()+ ", daño: " + enemies[i].GetDamage());
				}
			}
			int target = int.Parse( Console.ReadLine() );
			if ((target<0)||(target>=enemies.Length)){
				Console.WriteLine("Atacaste al aire y no le diste a nadie.");
			} else {
				Enemy enemy = enemies[target];
				if (enemy.IsAlive()){
					correctTarget = true;
					Console.WriteLine("Atacaste al enemigo "+target.ToString()+"!!!");
					Combat(player,enemy);
				} else {
					Console.WriteLine("Ese enemigo ya está muerto.");
				}
			}
		}
	}
	private void EnemyTurn(){
		AdvanceEnemyTurnIndex();
		Console.WriteLine("Es el turno del enemigo "+ enemyTurnIndex.ToString());
		Enemy enemy = enemies[ enemyTurnIndex ];
		Combat(enemy,player);
	}
	private void AdvanceEnemyTurnIndex(){
		bool turnEnemyIsAlive = false;
		while (!turnEnemyIsAlive){
			enemyTurnIndex++;
			if (enemyTurnIndex>=enemies.Length){
				enemyTurnIndex = 0;
			}
			turnEnemyIsAlive = enemies[enemyTurnIndex].IsAlive();
		}
	}
	private void Combat(Creature att, Creature def){
		if (att.GetName()=="RangedEnemy"){
			RangedEnemy r = (RangedEnemy)att;
			if (r.GetAmmo()>0){
				def.TakeDamage(att.GetDamage());
				Console.WriteLine(att.GetName()+" atacó a "+def.GetName()+". "+def.GetName()+" recibió "+att.GetDamage()+" de daño.");
			}else{
				r.SkipTurn();
			}
		} else {
			def.TakeDamage(att.GetDamage());
			Console.WriteLine(att.GetName()+" atacó a "+def.GetName()+". "+def.GetName()+" recibió "+att.GetDamage()+" de daño.");
		}
	}
	private int EnemiesLeft(){
		int enemiesLeft = 0;
		for (int i = 0; i<enemies.Length; i++){
			if (enemies[i].IsAlive()){
				enemiesLeft++;
			}
		}
		Console.WriteLine("Aún quedan "+enemiesLeft.ToString()+" enemigos");
		return enemiesLeft;
	}

	private Player CreatePlayer(){
		Console.WriteLine("Creación de personaje");
		bool todoCorrecto = false;
		float _health = -1;
		float _damage = -1;
		while(!todoCorrecto){
			Console.WriteLine("Indica la salud de tu personaje (max. 100)");
			_health = float.Parse(Console.ReadLine());
			todoCorrecto = ((_health>0) && (_health<=100));
			if (!todoCorrecto){
				Console.WriteLine("Error al asignar salud");
			}
		}
		todoCorrecto = false;
		while(!todoCorrecto){
			Console.WriteLine("Indica el daño de tu personaje (max. 100)");
			_damage = float.Parse(Console.ReadLine());
			todoCorrecto = ((_damage>0) && (_damage<=100));
			if (!todoCorrecto){
				Console.WriteLine("Error al asignar daño");
			}
		}

		Console.WriteLine("Personaje creado exitosamente.");
		Player _player = new Player(_health,_damage);
		return _player;
	}
	private void FillEnemesArray(){
		enemies = new Enemy[enemiesAmount];
		for (int i = 0; i<enemies.Length; i++){
			if (i>(enemiesAmount/2)&&(i%2==0)){
				enemies[i] = new RangedEnemy(50,20);
			} else {
				enemies[i] = new Enemy(150,5);
			}
		}
	}
	private void WinGame(){
		Console.WriteLine("Has ganado!");
	}
	private void LoseGame(){
		Console.WriteLine("Has perdido!");
	}
}


public class Player : Creature{
	public Player (float health, float damage) : base (health,damage){
		this.SetName("Player");
	}
}

public class Enemy : Creature{
	public Enemy (float health, float damage) : base (health,damage){
		this.SetName("Enemy");
	}
}

public class RangedEnemy : Enemy{
	private int ammo {get; 	set;}
	public RangedEnemy (float health, float damage) : base (health,damage){
		this.SetName("RangedEnemy");
		this.ammo = 3;
	}
	public int GetAmmo(){
		return ammo;
	}
	public void SkipTurn(){
		Console.WriteLine("¡El enemigo pierde un turno! ¡No tiene munición!");
	}
	
}

public class Creature{
	private string name{get; set;}
	private float health{get; set;}
	private float damage{get; set;}
	
	public Creature(float health, float damage){
		this.health = health;
		this.damage = damage;
	}
	public float GetHealth(){
		return health;
	}
	public bool IsAlive(){
		return health>0;
	}
	public float GetDamage(){
		return damage;
	}
	public void TakeDamage(float dmg){
		health-=dmg;
	}
	public void SetName(string name){
		this.name = name;
	}
	public string GetName(){
		return name;
	}
}
