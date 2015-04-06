using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 1;
	[SerializeField]private Player playerScript;
	private GameObject Enemy2;

	void Start () 
	{
		playerScript = GameObject.Find ("Player").GetComponent<Player>();

		Enemy2 = GameObject.Find ("Enemy2");
	}
	

	void Update () 
	{


		if (health == 0)
		{
			playerScript.kills ++;
			Destroy(this.gameObject);


		}


	}
	void EnemySpawn()
	{
		if (playerScript.kills >= 1) 
		{
			Enemy2.SetActive(true);
		}
	}

}
