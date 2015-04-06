/*
 * EnemyAI.cs
 * 
 * By Ben Stewart
 * 
 * This Scipt is for the Enemies of the game*/



using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour 
{

	[SerializeField]private float patrolSpeed = 10f;
	[SerializeField]private Transform [] patrolWayPoints;
	[SerializeField]private NavMeshAgent nav = null;
	[SerializeField]private int curWaypoint = 0;
	[SerializeField]private int maxWaypoint;
	[SerializeField]private float minWaypointDistance = 0.1f;


	//
	private void Awake()
	{
		nav = gameObject.GetComponent<NavMeshAgent> ();


		maxWaypoint = patrolWayPoints.Length - 1;
	}

	private void Update()
	{
		// calls the Patrolling function
		Patrolling ();
	}
	/// <summary>
	/// Set up the array for the way points of the enemies and so they know which way to patrol 
	/// and to return to the starting waypoint after it gets to the last waypoint in the array
	/// </summary>
	private void Patrolling()
	{
		nav.speed = patrolSpeed;

		Vector3 tempLocalPosition;
		Vector3 tempWayPointPosition;

		tempLocalPosition = transform.position;
		tempLocalPosition.y = 0f;

		tempWayPointPosition = patrolWayPoints [curWaypoint].position;
		tempWayPointPosition.y = 0f;

		if (Vector3.Distance (tempLocalPosition, tempWayPointPosition) <= minWaypointDistance) 
		{
			if(curWaypoint == maxWaypoint)
				curWaypoint =0;
			else
				curWaypoint ++;
		}
		nav.SetDestination (patrolWayPoints [curWaypoint].position);


	}


}
