using UnityEngine;
using System.Collections;

public class UIScale : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{

			this.transform.localScale = new Vector3 (0.08f, 0.08f, 0.08f);
			
			
			
		} 

	
	}
}
