using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]private int health = 5;
	[SerializeField]private int shots = 6;
	[SerializeField]private GUIUpdater updater;
	[SerializeField]private GUIUpdater updater2;
	[SerializeField]private Enemy enemyScript;
	[SerializeField]private GameObject Enemy2;
	[SerializeField]private GameObject Enemy3;
	[SerializeField]private GameObject Enemy4;
	[SerializeField]private GameObject Enemy5;
	[SerializeField]private GameObject Enemy6;
	[SerializeField]private GameObject Enemy7;
	[SerializeField]private GameObject Enemy8;
	[SerializeField]private GameObject Enemy9;
	[SerializeField]private GameObject Enemy10;
	[SerializeField]private GameObject Enemy11;
	[SerializeField]private GameObject Enemy12;
	[SerializeField]private GameObject Enemy13;
	[SerializeField]private GameObject Enemy14;
	[SerializeField]private GameObject Enemy15;
	[SerializeField]private Animator Anim = null;
	[SerializeField]private GameObject WinText;
	private GameObject QuickText;

	private GameObject Health_Backboard;
	private GameObject Health_WholeHeart1;
	private GameObject Health_WholeHeart2;
	private GameObject Health_WholeHeart3;
	private GameObject Health_WholeHeart4;
	private GameObject Health_WholeHeart5;
	private GameObject Health_HalfHeart1;
	private GameObject Health_HalfHeart2;
	private GameObject Health_HalfHeart3;
	private GameObject Health_HalfHeart4;
	private GameObject Health_HalfHeart5;

	private GameObject Leather_Ammo_Pouch;
	private GameObject Bullet1;
	private GameObject Bullet2;
	private GameObject Bullet3;
	private GameObject Bullet4;
	private GameObject Bullet5;
	private GameObject Bullet6;


	public int kills = 0;
	public Camera mainCamera;
	public GameObject hitImage;
	public static bool canReload = false;
	public GameObject Enemy;
	public static bool canShoot = true;
	public GameObject guiUpdater;
	public GameObject guiUpdater2;
	private bool canWin = false;

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
		Enemy12 = GameObject.Find ("Enemy12");
		Enemy13 = GameObject.Find ("Enemy13");
		Enemy14 = GameObject.Find ("Enemy14");
		Enemy15 = GameObject.Find ("Enemy15");
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
		Enemy12.SetActive (false);
		Enemy13.SetActive (false);
		Enemy14.SetActive (false);
		Enemy15.SetActive (false);


		Health_Backboard = GameObject.Find ("Health_Backboard");

		Health_WholeHeart1 = GameObject.Find ("Health_WholeHeart1");
		Health_WholeHeart2 = GameObject.Find ("Health_WholeHeart2");
		Health_WholeHeart3 = GameObject.Find ("Health_WholeHeart3");
		Health_WholeHeart4 = GameObject.Find ("Health_WholeHeart4");
		Health_WholeHeart5 = GameObject.Find ("Health_WholeHeart5");

		Health_HalfHeart1 = GameObject.Find ("Health_HalfHeart1");
		Health_HalfHeart2 = GameObject.Find ("Health_HalfHeart2");
		Health_HalfHeart3 = GameObject.Find ("Health_HalfHeart3");
		Health_HalfHeart4 = GameObject.Find ("Health_HalfHeart4");
		Health_HalfHeart5 = GameObject.Find ("Health_HalfHeart5");


		Leather_Ammo_Pouch = GameObject.Find ("Leather_Ammo_Pouch");

		Bullet1 = GameObject.Find ("Bullet1");
		Bullet2 = GameObject.Find ("Bullet2");
		Bullet3 = GameObject.Find ("Bullet3");
		Bullet4 = GameObject.Find ("Bullet4");
		Bullet5 = GameObject.Find ("Bullet5");
		Bullet6 = GameObject.Find ("Bullet6");

		WinText = GameObject.Find ("WinText");
		QuickText = GameObject.Find ("QuickText");
		QuickText.SetActive (false);
		WinText.SetActive (false);
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
			if(canReload)
			{
				Reloading ();

			}

		}

		if (Input.GetMouseButtonDown (0)) 
		{

			if(canReload == false)
			{
				
				Shoot ();
				Shooting();

			}
				
		}
		if (canWin)
		{
			if (Input.GetKey (KeyCode.E)) 
			{
				Application.LoadLevel("WinScene");
			}
		}

		if (shots >= 1) 
		{
			canShoot = true;
		} 
		else if (shots <= 0) 
		{
			canShoot = false;
		}
		Crouch();
		EnemyCount();
		Move();
		ShotCount();
		HealthCount();
	}
	void Shoot()
	{
		if (canShoot)
		{

			print ("shooting");
			shots--;
			updater.UpdateShot (shots);

		}
		if (canReload) 
		{
			canShoot = false;
		}

	}
	void Shooting()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast (ray, out hit))
		{
			Debug.DrawRay(ray.origin, hit.point);
			if(canShoot)
			{
				GameObject decal =  Instantiate(Resources.Load ("Decal")) as GameObject;
				decal.transform.position = hit.point;
				decal.transform.eulerAngles =  mainCamera.transform.eulerAngles;
				Destroy (decal,1);
			}

			//enemyScript.health --;

			//Destroy(GameObject.Find (hit.rigidbody.gameObject.name));

		}
	}
	void Reloading()
	{


		shots = 6;
		updater.UpdateShot (shots);




	}
	void Crouch()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			canShoot = false;
			canReload = true;
			this.transform.localScale = new Vector3 (5f, 2.5f, 5f);
			Health_Backboard.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);



		} 
		else if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			canReload = false;
			canShoot = true;
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
			hitImage.GetComponent<YouGotHit>().GetHit();
			health --;
			updater2.UpdateHealth(health);
			if(health <=0)
			{
				Destroy(this.gameObject,1);
				Application.LoadLevel("GameOver");
			}
		}
		if (other.tag == "EnemySpawn") 
		{
			Enemy8.SetActive (true);
			Enemy9.SetActive (true);
			Enemy10.SetActive (true);
			Enemy11.SetActive (true);

		}
		if (other.tag == "EnemySpawn1")
		{
			if(kills == 11)
			{
				print ("Enemy12");
				Enemy12.SetActive(true);
			}

		}
		if (other.tag == "EnemySpawn2")
		{
			if(kills == 12)
			{
				print ("Enemy13");
				Enemy13.SetActive(true);
			}
			
		}
		if (other.tag == "EnemySpawn3")
		{
			if(kills == 14)
			{
				print ("Enemy14");
				Enemy14.SetActive(true);

			}
			
		}
		if (other.tag == "EnemySpawn4") 
		{
			if(kills == 13)
			{
				QuickText.SetActive (true);
				Enemy15.SetActive(true);
			}
		}
		if (other.tag == "Win") 
		{
			WinText.SetActive(true);
			canWin = true;
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

		}
		if (kills == 11) 
		{
			Anim.SetBool("Walk3",true);
			Anim.StopPlayback();
		}
		if (kills == 12) 
		{
			Anim.SetBool("Walk4",true);
			Anim.StopPlayback();
		}
		if (kills == 13) 
		{
			Anim.SetBool("Walk5",true);
			Anim.StopPlayback();
		}
		if (kills == 15) 
		{
			Anim.SetBool("Walk6",true);
			Anim.StopPlayback();
		}
	}

	private void ShotCount()
	{
		if (shots == 6) 
		{
			Bullet1.SetActive(true);
			Bullet2.SetActive(true);
			Bullet3.SetActive(true);
			Bullet4.SetActive(true);
			Bullet5.SetActive(true);
			Bullet6.SetActive(true);
		}
		if (shots == 5)
		{
			Bullet1.SetActive(false);
			Bullet2.SetActive(true);
			Bullet3.SetActive(true);
			Bullet4.SetActive(true);
			Bullet5.SetActive(true);
			Bullet6.SetActive(true);
		}
		if (shots == 4)
		{
			Bullet1.SetActive(false);
			Bullet2.SetActive(false);
			Bullet3.SetActive(true);
			Bullet4.SetActive(true);
			Bullet5.SetActive(true);
			Bullet6.SetActive(true);
		}
		if (shots == 3)
		{
			Bullet1.SetActive(false);
			Bullet2.SetActive(false);
			Bullet3.SetActive(false);
			Bullet4.SetActive(true);
			Bullet5.SetActive(true);
			Bullet6.SetActive(true);
		}
		if (shots == 2)
		{
			Bullet1.SetActive(false);
			Bullet2.SetActive(false);
			Bullet3.SetActive(false);
			Bullet4.SetActive(false);
			Bullet5.SetActive(true);
			Bullet6.SetActive(true);
		}
		if (shots == 1)
		{
			Bullet1.SetActive(false);
			Bullet2.SetActive(false);
			Bullet3.SetActive(false);
			Bullet4.SetActive(false);
			Bullet5.SetActive(false);
			Bullet6.SetActive(true);
		}
		if (shots == 0)
		{
			Bullet1.SetActive(false);
			Bullet2.SetActive(false);
			Bullet3.SetActive(false);
			Bullet4.SetActive(false);
			Bullet5.SetActive(false);
			Bullet6.SetActive(false);
		}


	}
	private void HealthCount()
	{
		if (health == 5)
		{
			Health_WholeHeart1.SetActive(true);
			Health_WholeHeart2.SetActive(true);
			Health_WholeHeart3.SetActive(true);
			Health_WholeHeart4.SetActive(true);
			Health_WholeHeart5.SetActive(true);
		}
		if (health == 4)
		{
			Health_WholeHeart1.SetActive(false);
			Health_WholeHeart2.SetActive(true);
			Health_WholeHeart3.SetActive(true);
			Health_WholeHeart4.SetActive(true);
			Health_WholeHeart5.SetActive(true);
		}
		if (health == 3)
		{
			Health_WholeHeart1.SetActive(false);
			Health_WholeHeart2.SetActive(false);
			Health_WholeHeart3.SetActive(true);
			Health_WholeHeart4.SetActive(true);
			Health_WholeHeart5.SetActive(true);
		}
		if (health == 2)
		{
			Health_WholeHeart1.SetActive(false);
			Health_WholeHeart2.SetActive(false);
			Health_WholeHeart3.SetActive(false);
			Health_WholeHeart4.SetActive(true);
			Health_WholeHeart5.SetActive(true);
		}
		if (health == 1)
		{
			Health_WholeHeart1.SetActive(false);
			Health_WholeHeart2.SetActive(false);
			Health_WholeHeart3.SetActive(false);
			Health_WholeHeart4.SetActive(false);
			Health_WholeHeart5.SetActive(true);
		}
		if (health == 0)
		{
			Health_WholeHeart1.SetActive(false);
			Health_WholeHeart2.SetActive(false);
			Health_WholeHeart3.SetActive(false);
			Health_WholeHeart4.SetActive(false);
			Health_WholeHeart5.SetActive(false);
		}

	}


}
