using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class celebrating : MonoBehaviour {
	

	public string[] questions = new string[10000];
	public string[][] codeForAnswers = new string[10000][];

	// Use this for initialization
	void Start () 
	{
		camera = GameObject.Find ("Main Camera").transform.gameObject;
		GameObject.Find ("farAway").transform.position = new Vector3 (GameObject.Find ("farAway").transform.position.x, camera.transform.position.y, GameObject.Find ("farAway").transform.position.z);


		for(int i=0; i<10000; i++)
		{
			codeForAnswers[i]=new string[2];
			for(int i2=0; i2<2; i2++)
			{
				questions[i2] = "";
				codeForAnswers[i][i2]="";
			}
		}

		for (int i=0; i<10; i++)
		{
			whatMarked [i] = 0;
			if(i<5)
			{
				setsOfSentence[i]=new string[10][];
				actualyChecked[i]=new int[5];
				comboSentence[i] = new string[10][];
				for(int i2=0; i2<10; i2++)
				{
					setsOfSentence[i][i2]=new string[100];
					comboSentence[i][i2]=new string[100];
				}
			}
		}
		settingSentenceForAnswer ();
		setQuestions ();

		loadAndSave las = new loadAndSave ();
		celebrating intt = this.GetComponent<celebrating>();
	}

	void resaultOfConv()
	{
		int whatSide = 0;
		if (comboScore [0] > comboScore [1]) 
			whatSide=0;
		else
			whatSide=1;

		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().popularity += Random.Range (1,6)*comboScore[whatSide];
		if(comboScore[3]>0)
			GameObject.Find ("Main Camera").GetComponent<playerInterface> ().trustness += comboScore[3]*Random.Range(1,6);
		else if(comboScore[3]<0)
			GameObject.Find ("Main Camera").GetComponent<playerInterface> ().respectness += (comboScore[3]*-1)*Random.Range(1,6);
		else
		{
			GameObject.Find ("Main Camera").GetComponent<playerInterface> ().trustness += Random.Range(1,6);
			GameObject.Find ("Main Camera").GetComponent<playerInterface> ().respectness += Random.Range(1,6);
		}
		int i = 1;

		int howBigDemand = answeredDemands [0];
		int demand = 1;
		for(int i2=1; i2<3; i2++)
		{
			if(howBigDemand<answeredDemands[i2])
			{
				howBigDemand=answeredDemands[i2];
				demand=i2;
			}
		}

		while(GameObject.Find("country"+i))
		{
			if(demand==demendFromCountry[i])
				GameObject.Find("country"+i).GetComponent<howIsDoing>().coop+=Random.Range(1,6)*howBigDemand;
			i++;
		}
	}

	int[] demendFromCountry= new int[1000];


	public string[] whatCountryAbout = new string[50];
	void setQuestions()
	{
		questions [0] = "What do you think about actually situation in *?";
		questions [1] = "What do you think, what a main reason of problem in * in recent times?";
		questions [2] = "What do you think, what a main reason of problem in * in recent times?";
		questions [3] = "Do you think you did good recently?";
		questions [4] = "You had some promisses to made. You think you accomplished all of them?";

		questions [5] = "How we can avoid such problems, that had * in future?";
		questions [6] = "What is your main task to accomplished right now?";
		questions [7] = "What do you think about new goverment in the *?";
		questions [8] = "Your presents in the * is pretty strong. What about rest of the continent?";

		questions [9] = "What would you do to convinience people in order to give more money for you?";
		questions [10] = "Is there anything you want to mention?";
		questions [11] = "You started to be more popular around the world. How you do this?";
		questions [12] = "What you want to say to people who stopped sending you money whatever the reason is?";
		questions [13] = "There are some rumors about leaking money in your company. What is yours official stand by?";
		questions [14] = "The workers of your company started to complain about your treatment. Do you have any defense again it?";
		questions [15] = "How do you feel about the people you live because of you?";
		questions [16] = "How do you feel about people, that are dying all over Africa every day?";

		questions [17] = "Do you think, like some people all over the world, that sending help for Africa is pointless due to goverments, that stealing all of the money?";
		questions [18] = "Did you find any solution to avoid leaking money in process of helping?";
		questions [19] = "Is there any limit of the money your company can handle? ";
		questions [20] = "Do you suffer on lack of money? Is your company in good condition?";
		questions [21] = "Do you already know, for what you will spend money your company actually have?";
		questions [22] = "Do you enjoy helping people and are you actually happy with your life?";
		questions [23] = "What was your reaction to crisis in *?";
		questions [24] = "The 'accident' in * was on a really big scale. They are still in bad shape. Are you gonna help this country?";
		questions [25] = "The country * after your help went on the straight line. Is your company still planning to continue sending resources there?";
		questions [26] = "Sending resources and people to help are putted in risk on Africa's roads. What are you doing to protect these goods?";
		questions [27] = "There are some rummors about police invastigating your company. What is your comment about that?";
		questions [28] = "Do you have some problems with any goverment in Africa, or they are cooperating with you well?";
		questions [29] = "Are you proud of your job? Did you accomplished your goales already?";

		questions [30] = "Did attacks on your convoys was a really a problem for you?";
		questions [31] = "Handling the transport of resources has to be difficult. Do you have any good way to do it?";
		questions [32] = "It seems, country * didn't get any help for a long time. Do you think it will change in the future?";
		questions [33] = "How would you decsribe your cooperative with *?";

		for(int i =0; i<34; i++)
		{
			if(questions [i].IndexOf("*")>=0)
			{
				int randCountry = Random.Range(0,49);
				string countryName = GameObject.Find("Main Camera").GetComponent<playerInterface>().countryNames[randCountry];
				whatCountryAbout[i]=countryName;
				questions [i]=questions [i].Replace("*",countryName);
			}
		}



		codeForAnswers [0] [0] = "2020";
		codeForAnswers [1] [0] = "0100";
		codeForAnswers [2] [0] = "2300";
		codeForAnswers [3] [0] = "0001";
		codeForAnswers [4] [0] = "1234";

		codeForAnswers [5] [0] = "2020";
		codeForAnswers [6] [0] = "0100";
		codeForAnswers [7] [0] = "2300";
		codeForAnswers [8] [0] = "0001";
		codeForAnswers [9] [0] = "1234";
		codeForAnswers [10] [0] = "2020";
		codeForAnswers [11] [0] = "0100";
		codeForAnswers [12] [0] = "2300";
		codeForAnswers [13] [0] = "0001";
		codeForAnswers [14] [0] = "1234";
		codeForAnswers [15] [0] = "2020";
		codeForAnswers [16] [0] = "0100";
		codeForAnswers [17] [0] = "2300";
		codeForAnswers [18] [0] = "0001";
		codeForAnswers [19] [0] = "1234";
		codeForAnswers [20] [0] = "2020";
		codeForAnswers [21] [0] = "0100";
		codeForAnswers [22] [0] = "2300";
		codeForAnswers [23] [0] = "0001";
		codeForAnswers [24] [0] = "1234";
		codeForAnswers [25] [0] = "2020";
		codeForAnswers [26] [0] = "0100";
		codeForAnswers [27] [0] = "2300";
		codeForAnswers [28] [0] = "0001";
		codeForAnswers [29] [0] = "1234";
		codeForAnswers [30] [0] = "2020";
		codeForAnswers [31] [0] = "0100";
		codeForAnswers [32] [0] = "2300";
		codeForAnswers [33] [0] = "0001";


		codeForAnswers [0] [1] = "1021";
		codeForAnswers [1] [1] = "0301";
		codeForAnswers [2] [1] = "1101";
		codeForAnswers [3] [1] = "0001";
		codeForAnswers [4] [1] = "3121";

		codeForAnswers [5] [1] = "2021";
		codeForAnswers [6] [1] = "0101";
		codeForAnswers [7] [1] = "2301";
		codeForAnswers [8] [1] = "0002";
		codeForAnswers [9] [1] = "1231";
		codeForAnswers [10] [1] = "2010";
		codeForAnswers [11] [1] = "0101";
		codeForAnswers [12] [1] = "2301";
		codeForAnswers [13] [1] = "0002";
		codeForAnswers [14] [1] = "1231";
		codeForAnswers [15] [1] = "2021";
		codeForAnswers [16] [1] = "0101";
		codeForAnswers [17] [1] = "2301";
		codeForAnswers [18] [1] = "0002";
		codeForAnswers [19] [1] = "1231";
		codeForAnswers [20] [1] = "2021";
		codeForAnswers [21] [1] = "0101";
		codeForAnswers [22] [1] = "2301";
		codeForAnswers [23] [1] = "0002";
		codeForAnswers [24] [1] = "1231";
		codeForAnswers [25] [1] = "2021";
		codeForAnswers [26] [1] = "0101";
		codeForAnswers [27] [1] = "2301";
		codeForAnswers [28] [1] = "0002";
		codeForAnswers [29] [1] = "1231";
		codeForAnswers [30] [1] = "2021";
		codeForAnswers [31] [1] = "0102";
		codeForAnswers [32] [1] = "2301";
		codeForAnswers [33] [1] = "0003";
		
		for (int i=0; i<howManyQuestions; i++)
			alreadyPutQuestion [i] = 0;

		int i2=1;
		while(GameObject.Find ("country"+i2))
		{
			demendFromCountry[i2]=Random.Range (1,5);
			i2++;
		}
	}
	int howManyQuestions=5;
	int sideOfTalking=0;

	int[] alreadyPutQuestion=new int[1000];
	public void startConv()
	{

		putCameraOnCelebrate();

		putAnswer();
	}
	int numberOfQuestion=0;
	string[] actualCodeForAnswer = new string[2];
	int[] comboScore = new int[4]{0,0,0,0};
	int[] answeredDemands = new int[4]{0,0,0,0};
	int start=0;
	void putAnswer()
	{
		if(start!=0)
		{
			int checkIfCorrect = 0;
			if(answerCode.Length>3)
			{
				if(answerCode[3]=='1')
					answeredDemands[0]++;
				if(answerCode[3]=='2')
					answeredDemands[1]++;
				if(answerCode[3]=='3')
					answeredDemands[2]++;

				if(answerCode[1]=='1')
				{
					if(Random.Range(0,2)==0)
						comboScore[3]++;
					else
						comboScore[3]--;
				}
				else if(answerCode[1]=='2')
					comboScore[3]++;
				else if(answerCode[1]=='3')
					comboScore[3]--;

				for(int i=0; i<4; i++)
				{

					if(answerCode[i]!=actualCodeForAnswer [0][i] && actualCodeForAnswer [0][i]!='0')
					{
						checkIfCorrect=1;

					}
				}
			
				if(checkIfCorrect==0)
				{
					answer += "Good!\n";
					comboScore[0]++;
				}
				else
				{
					checkIfCorrect=0;
					for(int i=0; i<4; i++)
					{
						if(answerCode[i]!=actualCodeForAnswer [1][i] && actualCodeForAnswer [1][i]!='0')
							checkIfCorrect=1;
					}
					if(checkIfCorrect==0)
					{
						answer += "Bad!\n";
						comboScore[1]++;
					}
					else
					{
						answer += "Mhm\n";
						comboScore[2]++;
					}
				}
				Debug.Log (actualCodeForAnswer [0] + " vs " + answerCode+" by code");
			}

		}
		start=1;


		int rand;
		int tempCheck = 0;
		int tempCheck2 = 0;
		for (int i=0; i<howManyQuestions; i++) 
		{
			if(alreadyPutQuestion[i]==0)
				tempCheck2=1;
		}
		if (tempCheck2 == 1) {
			do 
			{
				tempCheck=0;
				rand = Random.Range (0, howManyQuestions);
				if (alreadyPutQuestion [rand] != 0)
					tempCheck = 1;
				else
					alreadyPutQuestion [rand] = 1;

			} while(tempCheck==1);
			answer += questions[rand]+"("+codeForAnswers[rand][0]+"/"+codeForAnswers[rand][1]+")\n";
			actualCodeForAnswer[0]=codeForAnswers[rand][0];
			actualCodeForAnswer[1]=codeForAnswers[rand][1];
			numberOfQuestion++;
		} else
			endConv ();


	}
	int finished=0;
	void endConv()
	{
		resaultOfConv ();
		answer += "End";
		Time.timeScale = 1;
		StartCoroutine(turnOffStep1 ());
		finished = 1;
	}

	int[] whatMarked = new int[10];
	int whatBracketClicked=-1;
	void OnGUI()
	{
		if(send==0)
		{
			GUI.color=Color.white;
			GUI.skin.label.fontSize=20;
			GUI.skin.label.alignment=TextAnchor.MiddleCenter;
			GUI.Label (new Rect(Screen.width*0.195f,Screen.height*0.1f-50,Screen.width*0.15f, 50),"Time");
			GUI.Box (new Rect(Screen.width*0.21f,Screen.height*0.1f,Screen.width*0.1f, Screen.height*0.2f),"");

			if(whatMarked[0]==1)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.1f,Screen.width*0.1f, Screen.height*0.05f), "Future"))
			{
				whatMarked[0]=1;
				whatBracketClicked=0;
			}

			if(whatMarked[0]==2)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.15f,Screen.width*0.1f, Screen.height*0.05f), "Now"))
			{
				whatMarked[0]=2;
				whatBracketClicked=0;
			}

			if(whatMarked[0]==3)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.2f,Screen.width*0.1f, Screen.height*0.05f), "Past"))
			{
				whatMarked[0]=3;
				whatBracketClicked=0;
			}

			if(whatMarked[0]==4)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.25f,Screen.width*0.1f, Screen.height*0.05f), "Change subject"))
			{
				whatMarked[0]=4;
				whatBracketClicked=0;
			}
			GUI.color=Color.white;

			GUI.Label (new Rect(Screen.width*0.475f,Screen.height*0.1f-50,Screen.width*0.15f, 50),"In reference");
			GUI.Box (new Rect(Screen.width*0.5f,Screen.height*0.1f,Screen.width*0.1f, Screen.height*0.2f),"");

			if(whatMarked[1]==1)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.1f,Screen.width*0.1f, Screen.height*0.05f), "Country"))
			{
				whatMarked[1]=1;
				whatBracketClicked=1;
			}
			if(whatMarked[1]==2)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.15f,Screen.width*0.1f, Screen.height*0.05f), "Company"))
			{
				whatMarked[1]=2;
				whatBracketClicked=1;
			}
			if(whatMarked[1]==3)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.2f,Screen.width*0.1f, Screen.height*0.05f), "Myself"))
			{
				whatMarked[1]=3;
				whatBracketClicked=1;
			}


			GUI.color=Color.white;

			GUI.Label (new Rect(Screen.width*0.195f,Screen.height*0.4f-50,Screen.width*0.15f, 50),"Overtone");
			GUI.Box (new Rect(Screen.width*0.21f,Screen.height*0.4f,Screen.width*0.1f, Screen.height*0.2f),"");
			if(finished==0)
			{
				if(whatMarked[2]==1)
					GUI.color=Color.green;
				else
					GUI.color=Color.white;
			}
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.4f,Screen.width*0.1f, Screen.height*0.05f), "Possitive"))
			{
				whatMarked[2]=1;
				whatBracketClicked=2;
			}
			if(finished==0)
			{
				if(whatMarked[2]==2)
					GUI.color=Color.green;
				else
					GUI.color=Color.white;
			}
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.45f,Screen.width*0.1f, Screen.height*0.05f), "Neutral"))
			{
				whatMarked[2]=2;
				whatBracketClicked=2;
			}
			if(finished==0)
			{
				if(whatMarked[2]==3)
					GUI.color=Color.green;
				else
					GUI.color=Color.white;
			}
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.21f,Screen.height*0.5f,Screen.width*0.1f, Screen.height*0.05f), "Negative"))
			{
				whatMarked[2]=3;
				whatBracketClicked=2;
			}


			GUI.color=Color.white;

			GUI.Label (new Rect(Screen.width*0.475f,Screen.height*0.4f-50,Screen.width*0.15f, 50),"About");
			GUI.Box (new Rect(Screen.width*0.5f,Screen.height*0.4f,Screen.width*0.1f, Screen.height*0.2f),"");

			if(whatMarked[3]==1)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.4f,Screen.width*0.1f, Screen.height*0.05f), "Condition"))
			{
				whatMarked[3]=1;
				whatBracketClicked=3;
			}
			if(whatMarked[3]==2)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;

			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.45f,Screen.width*0.1f, Screen.height*0.05f), "Menagment"))
			{
				whatMarked[3]=2;
				whatBracketClicked=3;
			}
			if(whatMarked[3]==3)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.5f,Screen.width*0.1f, Screen.height*0.05f), "People"))
			{
				whatMarked[3]=3;
				whatBracketClicked=3;
			}
			if(whatMarked[3]==4)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button(new Rect(Screen.width*0.5f,Screen.height*0.55f,Screen.width*0.1f, Screen.height*0.05f), "Help"))
			{
				whatMarked[3]=4;
				whatBracketClicked=3;
			}

			GUI.color=Color.white;

			Rect labelRect = GUILayoutUtility.GetRect(new GUIContent(answer+sentence), "");

			if(labelRect.height>1)
				heightOfTextArea=labelRect.height*1.5f;

			GUI.Box (new Rect(0,Screen.height*0.75f,Screen.width, Screen.height*0.25f),"");
			if(scrollTemp ==1)
				scrollPosition = GUI.BeginScrollView(new Rect(0, Screen.height*0.751f, Screen.width, Screen.height*0.25f), scrollPosition /*new Vector2(0,heightOfTextArea)*/, new Rect(0, 0, 0, heightOfTextArea));
			if(scrollTemp ==0)
				scrollPosition = GUI.BeginScrollView(new Rect(0, Screen.height*0.751f, Screen.width, Screen.height*0.25f), new Vector2(0,heightOfTextArea), new Rect(0, 0, 0, heightOfTextArea));


			GUI.skin.label.alignment=TextAnchor.UpperLeft;
			GUI.skin.label.fontSize=16;
			GUI.Label (new Rect(10,10,Screen.width-20, heightOfTextArea),answer+sentence);
			GUI.EndScrollView();
		}
	}
	public void OnDrag (PointerEventData data) 
	{
		Debug.Log("Currently dragging " + this.name);
	}

	float heightOfTextArea=0;
	string answer="";
	GameObject camera;
	int send=-1;
	Vector2 scrollPosition = Vector2.zero;
	void putCameraOnCelebrate()
	{
		send = 1;
		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=1;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = false;
	
			i++;
		}
		GameObject.Find ("Main Camera").GetComponent<eventSystem> ().setTimeScale (0);
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().canShowEmailsAtAll = 3;
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().showMailBox = 0;

		Debug.Log("thru");
			
	}

	IEnumerator turnOffStep1()
	{
		yield return new WaitForSeconds (2);
		send = 2;
		previousAnswer = new char[]{'0','0','0','0'};

	}
	void turnOffStep2()
	{

		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=0;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = true;
	
			i++;
		}
		Time.timeScale = 1;
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().canShowEmailsAtAll = 0;
		GameObject.Find ("Main Camera").GetComponent<playerInterface> ().showMakeSure = 3;
		StartCoroutine(GameObject.Find ("Main Camera").GetComponent<playerInterface> ().countDate ());

		answer = "";
		sentence = "";
	}
	string answerCode="";
	int alreadyGiven=0;



	void waitForAnswerFromAI()
	{
		answer += sentence+"\n";
		putAnswer();
		for (int i=0; i<10; i++)
			whatMarked [i] = 0;
		answerCode = "";

		sentence = "";

		alreadyGiven = 0;

	}
	string[][][] setsOfSentence=new string[5][][];
	string[] timesForSentence = new string[100];
	void settingSentenceForAnswer()
	{
		timesForSentence [0] = "will";
		timesForSentence [1] = " ";
		timesForSentence [2] = "did";

		setsOfSentence [0][0][0] = "In the future ";
		setsOfSentence [0][0][1] = "Future seems to ";
		setsOfSentence [0][0][2] = "In future days ";

		setsOfSentence [0][1][0] = "Right now ";
		setsOfSentence [0][1][1] = "Just now";
		setsOfSentence [0][1][2] = "Nowadays";
		setsOfSentence [0][1][3] = "At present";

		setsOfSentence [0][2][0] = "In past ";
		setsOfSentence [0][2][1] = "Before ";
		setsOfSentence [0][2][2] = "Yesterdays ";

		setsOfSentence [0][3][0] = "Let's talk about something else. ";

		setsOfSentence [1][0][0] = "country we are talking about is";
		setsOfSentence [1][0][1] = "mentioned country is";

		setsOfSentence [1][1][0] = "my company is";
		setsOfSentence [1][1][1] = "this organization is";

		setsOfSentence [1][2][0] = "personaly, I'm ";
		setsOfSentence [1][2][1] = "It's just... I'm ";

	


		setsOfSentence [3][0][0] = "in terms of condition";
		setsOfSentence [3][0][1] = "to make life good";

		setsOfSentence [3][1][0] = "to improve menagment";

		setsOfSentence [3][2][0] = "about this people";

		setsOfSentence [3][3][0] = "speaking about bringing help";


		comboSentence [0] [0] [0] = "will do good ";
		comboSentence [0] [0] [1] = "will do excelent ";

		comboSentence [0] [1] [0] = "will be neutral ";
		comboSentence [0] [2] [0] = "won't be good ";

		comboSentence [1] [0] [0] = "making good ";
		comboSentence [1] [1] [0] = "staying neutral ";
		comboSentence [1] [2] [0] = "harming ";

		comboSentence [2] [0] [0] = "made good ";
		comboSentence [2] [1] [0] = "was neutral ";
		comboSentence [2] [2] [0] = "didn't do anything ";


	}
	string[][][] comboSentence = new string[5] [][];

	int[][] actualyChecked = new int[5][];
	char[] previousAnswer= new char[4]{'0','0','0','0'};
	void createSentence()
	{
		answerCode=whatMarked[0]+""+whatMarked[1]+""+whatMarked[2]+""+whatMarked[3]+"";
		sentence = "";

		if(answerCode.Substring(0,4)!="0000")
		{
			for(int i=0; i<4; i++)
			{
				if (answerCode [i] == 0)
					sentence += "[...] ";
				else
				{
					int yAnswer=answerCode[i]-49;

					
					if(yAnswer<0)
						yAnswer=0;
					if(whatBracketClicked==i)
					{
						
						Debug.Log (whatBracketClicked+" vs "+yAnswer+" vs "+i);

						if(i!=2)
						{
							actualyChecked[i][yAnswer]++;
							if(setsOfSentence[i][yAnswer][actualyChecked[i][yAnswer]]==null)
								actualyChecked[i][yAnswer]=0;
							if(i==0)
							{
								for(int i2=0; i2<4; i2++)
								{
									actualyCheckedForCombo[i2]=0;
								}
							}

						}
						else 
						{
							actualyCheckedForCombo[yAnswer]++;
							int idForCombo=0;
							if(answerCode[0]=='1')
							{
								idForCombo=0;

							}
							else if(answerCode[0]=='2')
								idForCombo=1;
							else
								idForCombo=2;

							if(comboSentence[idForCombo][yAnswer][actualyCheckedForCombo[yAnswer]]==null)
								actualyCheckedForCombo[yAnswer]=0;

						}
						previousAnswer[i]=(char)answerCode[i];
					}

					if(i!=2)
						sentence += setsOfSentence[i][yAnswer][actualyChecked[i][yAnswer]]+answerCode [i]+" ";
					else
					{
						if(answerCode[0]=='1')
							sentence += comboSentence[0][yAnswer][actualyCheckedForCombo[yAnswer]]+answerCode [i]+" ";
						else if(answerCode[0]=='2')
							sentence += comboSentence[1][yAnswer][actualyCheckedForCombo[yAnswer]]+answerCode [i]+" ";
						else
							sentence += comboSentence[2][yAnswer][actualyCheckedForCombo[yAnswer]]+answerCode [i]+" ";
					}


				}
			}

		}

	}
	int[] actualyCheckedForCombo = new int[4]{0,0,0,0};
	string tempSentence="";
	string sentence="";
	// Update is called once per frame
	void Update () 
	{

		if (send == 1) {
			camera.transform.position = Vector3.MoveTowards (camera.transform.position, GameObject.Find ("farAway").transform.position, 2);
			GameObject.Find("backgroundCube").transform.localScale=new Vector3(0,0,0);

			if(GameObject.Find("backgroundForSend"))
				Destroy(GameObject.Find("backgroundForSend"));
		}
		if (send == 2) {
			camera.transform.position = Vector3.MoveTowards (camera.transform.position, GameObject.Find ("positionCamera").transform.position, 2);
			
		}
		if (Vector3.Distance (camera.transform.position, GameObject.Find ("farAway").transform.position) < 1 && send==1)
			send = 0;
		if (GameObject.Find ("positionCamera") && Vector3.Distance (camera.transform.position, GameObject.Find ("positionCamera").transform.position) < 1 && send==2)
		{
			send = -1;
			turnOffStep2();
		}
		if(finished==0)
		{

			if (Input.GetMouseButtonDown(0))
			{ 
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{

					if(alreadyGiven==0 && hit.transform.name=="character1" && whatMarked[0]!=0 && whatMarked[1]!=0 && whatMarked[2]!=0 && whatMarked[3]!=0)
					{

						alreadyGiven=1;
						waitForAnswerFromAI();
					}
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				createSentence();
				scrollTemp = 0;
			}
			if (Input.GetMouseButtonDown (0)) {
				scrollTemp = 1;
				
			}
		}

	}
	int scrollTemp=0;
}
