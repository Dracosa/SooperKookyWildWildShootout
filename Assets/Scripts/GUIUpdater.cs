/*
 * GUIUpdater.cs
 * by Ben Stewart
 * 
 * Updates the UI text*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour 
{
	public Text ShotText;

	public Text HealthText;
	//player script
	private Player PlayerScript;

	public void Start()
	{	// finds the player
		PlayerScript = GameObject.Find ("Player").GetComponent<Player>();

	}
	public void UpdateShot(int shots)
	{
		ShotText.text = ("Shots:" + shots.ToString ());

	}
	public void UpdateHealth(int health)
	{
		HealthText.text = ("Health:" + health.ToString ());
	}




}
