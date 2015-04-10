using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 1;
	[SerializeField]private Player playerScript;
	[SerializeField]private GameObject bullet;
	[SerializeField]private GameObject bulletSpawn;
	[SerializeField]private  int WaitTime = 5;
	[SerializeField]private bool canShoot = true;

	void Start () 
	{
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();


	}

	void Update () 
	{

		if (canShoot == true) 
		{
			Shoot ();
		}

	}
	private void Shoot()
	{
		StartCoroutine (Shooting ());

	}
	IEnumerator Shooting()
	{
		Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
		canShoot = false;
		yield return new WaitForSeconds (WaitTime);
		canShoot = true;
	}
	void OnMouseDown()
	{
		
		health --;
		
		if (health == 0)
		{
			playerScript.kills ++;
			Destroy(this.gameObject);
			
			
		}

	}
}
