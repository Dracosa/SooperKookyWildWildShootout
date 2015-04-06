using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 1;

	void Start () 
	{
	
	}
	

	void Update () 
	{


		if (health == 0)
		{
			Destroy(this.gameObject);
		}



		
	
	}
}
