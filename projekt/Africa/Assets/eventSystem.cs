using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class eventSystem : MonoBehaviour {


	Texture2D texture;
	// Use this for initialization
	void Start () 
	{

	

		texture = Resources.Load ("blueTexture") as Texture2D;

		StartCoroutine (putEvent ());
		sendTexture = Resources.Load("whiteTexture") as Texture;
		disasterTexture = Resources.Load("disaster1") as Texture2D;
		setDescribe ();

		for (int i=0; i<100; i++)
			whatCoursePutted [i] = new string[1000];


	}

	IEnumerator temp()
	{
		yield return new WaitForSeconds (3);
		sendAbroad (-1);

	}

	void setDescribe()
	{
		for (int i=0; i<3; i++)
			describe [i] = new string[1000];

		describe [0] [0] = "describe A1";
		describe [0] [0] = "describe A2";
		describe [0] [0] = "describe A3";
		describe [1] [0] = "describe B1";
		describe [1] [0] = "describe B2";
		describe [1] [0] = "describe B3";
		describe [2] [0] = "describe C1";
		describe [2] [0] = "describe C2";
	}
	string[][] describe = new string[3][];

	Collider[] hit=new Collider[50];
	public int[] badOfEvents = new int[10000];

	void putCurse(string country, int howBad, int howLong)
	{
	
	}
	IEnumerator slowCourse(string country, int id, int whatAffect)
	{

		GameObject.Find (country).GetComponent<howIsDoing> ().addX += badOfEvents [id];
		GameObject.Find (country).GetComponent<howIsDoing> ().addY += badOfEvents [id];
		GameObject.Find (country).GetComponent<howIsDoing> ().addZ += badOfEvents [id];
		yield return new WaitForSeconds (GameObject.Find ("Main Camera").GetComponent<playerInterface> ().globalTimePerDay);
		if(GameObject.Find ("event" + id).GetComponent<MeshRenderer> ().enabled==true)
			StartCoroutine (slowCourse (country, id,whatAffect));
		else
		{
			GameObject.Find (country).GetComponent<howIsDoing> ().addX += badOfEvents [id];
			GameObject.Find (country).GetComponent<howIsDoing> ().addY += badOfEvents [id];
			GameObject.Find (country).GetComponent<howIsDoing> ().addZ += badOfEvents [id];
		}

	}

	string[][] whatCoursePutted=new string[100][];
	int[] whatCourseAlreadyPut = new int[10000];
	void forWhatCourse(Vector3 where, float howBig, int id)
	{

		hit = Physics.OverlapSphere(where, howBig);
		if(whatCourseAlreadyPut[id]!=hit.Length)
		{
			whatCourseAlreadyPut [id] = hit.Length;
			if (hit.Length > 0)
			{

				for(int i2=0; i2<hit.Length; i2++)
				{

					if(hit[i2].transform.name[0]=='c')
					{

						int canMoveForword=0;

						int tempID = int.Parse(hit[i2].transform.name.Substring(7,hit[i2].transform.name.Length-7));
						for(int i3=0; i3<hit.Length; i3++)
						{

							if(whatCoursePutted[tempID][i3]==hit[i2].transform.name)
								canMoveForword=1;
						}
						if(canMoveForword==0)
						{
							whatCoursePutted[tempID][i2]=hit[i2].transform.name;
							StartCoroutine(slowCourse(hit[i2].transform.name, id, Random.Range(0,3)));
						}

					}
				}
			}
		}
	}

	int[] howMuchMoneyNeedEvent=new int[10000];
	IEnumerator putEvent()
	{
		int howBigBrake = Random.Range (1, 5);

		yield return new WaitForSeconds(howBigBrake*GameObject.Find("Main Camera").GetComponent<playerInterface>().globalTimePerDay);
		int whatKindOfEvent = Random.Range (0, 3);
		if(whatKindOfEvent==0)
		{
		
			int howBad = Random.Range (1, 4);
		
			float howBig = Random.Range (0.5f, 5f);
			int howLong = Random.Range (5, 61);
		
			Vector3 whereEvent = new Vector3 ();
			whereEvent.x = Random.Range (-20f, 20f); // normalnie -22,22

			whereEvent.y = 0.1f;
			whereEvent.z = Random.Range (-10f, 10f); //normalnie -11,11
			GameObject ballEvent = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			int i = 1;

			while(GameObject.Find("event"+i))
			{
				i++;
			}

			badOfEvents [i] = howBad;

			forWhatCourse(whereEvent, howBig, i);
		
		
			ballEvent.GetComponent<MeshRenderer> ().material.SetColor ("_Color", new Color (1, 0, 0, 0.5f));
			ballEvent.GetComponent<MeshRenderer> ().material.shader = Shader.Find( "Transparent/Diffuse" );
		
			ballEvent.name = "event" + i;

			howLongForExist[i]=0;

			StartCoroutine (turnOffEvent (howLong, howBad, i));



			howMuchMoneyNeedEvent[i]=howBad*Random.Range(1000,2000);
	
			ballEvent.transform.localScale = new Vector3 (howBig, howBig, howBig);

			ballEvent.transform.position = whereEvent;
		}
		else if(whatKindOfEvent==1)
		{
			int howBad = Random.Range (1, 4);

			int forWhat = Random.Range(0,3);
			int didPass=0;

			if(forWhat==0)
			{
				if(Random.Range(0,100)<GameObject.Find("Main Camera").GetComponent<playerInterface>().powerOfMarket)
					didPass=0;
				else
					didPass=1;
				if(didPass==0)
					GameObject.Find("Main Camera").GetComponent<playerInterface>().popularity-=howBad;
				else
					GameObject.Find("Main Camera").GetComponent<playerInterface>().popularity+=howBad;
			
			}
			if(forWhat==0)
			{
				if(Random.Range(0,100)<GameObject.Find("Main Camera").GetComponent<playerInterface>().powerOfMenage )
					didPass=0;
				else
					didPass=1;
				if(didPass==0)
					GameObject.Find("Main Camera").GetComponent<playerInterface>().trustness-=howBad;
				else
					GameObject.Find("Main Camera").GetComponent<playerInterface>().trustness+=howBad;
				
			}
			if(forWhat==0)
			{
				if(Random.Range(0,100)<GameObject.Find("Main Camera").GetComponent<playerInterface>().powerOfHelp)
					didPass=0;
				else
					didPass=1;
				if(didPass==0)
					GameObject.Find("Main Camera").GetComponent<playerInterface>().respectness-=howBad;
				else
					GameObject.Find("Main Camera").GetComponent<playerInterface>().respectness+=howBad;
				
			}
			if(didPass==0)
				GameObject.Find("Main Camera").GetComponent<playerInterface>().money-=Random.Range(1000,2001);
			else
				GameObject.Find("Main Camera").GetComponent<playerInterface>().money+=Random.Range(1000,2001);
	
		}
		else 
		{
			GameObject.Find("Main Camera").GetComponent<playerInterface>().addEmail (0,"Invite", "World","You are invated into special event",1);
		}
		StartCoroutine (putEvent ());


	}





	int eventShow=0;
	void showEvent()
	{
		eventShow = 1;
		Time.timeScale = 0;
		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=1;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = false;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = false;


			i++;
		}
		GameObject.Find("Main Camera").GetComponent<playerInterface>().canShowEmailsAtAll=1;

	}
	public void setTimeScale(int mode)
	{
		if (mode == 0)
			Time.timeScale = mode;
		if (mode == 1)
			Time.timeScale = mode;

	}
	void hideEvent()
	{
		eventShow = 0;
		Time.timeScale = 1;
		int i = 1;
		while(GameObject.Find("statistic"+i))
		{

			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=0;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = true;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = true;
			
			
			i++;
		}
		GameObject.Find("Main Camera").GetComponent<playerInterface>().canShowEmailsAtAll=0;
	}


	Texture2D normalTexture;
	void OnGUI()
	{
		GUI.skin.label.fontSize=15;

		if(eventShow==1)
		{
	
			Graphics.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture,10,10,10,10);
		
			GUI.Box(new Rect(5,0,Screen.width*0.25f-10,Screen.height),"");

			normalTexture=GUI.skin.box.normal.background;
			GUI.skin.box.normal.background=disasterTexture;
			GUI.Box(new Rect(Screen.width*0.25f,0,Screen.width*0.5f,Screen.height*0.65f),"");
			GUI.skin.box.normal.background=normalTexture;
			GUI.Box(new Rect(Screen.width*0.25f,Screen.height*0.65f+5,Screen.width*0.5f,Screen.height*0.35f-5),"");
			GUI.Box(new Rect(Screen.width*0.75f+5,0,Screen.width*0.25f-10,Screen.height),"");

			GUI.skin.button.alignment=TextAnchor.MiddleCenter;
			GUI.skin.button.fontSize=25;
			GUI.color=Color.red;
			if(GUI.Button(new Rect(Screen.width*0.75f-30,0,30,25),"X"))
			{
				hideEvent();
			}
			GUI.color=Color.white;
			GUI.skin.button.fontSize=15;
			GUI.skin.label.fontSize=15;
			GUI.skin.label.alignment=TextAnchor.UpperLeft;
			GUI.Label(new Rect(10,10,Screen.width*0.25f-10,Screen.height-10),describe[0][0]);
			GUI.Label(new Rect(Screen.width*0.75f+10,10,Screen.width*0.25f-10,Screen.height-10),"What already did\nWhat already did\nWhat already did\nWhat already did\nWhat already did\nWhat already did\n");

			howManyHire=0;
			additionalHeight=0;

			GUI.color=Color.white;
			howManyHire2=0;
			countBulidTemp=1;
			if(widthOfChoice<Screen.width*0.501f)
				widthOfChoice=Screen.width*0.501f;
			scrollPosition = GUI.BeginScrollView(new Rect((Screen.width*0.25f), Screen.height*0.65f, Screen.width*0.5f, Screen.height*0.35f), scrollPosition, new Rect(0, 0, widthOfChoice, 0));

			for(int i=0; i<GameObject.Find("Main Camera").GetComponent<playerInterface>().countHelp; i++)
			{

				if(GameObject.Find("hiredBuilding"+howManyHire2))
				{
					GUI.skin.label.alignment=TextAnchor.MiddleLeft;
					GUI.color=Color.white;
					GUI.DrawTexture(new Rect((howManyHire2*Screen.width*0.1f),Screen.height*0.15f,Screen.width*0.1f,Screen.height*0.11f), sendTexture, ScaleMode.StretchToFill, true, 0);
					GUI.color=Color.black;
					GUI.Label(new Rect(5+(howManyHire2*Screen.width*0.1f),Screen.height*0.15f,Screen.width*0.1f,Screen.height*0.11f),"From: Country\nResources: 2000\nDistance: "+distanceEvent.ToString("0"));
					distanceEvent=Vector3.Distance (GameObject.Find ("hiredBuilding"+howManyHire2).transform.position,whatEvent.transform.position);
					if(distanceEvent<10)
						GUI.color=Color.green;
					else if(distanceEvent<20)
						GUI.color=Color.yellow;
					else
						GUI.color=Color.red;

					GUI.skin.label.fontSize=15;

					GUI.DrawTexture(new Rect(0+(howManyHire2*Screen.width*0.1f),5,Screen.width*0.1f,Screen.height*0.15f-5), sendTexture, ScaleMode.StretchToFill, true, 0);

					GUI.Box(new Rect(0+(howManyHire2*Screen.width*0.1f),5,Screen.width*0.1f,Screen.height*0.325f),"");

					if(GUI.Button(new Rect(0+(howManyHire2*Screen.width*0.1f),Screen.height*0.26f,Screen.width*0.1f,Screen.height*0.075f),"SEND"))
					{
						sendAbroad(howManyHire2);
					}
				}
				else
				{
					GUI.color=Color.white;

					if(GUI.Button(new Rect(0+(howManyHire2*Screen.width*0.1f),0,Screen.width*0.1f,Screen.width*0.325f),""))
					{

						sendAbroad(-1*countBulidTemp);
					}
					countBulidTemp++;
				}

				howManyHire2++;
				if(howManyHire2%5==0)
					additionalHeight+=Screen.width*0.5f+5;
			}
			widthOfChoice=howManyHire2*Screen.width*0.1f;
			GUI.EndScrollView();
		}
	}
	Texture sendTexture;
	Texture2D disasterTexture;
	float widthOfChoice=0;
	Vector2 scrollPosition = Vector2.zero;
	int countBulidTemp=1;
	void sendAbroad(int mode)
	{
		GameObject rentBuilding = GameObject.CreatePrimitive(PrimitiveType.Cube);
		rentBuilding.GetComponent<BoxCollider> ().isTrigger = true;
		int i = 0;
		while(GameObject.Find("sendAbroad"+i))
		{
			i++;
		}
		rentBuilding.transform.name = "sendAbroad" + i;
		rentBuilding.AddComponent<goForTrip> ();

		if (mode < 0)
		{
			rentBuilding.transform.position = new Vector3 (-20, 0, -20);
			rentBuilding.GetComponent<goForTrip>().protectionLevel=GameObject.Find("Main Camera").GetComponent<playerInterface>().protectionOfCompany;
		
			if(GameObject.Find ("Main Camera").GetComponent<playerInterface>().builedHelp[(mode*-1)-1][3]==1)
				rentBuilding.GetComponent<goForTrip> ().counterTrip2 = rentBuilding.GetComponent<goForTrip> ().whenBreakTripToNormal;
		}
		else
		{
			rentBuilding.transform.position = GameObject.Find ("hiredBuilding" + mode).transform.position;
		
			rentBuilding.GetComponent<goForTrip> ().counterTrip2 = GameObject.Find ("hiredBuilding" + mode).GetComponent<goForTrip>().counterTrip2;
		}


		badOfEvents [(mode * -1)] = 3;

		int resoTemp = 0;
		int intId=mode;
		int tempBad = 0;
		if (mode >= 0)
		{
			resoTemp=GameObject.Find ("hiredBuilding" + mode).GetComponent<goForTrip>().resources;
			tempBad=badOfEvents[mode]*1000;
			tempBad=howMuchMoneyNeedEvent[mode];
		}
		else
		{
			resoTemp=GameObject.Find("Main Camera").GetComponent<playerInterface>().resources;
			tempBad=badOfEvents[(mode*-1)]*1000;
			tempBad=howMuchMoneyNeedEvent[mode*-1];

		}
		Debug.Log (tempBad+ "Alla");
		hideEvent();

		GameObject.Find ("Main Camera").GetComponent<zipper> ().callZipper(whatEvent, 0, rentBuilding,resoTemp,intId, tempBad);
	}



	void putCameraOnCelebrate()
	{
		
		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			 
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=1;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = false;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = false;
			
			/	
			i++;
		}
		GameObject.Find ("Main Camera").GetComponent<eventSystem> ().setTimeScale (0);
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().canShowEmailsAtAll = 3;
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().showMailBox = 0;
		
		GameObject.Find ("Main Camera").GetComponent<matrixGameScript> ().letStart (1, 150);

		
	}
	
	
	void turnOffStep2()
	{

		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=0;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = true;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = true;
			
			
			i++;
		}
		Time.timeScale = 1;
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().canShowEmailsAtAll = 0;
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().showMakeSure = 3;
	
		GameObject.Find ("Main Camera").transform.position = new Vector3 (0, 20, 0);
		
		GameObject.Find ("Main Camera").GetComponent<matrixGameScript> ().letDestroy ();
	}


	int howManyHire=0,howManyHire2=0;
	float additionalHeight=0;
	RaycastHit hit2;
	Ray ray;
	float distanceEvent=0;
	GameObject whatEvent;

	public int matrixOn=0;

	public void startMatrix(GameObject matrixObject)
	{
		matrixOn=1;
		putCameraOnCelebrate();
		matrixTempObject = matrixObject;
	}

	public GameObject matrixTempObject;

	int checkingCore=0;

	int[] isRangeBigger=new int[10000];
	int[] howLongForExist = new int[10000];
	IEnumerator turnOffEvent(int howLong, int howBad, int id)
	{
		yield return new WaitForSeconds(GameObject.Find("Main Camera").GetComponent<playerInterface>().globalTimePerDay);
		int addToEvent = 1;
		isRangeBigger [id] = 1;
		if (Random.Range (0, 2) != 0)
		{
			addToEvent = -1;
			isRangeBigger[id]=2;
		}

		float tempColorA = addToEvent;
		tempColorA /= 20;
		tempColorA += GameObject.Find ("event" + id).GetComponent<MeshRenderer> ().material.color.a;


		GameObject.Find ("event" + id).GetComponent<MeshRenderer> ().material.SetColor ("_Color", new Color (1, 0, 0, tempColorA));
		
		badOfEvents [id] += addToEvent;

		if (badOfEvents [id] > 5)
		{
			badOfEvents [id] = 5;
	
		}

		if(howLong==howLongForExist[id] || badOfEvents[id]<-2)
			GameObject.Find ("event" + id).GetComponent<MeshRenderer> ().enabled = false;
		else
		{
			howLongForExist [id]++;
			StartCoroutine (turnOffEvent (howLong, howBad, id));
		}


		
	}

	Vector3 scaleOfCountry; 
	float speedOfScaling=0;
	// Update is called once per frame
	void Update () 
	{
		checkingCore = 1;
		speedOfScaling = (0.01f/GameObject.Find ("Main Camera").transform.GetComponent<playerInterface> ().globalTimePerDay)/2;
		while(GameObject.Find("event"+checkingCore))
		{
			scaleOfCountry=GameObject.Find("event"+checkingCore).transform.localScale;
			if(isRangeBigger[checkingCore]==2 && scaleOfCountry.x>=1)
				scaleOfCountry*=1-speedOfScaling;
			else if(scaleOfCountry.x<=5)
				scaleOfCountry*=1+speedOfScaling;
			GameObject.Find("event"+checkingCore).transform.localScale = scaleOfCountry;

			forWhatCourse(GameObject.Find("event"+checkingCore).transform.position,scaleOfCountry.x, checkingCore);

			checkingCore++;
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if(GameObject.Find ("Main Camera").transform.position.x>=-1f && GameObject.Find ("Main Camera").transform.position.x<=1f && GameObject.Find ("Main Camera").transform.position.x==0)
			{
			
				matrixOn=1;
				putCameraOnCelebrate();
				
			}
			else if(GameObject.Find ("Main Camera").transform.position.x>2)
			{
				matrixOn=2;
				Debug.Log("dsadsadsadsa "+GameObject.Find ("Main Camera").transform.position.x);
			
			}
		}
		
		if(matrixOn==1)
		{
		
			GameObject.Find ("Main Camera").transform.position = Vector3.MoveTowards(GameObject.Find ("Main Camera").transform.position, new Vector3(GameObject.Find ("MatrixGame").transform.position.x,20,GameObject.Find ("MatrixGame").transform.position.z), 2f);
			if(Vector3.Distance(GameObject.Find ("Main Camera").transform.position,GameObject.Find ("MatrixGame").transform.position)==20)
				GameObject.Find ("Main Camera").transform.GetComponent<matrixGameScript>().startStoper=1;

		}
		else if(matrixOn==2)
		{
			if(Vector3.Distance(GameObject.Find ("Main Camera").transform.position,new Vector3(0,20,0))>1)
				GameObject.Find ("Main Camera").transform.position = Vector3.MoveTowards(GameObject.Find ("Main Camera").transform.position, new Vector3(0,20,0), 1f);
			else
			{
				turnOffStep2();
				
				matrixOn=0;
			}
		}


		if (Input.GetMouseButtonDown(0))
		{ 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
			
				if(hit.transform.name.Length>5 && hit.transform.name.Substring(0,5)=="event")
				{
					whatEvent=hit.transform.gameObject;
					showEvent();
				}
			
			}
		}
	}
}
