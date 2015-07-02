using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class MaquinaEstados : MonoBehaviour {

	public enum Transition
	{
		NullTransition = 0, // Use this transition to represent a non-existing transition in your system
	}
	
	
	public enum StateID
	{
		NullStateID = 0, // Use this ID to represent a non-existing State in your system	
	}

	// Use this for initialization
	void Start () {

		Debug.Log("START");
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("UPDATE");
	
	}
}
