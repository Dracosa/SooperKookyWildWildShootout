using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{

	public void LoadGame()
	{
		Application.LoadLevel ("Game1");
	}

	public void LoadInstructions()
	{
		Application.LoadLevel ("Instructions");

	}
	public void LoadMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
	public void LoadCredits()
	{
		Application.LoadLevel ("Credits"); 
	}
	public void QuitGame()
	{

	}
}
