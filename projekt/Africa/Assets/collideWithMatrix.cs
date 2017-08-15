using UnityEngine;
using System.Collections;

public class collideWithMatrix : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}

	public int isColl=0;
	GameObject withWhat = null;
	void OnCollisionStay(Collision collisionInfo) 
	{
		isColl = 1;
		Debug.Log ("AAA");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
