using UnityEngine;
using System.Collections;

public class WayPointAi : MonoBehaviour {
	
	//This array is used to set which points are the waypoints
	public GameObject[] wayPoints;
	
	//Speed and distance. Distance is used to determine how close you
	//want the object to get before going to next point.
	public float spd;
	public float distance;
	
	//Holds the current waypoint it is going to
	public int currentPoint;
	
	private bool change = false;
	
	//Holds the position of the waypoint it's heading towards.
	private Vector3 targetPosition;
	
	// Use this for initialization
	void Start () {
		//Sets  the first waypointPosition
		targetPosition = wayPoints[currentPoint].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Checks if the distance from the object to the way point is less than distance given
		//Once true it will increment to the next point.
		if (Vector3.Distance(transform.position, targetPosition) < distance && !change)
		{
			nextPoint();
		}
		else
		{
			float dir = 0;
			
			//Moving and turning
			
			//Gets the direction to face
			dir = -Mathf.Atan2(transform.position.z - targetPosition.z, transform.position.x - targetPosition.x) - 90 * Mathf.Deg2Rad;
			//Draws the line to show where the object is going.
			Debug.DrawRay(transform.position, new Vector3(Mathf.Sin(dir), 0, Mathf.Cos(dir)) * 20);
			//Rotates the object towards to the waypoint.
			transform.rotation = Quaternion.AngleAxis(dir * Mathf.Rad2Deg, Vector3.up);
			//Moves the object forward
			transform.Translate(Vector3.forward * spd * Time.deltaTime);
			
			change = false;
		}
	}
	
	private void nextPoint()
	{
		//Checks to see if it reached the max waypoint possible
		if (currentPoint >= wayPoints.Length - 1)
			//If true sets it to 0 so array doesn't go out of bounds.
			currentPoint = 0;
		else
			currentPoint++;
		//Sets the the targetPosition to the next waypoint.
		targetPosition = wayPoints[currentPoint].transform.position;
		change = true;
		
	}
}
