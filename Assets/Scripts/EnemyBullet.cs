using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour 
{

	[SerializeField]private float speed = 20f;
	[SerializeField]private string m_BulletKillZone = "BulletKillZone";
	[SerializeField]private string m_PlayerName = "Player";

	private void Update()
	{
		transform.Translate (transform.forward * Time.deltaTime * speed,Space.World);
		//this.transform.position += Vector3.forward * Time.deltaTime * speed;
	}

	public void OnTriggerEnter(Collider other)
	{
		print ("hitKillZone");
		// when it hits the player the bullet will get destroyed 
		if (other.tag == m_PlayerName) 
		{
			Destroy(this.gameObject);
		}
		// when they hit a bullet kill zone they will get destroyed
		if (other.tag == m_BulletKillZone)
		{
			Destroy (this.gameObject);
		}
	}

}
