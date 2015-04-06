using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]private int health = 5;
	[SerializeField]private int damage = 1;
	[SerializeField]private int shots = 6;
					public int kills = 0;
	[SerializeField]private bool reloading = false;
	[SerializeField]private bool canShoot = false;
	public GameObject guiUpdater;
	public GameObject guiUpdater2;
	private GUIUpdater updater;
	private GUIUpdater updater2;
	public GameObject Enemy;
	[SerializeField]private Enemy enemyScript;
	private GameObject Enemy2;
	private GameObject Enemy3;


	void Start()
	{
		Enemy2 = GameObject.Find ("Enemy2");
		Enemy3 = GameObject.Find ("Enemy3");
		Enemy2.SetActive (false);
		Enemy3.SetActive (false);
		guiUpdater = GameObject.Find ("ShotText");
		guiUpdater2 = GameObject.Find ("HealthText");
		Enemy = GameObject.Find ("Enemy");

		enemyScript = Enemy.GetComponent<Enemy> ();

		updater = guiUpdater.GetComponentInParent<GUIUpdater> ();
		updater2 = guiUpdater2.GetComponentInParent<GUIUpdater> ();
	}
	void Update()
	{
		

		if (Input.GetKeyDown (KeyCode.R))
		{
			Reloading ();
		}

		if (Input.GetMouseButtonDown (0)) 
		{

				Shoot ();
				Shooting();
				
		}
		Crouch ();
		EnemyCount ();
	}
	void Shoot()
	{
		if (shots >= 1)
		{
			canShoot = true;
			print ("shooting");
			shots--;
			updater.UpdateShot (shots);

		}
		else if(shots <= 0)
		{
			canShoot = false;
			//Reloading();
		}
	}
	void Shooting()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast (ray, out hit))
		{
			Debug.DrawRay(ray.origin, hit.point);
			//enemyScript.health --;
			Destroy(GameObject.Find (hit.rigidbody.gameObject.name));
			kills ++;
		}
	}
	void Reloading()
	{
		reloading = true;

		shots = 6;
		updater.UpdateShot (shots);
		reloading = false;



	}
	void Crouch()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			this.transform.localScale = new Vector3 (0.5f, 0.25f, 0.5f);
		} 
		else if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			this.transform.localScale = new Vector3 (0.5f, .5f, 0.5f);
		}
	}
	void EnemyCount()
	{
		if (kills == 1) 
		{
			Enemy2.SetActive(true);
		}
		if (kills == 2)
		{
			Enemy3.SetActive(true);
		}
	}

}
