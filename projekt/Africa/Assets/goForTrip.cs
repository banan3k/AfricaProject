using UnityEngine;
using System.Collections;

public class goForTrip : MonoBehaviour {

	LineRenderer lineRenderer;
	void Start () 
	{
		howBigStep = 0.1f * GameObject.Find ("Main Camera").GetComponent<playerInterface> ().globalTimePerDay;

		Rigidbody gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.

		gameObjectsRigidBody.useGravity = false;
		gameObjectsRigidBody.interpolation = RigidbodyInterpolation.Extrapolate;

		this.GetComponent<BoxCollider> ().size = new Vector3 (2, 2,2);
	
		lineRenderer = this.transform.gameObject.AddComponent<LineRenderer> ();
		lineRenderer.enabled=true;
		lineRenderer.useWorldSpace=true;
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(Color.red, Color.red);
		lineRenderer.SetWidth(0.5F, 0.5F);
	
		sizeOfBoxInGui=(int)(fontSizeForKeys*1.2f);
	}

	void OnTriggerStay(Collider other) 
	{
		if(other==toCheckCollider)
		{
			StartCoroutine(punishForBeing(other));
			toCheckCollider=null;
			Debug.Log("punish is coming again");
		}
	}

	IEnumerator punishForBeing(Collider other)
	{
		//here make some punishment

		yield return new WaitForSeconds (3);
		toCheckCollider = other;
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.transform.name.Length>=10 && other.transform.name.Substring(0,10)=="sendAbroad")
		{
			StartCoroutine(stun());
			Debug.Log ("collision "+other.transform.name);
		}
		else
		{
			StartCoroutine(punishForBeing(other));
		}

	}

	Collider toCheckCollider;
	IEnumerator stun()
	{
		int x = 1;
		speed = 0;
		yield return new WaitForSeconds (x);
		speed = 1;



	}

	Vector3 startPutting=new Vector3(0,0,0);
	Vector3[] pathToGo=new Vector3[100000];
	int pathCount=0, alreadyAprouched=0;

	int reached=0;
	int isWaiting=0;
	float speed=0.05f;


	ArrayList keysList = new ArrayList();


	void stopPressingButtons()
	{
	
		if (completePressing != 4)
			Destroy (this.gameObject);
		else
		{
			completePressing=0;
		}
		animationGuiX=0;
	}

	int fontSizeForKeys = 25;
	int animationGuiX=0;
	float sizeOfBoxInGui;

	float visibilityOfGui=1;
	int blockGui=0;
	void OnGUI()
	{
		if(completePressing>0 && blockGui==0)
		{
			if(animationGuiX<0.3f*Screen.width)
				visibilityOfGui=(animationGuiX/(0.3f*Screen.width));
			else
			{
				visibilityOfGui=1-((animationGuiX-(0.3f*Screen.width))/(0.3f*Screen.width));

			}
			GUI.skin.button.fontSize=fontSizeForKeys;
			GUI.skin.button.alignment=TextAnchor.MiddleCenter;
			GUI.skin.button.padding=new RectOffset(0,0,0,0);
			GUI.backgroundColor = new Color(0,0,0,visibilityOfGui);
			GUI.color = new Color(1,1,1,visibilityOfGui);
			GUI.Button(new Rect(Screen.width*0.2f+animationGuiX, Screen.height-sizeOfBoxInGui,fontSizeForKeys*1.2f,sizeOfBoxInGui),keysList [0].ToString());
			GUI.Button(new Rect(Screen.width*0.2f+sizeOfBoxInGui+animationGuiX,Screen.height-sizeOfBoxInGui,sizeOfBoxInGui,sizeOfBoxInGui),keysList [1].ToString());

			animationGuiX++;

		}
		if(Screen.width*0.2f+(sizeOfBoxInGui*2)+animationGuiX>=Screen.width*0.8f)
		{
			blockGui=1;

			stopPressingButtons();
		}
		GUI.skin.button.fontSize=10;


	}

	int completePressing=0;

	KeyCode[] keysToPresse = new KeyCode[26]{KeyCode.Q,KeyCode.W,KeyCode.E,KeyCode.R,KeyCode.T,KeyCode.Y,KeyCode.U,KeyCode.I,KeyCode.O,KeyCode.P,KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.F,KeyCode.G,KeyCode.H,KeyCode.J,
		KeyCode.K,KeyCode.L,KeyCode.Z,KeyCode.X,KeyCode.C,KeyCode.V,KeyCode.B,KeyCode.N,KeyCode.M};
	void Update () 
	{

		if(keysList.Count>0 && (Input.GetKeyDown((KeyCode)keysList[0]) || Input.GetKeyDown((KeyCode)keysList[1])))
		{
			Debug.Log("step 1");

			completePressing++;
		}
		if (keysList.Count>0 && (Input.GetKeyUp ((KeyCode)keysList [0]) || Input.GetKeyUp ((KeyCode)keysList [1])) && (completePressing > 0 && completePressing <4))
			completePressing--;
		if(completePressing==3)
		{
			Debug.Log("done");
			completePressing=4;
			stopPressingButtons();
		}

		if(pathCount!=0 && alreadyAprouched<pathCount)
		{
			isWaiting=0;

			if(Vector3.Distance(transform.position,pathToGo[alreadyAprouched])>0.5f)
			{
				transform.position = Vector3.MoveTowards(transform.position,pathToGo[alreadyAprouched],speed);
				if(Random.Range (0,1)==0 && completePressing==0)
				{
					int firstKey = Random.Range(0,26);
					completePressing=1;
					keysList.Insert(0,keysToPresse[firstKey]);
					int secondKey = Random.Range(0,26);
					while(secondKey==firstKey)
					{
						secondKey = Random.Range(0,26);
					}
					keysList.Insert(1,keysToPresse[secondKey]);
					Debug.Log (keysToPresse[secondKey].ToString()+" click "+keysToPresse[firstKey]);
					blockGui=0;

				}
			}
			else
			{
				if(alreadyAprouched>0)
					lineRenderer.SetPosition(alreadyAprouched-1, new Vector3(pathToGo[alreadyAprouched].x,1000,pathToGo[alreadyAprouched].z));
				alreadyAprouched++;


			}
			if (Vector3.Distance (transform.position, destinationObjct.transform.position) <= 3 && reached==0)
			{
				if(globalMode==0)
					reachedDestiny (destinationObjct);
				else
					reachedResources(destinationObjct);
				reached=1;

			}

		}
		else if(alreadyAprouched==pathCount && pathCount>5)
		{
		
		}



		if(howBigStep!=0.1f * GameObject.Find ("Main Camera").GetComponent<playerInterface> ().globalTimePerDay)
			howBigStep = 0.1f * GameObject.Find ("Main Camera").GetComponent<playerInterface> ().globalTimePerDay;

		if(whatModeOfDestination==1)
		{

			if(Vector2.Distance(startPutting,Input.mousePosition)>2)
			{
				startPutting=Input.mousePosition;

				Vector3 goingTemp = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(startPutting.x,0,startPutting.y)).x,1,Camera.main.ScreenToWorldPoint(startPutting).z);
			
			
				pathToGo[pathCount]=goingTemp;
				pathCount++;
				lineRenderer.SetVertexCount(pathCount);
				lineRenderer.SetPosition(pathCount-1, goingTemp);
			
			}
			if(Input.GetMouseButtonUp(0) && pathCount>5)
			{
				whatModeOfDestination=0;
			
			}
		}
		else if(whatModeOfDestination==0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Input.GetMouseButtonDown(0))
			{ 

				if (Physics.Raycast(ray, out hit))
				{

					if(hit.transform.name==this.transform.name)
					{
						Debug.Log("comming there by you");
						setTrip(destinationObjct,globalMode);
					}
				}
			}
			else if (Physics.Raycast(ray, out hit))
			{

				if(hit.transform.name==this.transform.name)
				{
					this.GetComponent<MeshRenderer>().material.color = Color.red;
				}
				else
				{
					this.GetComponent<MeshRenderer>().material.color = Color.white;

				}
			}
			else
				this.GetComponent<MeshRenderer>().material.color = Color.white;
		}
	
	}

	void setDirectly()
	{

		float divition = 3f;
		int howManyDiserupts = Random.Range (1, 10);
		lineRenderer.SetVertexCount(howManyDiserupts+2);

		lineRenderer.SetPosition(0, this.transform.position);
		for(int i=0; i<howManyDiserupts; i++)
		{

			divition=1.2f+((1.8f/(howManyDiserupts+1))*(i+1));

			Vector3 midpointAtoB = new Vector3((this.transform.position.x+destinationObjct.transform.position.x)/divition+Random.Range(1,5),(this.transform.position.y+destinationObjct.transform.position.y)/2f,(this.transform.position.z+destinationObjct.transform.position.z)/divition+Random.Range(1,5));
			midpointAtoB.y=1;
			lineRenderer.SetPosition (i+1, midpointAtoB);
			pathToGo[i]=midpointAtoB;
		}

		lineRenderer.SetPosition (howManyDiserupts+1, new Vector3(destinationObjct.transform.position.x, 1,destinationObjct.transform.position.z));

		pathToGo[howManyDiserupts]=destinationObjct.transform.position;
		pathCount = howManyDiserupts+1;
	}

	int whatSideTowards=0;
	public void setTrip(GameObject destiny, int mode)
	{
		destinationObjct = destiny;
		pathToGo=new Vector3[100000];
		alreadyAprouched = 0;
		if(pathCount!=0)
			Destroy(GameObject.Find(this.transform.name+"group").transform.gameObject);
		GameObject groupDest = new GameObject ();
		groupDest.transform.name = this.transform.name + "group";
		globalMode = mode;
		if(pathCount==0)
		{
			setDirectly();
		}
		else
		{

			pathCount=0;

			putDestinations ();
		}

	}

	int whatModeOfDestination=0, globalMode=0;
	GameObject destinationObjct;
	void putDestinations()
	{
		pathCount = 0;
		startPutting = new Vector2 (0, 0);
		whatModeOfDestination = 1;
	
	}

	public float power=0;
	public int whenBreakTripToNormal=5;
	float howBigStep=0.1f;
	int whatSideX=0,whatSideZ=0;
	float randTemp=0, randTemp2=0;
	float x=-1,z=-1;
	public int protectionLevel=0;

	int possibilityToNotAttack=100;

	void reachedResources(GameObject destiny)
	{
	
		destiny.GetComponent<goForTrip> ().resources += transform.GetComponent<goForTrip> ().resources;
		if (destiny.GetComponent<goForTrip> ().resources > destiny.GetComponent<goForTrip> ().maxResources)
			destiny.GetComponent<goForTrip> ().resources = destiny.GetComponent<goForTrip> ().maxResources;
		Destroy (transform.gameObject);
	}
	public int resources=500,maxResources=0;
	void reachedDestiny(GameObject destiny)
	{
		Debug.Log ("first power: " + power);
		destinyInMatrix = transform.gameObject;
		destinyInMatrix2 = destiny.transform.gameObject;
		GameObject.Find ("Main Camera").GetComponent<eventSystem> ().startMatrix (destinyInMatrix);
		completePressing = 0;

	}

	GameObject destinyInMatrix, destinyInMatrix2;

	public void resaultOfReach(float powerInAddition)
	{
		int numberOfEvent = int.Parse(destinyInMatrix2.transform.name [destinyInMatrix2.transform.name.Length - 1].ToString());
		Destroy (transform.gameObject);
		power *= powerInAddition;
	
		float tempBad = GameObject.Find ("Main Camera").GetComponent<eventSystem> ().badOfEvents [numberOfEvent];
		tempBad *= power;
		GameObject.Find ("Main Camera").GetComponent<eventSystem> ().badOfEvents [numberOfEvent] -= (int)(Mathf.Round(tempBad));
		Debug.Log (power+" power "+GameObject.Find ("Main Camera").GetComponent<eventSystem> ().badOfEvents [numberOfEvent]);
		
		if(GameObject.Find ("Main Camera").GetComponent<eventSystem> ().badOfEvents[numberOfEvent]<=-1)
			GameObject.Find ("event" + numberOfEvent).GetComponent<MeshRenderer> ().material.SetColor ("_Color", new Color (1, 0, 0, 0.5f));
		else if(GameObject.Find ("Main Camera").GetComponent<eventSystem> ().badOfEvents[numberOfEvent]<=1)
			GameObject.Find ("event" + numberOfEvent).GetComponent<MeshRenderer> ().material.SetColor ("_Color", new Color (1, 1, 0, 0.5f));
		else
			GameObject.Find ("event" + numberOfEvent).GetComponent<MeshRenderer> ().material.SetColor ("_Color", new Color (0, 1, 0, 0.5f));
		Debug.Log (GameObject.Find ("Main Camera").GetComponent<eventSystem> ().badOfEvents [numberOfEvent]+" because of "+power);

	}

	int whenStopTravelingAround=10;
	int counterTrip=0;
	public int counterTrip2=0;
	Vector3 destinyTemp;
	// Update is called once per frame

}
