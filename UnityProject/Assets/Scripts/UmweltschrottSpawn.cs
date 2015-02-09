using UnityEngine;
using System.Collections;

public class UmweltschrottSpawn : MonoBehaviour
{
	public float spawnTime = 15f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public Rigidbody2D[] enemies;		// Array of enemy prefabs.
	public float spawndirectionX = 6F; 
	public float spawndirectionY = -5F; 
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, Random.Range(10F, 25F));
	}
	
	//Random.Range(-10.0F, 10.0F)
	void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		Rigidbody2D enemieInstance;
		enemieInstance = Instantiate (enemies [enemyIndex], transform.position, transform.rotation) as Rigidbody2D;
		enemieInstance.AddForce(new Vector2(Random.Range(spawndirectionX - 4F,spawndirectionX + 4F), Random.Range(spawndirectionY - 4F, spawndirectionY + 4F)) * Random.Range(80, 160));
		enemieInstance.AddTorque (50.0F);

	}
}
