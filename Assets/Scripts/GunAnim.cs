using UnityEngine;
using System.Collections;

public class GunAnim : MonoBehaviour 
{
	[SerializeField]private Animator Anim = null;

	// Update is called once per frame
	void Update () 
	{
		if (Player.canShoot) 
		{
			
			if(Input.GetMouseButtonDown (0))
			{
				Anim.SetBool("ShootAnim",true);


			

			}
			if(Input.GetMouseButtonUp(0))
			{
				Anim.SetBool("ShootAnim",false);
			}

		}
		 



	
	}
}
