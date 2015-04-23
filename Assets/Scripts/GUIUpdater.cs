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

	public Text KillsText;
	//player script
	private Player PlayerScript;
	//enemy script
	private Enemy EnemyScript;

	public void Start()
	{	// finds the player
		PlayerScript = GameObject.Find ("Player").GetComponent<Player>();
		EnemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy> ();
	}
	public void UpdateShot(int shots)
	{
		ShotText.text = ("Shots:" + shots.ToString ());

	}
	public void UpdateHealth(int health)
	{
		HealthText.text = ("Health:" + health.ToString ());
	}
	public void UpdateKills(int kills)
	{
		KillsText.text = ("Kills:" + kills.ToString ());
	}



}
