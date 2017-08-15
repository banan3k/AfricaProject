using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class zipper : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}

	IEnumerator temp()
	{
		yield return new WaitForSeconds (0.5f);
	}
	int zipperCalled=0;
	public GameObject help;
	int modeGlobal=0;
	int globalResources=0;
	int globalID=0;
	int globalBad=0;
	public void callZipper(GameObject helpHired, int mode, GameObject rented, int resources, int id, int badness)
	{
		GameObject.Find("backgroundCube").transform.localScale=new Vector3(0,0,0);
		if(GameObject.Find("backgroundForSend"))
			Destroy(GameObject.Find("backgroundForSend"));
		int i = 1;
		zipperCalled = 1;
		modeGlobal = mode;
		help = helpHired;
		globalResources = resources;
		rentBuilding = rented;
		globalID = id;
		globalBad = badness;
		while(GameObject.Find("statistic"+i))
		{

			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=1;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = false;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = false;
			
			
			i++;
		}
		GameObject.Find("Main Camera").GetComponent<playerInterface>().showEmailForUser=0;
		float xForBackGround = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.3f, 1, Screen.height * 0.25f)).x - Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.7f, 1, Screen.height * 0.25f)).x;
		if(xForBackGround<0)
			xForBackGround *= -1;
		float yForBackGround = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.height * 0.2f, Screen.height * 0.2f, Screen.height * 0.2f)).x - Camera.main.ScreenToWorldPoint (new Vector3 (Screen.height * 0.799f, Screen.height * 0.8f, Screen.height * 0.8f)).x;

		if(yForBackGround<0)
			yForBackGround *= -1;


		background = GameObject.CreatePrimitive(PrimitiveType.Cube);
		background.transform.position = new Vector3 (0, 1, 0);
		background.transform.localScale = new Vector3 (xForBackGround, 1, yForBackGround);
		background.transform.name = "backgroundForSend";
		Material newMat = Resources.Load("forSend", typeof(Material)) as Material;
		background.GetComponent<MeshRenderer> ().material = newMat;

		background.GetComponent<MeshRenderer> ().receiveShadows = false;
		zipperObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		zipperObj.transform.position = new Vector3 (background.transform.position.x-background.transform.localScale.x/2+5, 4.5f, heightOfZipper);
		zipperObj.GetComponent<MeshRenderer> ().material.color = Color.red;
		zipperObj.transform.name = "zipper";

		positionForBox=Camera.main.WorldToScreenPoint(zipperObj.transform.position);
	}

	void turnOfZipper()
	{
		zipperCalled=0;
		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=0;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = true;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = true;
			
			
			i++;
		}
		howMuchPointed = 0;
		Destroy (GameObject.Find ("backgroundForSend"));
		Destroy (GameObject.Find ("zipper"));

	}

	int heightOfZipper = -7;
	GameObject zipperObj;
	GameObject background;
	int canMove=0;
	float positionStartMouse=0, positionStart;
	float tempMouse=0;
	float changeOfPosition=0;
	float max=0;

	string describe="\n\n\nWelcome,\n how much resources you want to send to this place?";
	void OnGUI()
	{
		if(zipperCalled==1)
		{
			GUI.skin.label.alignment = TextAnchor.UpperCenter;
			GUI.skin.button.alignment = TextAnchor.MiddleCenter;
			GUI.color = Color.black;
			GUI.Label (new Rect (Screen.width*0.3f, Screen.height*0.2f, Screen.width*0.4f, Screen.height*0.6f), describe);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (Screen.width*0.3f, Screen.height*0.6f, Screen.width*0.4f, 100), howMuchPointed+"");
			GUI.Box(new Rect(Screen.width*0.3f, Screen.height*0.2f, Screen.width*0.4f, Screen.height*0.5f),"");
			if(GUI.Button(new Rect (Screen.width*0.3f, Screen.height*0.7f, Screen.width*0.4f, Screen.height*0.1f), "SEND"))
			{
				Debug.Log("send");
				send ();
			}
			if(GUI.Button(new Rect (Screen.width*0.7f-25, Screen.height*0.2f, 25, 25), "X"))
			{
				turnOfZipper();
				if(rentBuilding)
					Destroy(rentBuilding);
			}

			sizeForBox=Camera.main.WorldToScreenPoint(zipperObj.transform.localScale);

			GUI.Box (new Rect(positionForBox.x-12.5f,Screen.height-positionForBox.y-12.5f,Screen.width*0.325f+7.5f,25),"");

		}
	}
	GameObject rentBuilding;
	Vector3 positionForBox, sizeForBox;
	void send()
	{


		rentBuilding.GetComponent<goForTrip> ().setTrip (help, modeGlobal);
		Debug.Log(globalBad+" how bad");
		if(globalID!=10000 && globalBad!=0)
		{
			float additionalPower = howMuchPointed/globalBad;
			rentBuilding.GetComponent<goForTrip> ().power = additionalPower;

		}
		else
		{
			rentBuilding.GetComponent<goForTrip> ().resources=howMuchPointed;

		}
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().resources -= howMuchPointed;
		turnOfZipper ();
	}

	int howMuchPointed=0;
	// Update is called once per frame
	void Update () 
	{
		if(canMove==1)
		{

			if((zipperObj.transform.position.x>=background.transform.position.x-background.transform.localScale.x/2+5 || tempMouse<Input.mousePosition.x)
			   && (zipperObj.transform.position.x<=background.transform.position.x+background.transform.localScale.x/2-5 || tempMouse>Input.mousePosition.x))
			{
				if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x>=background.transform.position.x-background.transform.localScale.x/2+5 
				   && Camera.main.ScreenToWorldPoint(Input.mousePosition).x<=background.transform.position.x+background.transform.localScale.x/2-5)
					zipperObj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,5,heightOfZipper);
				else if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x<background.transform.position.x-background.transform.localScale.x/2+5)
					zipperObj.transform.position = new Vector3(background.transform.position.x-background.transform.localScale.x/2+5,5,heightOfZipper);
				else
					zipperObj.transform.position = new Vector3(background.transform.position.x+background.transform.localScale.x/2-5,5,heightOfZipper);
				changeOfPosition=((((zipperObj.transform.position.x-positionStart)/max)+1)/2);

			
				howMuchPointed = (int)(changeOfPosition*globalResources);

			}
		
			tempMouse=Input.mousePosition.x;
		}

		if (Input.GetMouseButtonDown(0))
		{ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
			
				if(hit.transform.name=="zipper")
				{
				
					canMove=1;
					max=background.transform.position.x+background.transform.localScale.x/2-5;
					positionStartMouse=Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
					positionStart = transform.position.x;

				}
				
			}
		}
		if (Input.GetMouseButtonUp(0))
		{

			canMove=0;

				

		}
	}
}
