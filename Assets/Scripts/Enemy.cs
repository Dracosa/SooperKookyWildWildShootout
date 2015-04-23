using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 1;

	[SerializeField]private Player playerScript;
	[SerializeField]private GameObject bullet;
	[SerializeField]private GameObject bulletSpawn;
	[SerializeField]private  int WaitTime = 5;
	[SerializeField]private bool canShoot = true;
	[SerializeField]private GUIUpdater updater;

	public GameObject guiUpdater;


	void Start () 
	{
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();

		guiUpdater = GameObject.Find ("KillsText");
		updater = guiUpdater.GetComponentInParent<GUIUpdater> ();
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
		GameObject muzzle = Instantiate (Resources.Load ("GunMuzzle")) as GameObject;
		muzzle.transform.position = bulletSpawn.transform.position;
		Destroy (muzzle, 1);
		canShoot = false;
		yield return new WaitForSeconds (WaitTime);
		canShoot = true;
	}
	void OnMouseDown()
	{
		if (Player.canReload == false)
		{
			health --;
		
			if (health == 0) 
			{
				playerScript.kills ++;
				Destroy (this.gameObject);
				updater.UpdateKills (playerScript.kills);
			
			
			}

		}
	}
}
