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
	private GameObject Enemy4;
	private GameObject Enemy5;
	private GameObject Enemy6;
	private GameObject Enemy7;
	private GameObject Enemy8;
	private GameObject Enemy9;
	private GameObject Enemy10;
	private GameObject Enemy11;
	private Animator Anim = null;

	void Start()
	{
		Enemy2 = GameObject.Find ("Enemy2");
		Enemy3 = GameObject.Find ("Enemy3");
		Enemy4 = GameObject.Find ("Enemy4");
		Enemy5 = GameObject.Find ("Enemy5");
		Enemy6 = GameObject.Find ("Enemy6");
		Enemy7 = GameObject.Find ("Enemy7");
		Enemy8 = GameObject.Find ("Enemy8");
		Enemy9 = GameObject.Find ("Enemy9");
		Enemy10 = GameObject.Find ("Enemy10");
		Enemy11 = GameObject.Find ("Enemy11");
		Enemy2.SetActive (false);
		Enemy3.SetActive (false);
		Enemy4.SetActive (false);
		Enemy5.SetActive (false);
		Enemy6.SetActive (false);
		Enemy7.SetActive (false);
		Enemy8.SetActive (false);
		Enemy9.SetActive (false);
		Enemy10.SetActive (false);
		Enemy11.SetActive (false);
		guiUpdater = GameObject.Find ("ShotText");
		guiUpdater2 = GameObject.Find ("HealthText");
		Enemy = GameObject.Find ("Enemy");

		enemyScript = Enemy.GetComponent<Enemy> ();
		Anim = this.GetComponent<Animator>();
		updater = guiUpdater.GetComponentInParent<GUIUpdater> ();
		updater2 = guiUpdater2.GetComponentInParent<GUIUpdater> ();
	}
	void Update()
	{
		

		if (Input.GetMouseButtonDown (1))
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
		Move ();
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
			//Destroy(GameObject.Find (hit.rigidbody.gameObject.name));

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
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			canShoot = false;
			this.transform.localScale = new Vector3 (5f, 2.5f, 5f);


		} 
		else if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			this.transform.localScale = new Vector3 (5f, 5f, 5f);
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
		if (kills == 5) 
		{
			Enemy6.SetActive(true);
			Enemy7.SetActive(true);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet") 
		{
			print ("You got hit!");
			health --;
			updater2.UpdateHealth(health);
			if(health <=0)
			{
				Destroy(this.gameObject);
			}
		}
	}
	void Move()
	{
		if (kills == 3) 
		{
			Anim.SetBool("Walk1",true);
			Anim.StopPlayback();
			Enemy4.SetActive(true);
			Enemy5.SetActive(true);
		}
		if (kills == 7) 
		{
			Anim.SetBool("Walk2",true);
			Anim.StopPlayback();
			Enemy8.SetActive (true);
			Enemy9.SetActive (true);
			Enemy10.SetActive (true);
			Enemy11.SetActive (true);
		}
		if (kills == 11) 
		{
			Anim.SetBool("Walk3",true);
			Anim.StopPlayback();
		}
	}

}
