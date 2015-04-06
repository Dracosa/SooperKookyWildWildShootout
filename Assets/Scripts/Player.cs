using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]private int health = 5;
	[SerializeField]private int damage = 1;
	[SerializeField]private int shots = 6;
	[SerializeField]private bool reloading = false;
	[SerializeField]private bool canShoot = false;
	public GameObject guiUpdater;
	public GameObject guiUpdater2;
	private GUIUpdater updater;
	private GUIUpdater updater2;
	public GameObject Enemy;
	[SerializeField]private Enemy enemyScript;
	void Start()
	{
		guiUpdater = GameObject.Find ("ShotText");
		guiUpdater2 = GameObject.Find ("HealthText");
		Enemy = GameObject.Find ("Enemy");
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
				//enemyScript.health --;
		}
		Crouch ();
	}
	void Shoot()
	{
		if (shots <= 6)
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
			Destroy(GameObject.Find (hit.rigidbody.gameObject.name));
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

}
