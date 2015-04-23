using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YouGotHit : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		this.GetComponent<Image> ().CrossFadeAlpha (0, 0, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GetHit()
	{
		this.GetComponent<Image> ().CrossFadeAlpha (1, 0, true);
		this.GetComponent<Image> ().CrossFadeAlpha (0, 0.5f, true);
	}
}
