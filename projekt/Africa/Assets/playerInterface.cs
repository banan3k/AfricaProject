using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random=UnityEngine.Random;

[Serializable]
public class playerInterface : MonoBehaviour {


	public float globalTimePerDay=1;

	public int resources=0, maxResources=5000;
	public string[][][] messeges;
	public int[] howManyEmails;

	public int[] date=new int[3]{22,2,1994};
	public int[] startDate =new int[3]{22,2,1994};
	public int howManyDaysInMonth=31;

	public int[][] checkingLong = new int[10000][];

	public int howManyCelebreteComming=0;

	public int showMakeSure=0;
	public int idToSure=0;
	public int howManyToday = 0;
	public int[] todayEvent = new int[100];

	public string[] countryNames= new string[50];

	public string[][] stuff = new string[1000][];
	public int howManyStuff=0;
	public int[] howMuchForResponse = new int[10000];
	public int[] howLongCanWait=new int[10000]; 

	public int showMailBox=0, whatKindOfEmailsShow=0;
	public float heightForEmails=0;
	GUIStyle style;
	public int canShowEmailsAtAll=0;
	
	
	public int popularity=1, respectness=0, trustness=1;
	
	public int[] whatEmailUrgent=new int[10000000];
	
	public float calculatedNumberForPeople=1.20226f, calculatedNumberForPeople2=98.79774f;
	public int calculatedNumberForMoney=9;
	
	public int[] peopleInDayMoney=new int[32];
	public int sumOfRandomInDayPeople=0;
	public int[][] whatBuilingAlreadyHave = new int[1000][];
	public int[] howManyBuildings;
	public int[][][] canShow = new int[4][][];
	public int[][] bonusForMax=new int[4][];

	public long money=0;
	public float heightForMoney=Screen.height*0.9f;
	public int buildingPoints=0;
	public int[][] howMuchPointBuildingNeed=new int[3][];

	public int countHelp=0;
	public int[][] builedHelp = new int[1001][];

	public int powerOfHelp=0, powerOfMarket=0, powerOfMenage=0;

	public int globalIDofEmail=0, globalKindOfEmail=0;
	public int whatKindIsShowing=0;

	public int[][] canBuildBuilding = new int[3][];
	public int alreadyCalculatedHeightOfBox=0;
	public float heightOfBuildingBox=Screen.height*0.06f;
	public Vector2 scrollPosition = Vector2.zero;
	public Vector2 scrollPosition2 = Vector2.zero;
	public int whatKindOfBuildingsShow=0;
	public string[][][] buildingInformation;
	public int[][] costBuilding;
	
	public int showEmailForUser=0;
	string fromWhoCenter,subjectCenter,contentCenter,idCenter,fromWhereCenter, dataCenter;

	public int[][] protectionLevels=new int[1000][];
	public int[] whatBuildingUnlockHelp = new int[1000];
	public int[] whatHiredAirplane = new int[1000];
	public int[] powerOfHired=new int[1000];
	public int protectionOfCompany=1;
	public int[] toWhatBelongHire=new int[1000];
	public int[][][] bonusFromBuilding = new int[4][][];
	public int isBuyingRes=0;
	public int costPerUnit=5;
	public float heightOfBuildings = 0, countBuildings = 0,heightOfBuildings2=0;
	void setCountry()
	{
		countryNames [0] = "Algeria";
		countryNames [1] = "Angola";
		countryNames [2] = "Benin";
		countryNames [3] = "Botswana";
		countryNames [4] = "Burikna Faso";
		countryNames [5] = "Burundi";
		countryNames [6] = "Cameroon";
		countryNames [7] = "Central African Republic";
		countryNames [8] = "Chad";
		countryNames [9] = "Congo";

		countryNames [10] = "Cote";
		countryNames [11] = "Democratic Republic of Congo";
		countryNames [12] = "Djibouti";
		countryNames [13] = "Egypt";
		countryNames [14] = "Equatorial Guinea";
		countryNames [15] = "Eritrea";
		countryNames [16] = "Ethiopia";
		countryNames [17] = "Gabon";
		countryNames [18] = "Gambia";
		countryNames [19] = "Ghana";

		countryNames [20] = "Guinea";
		countryNames [21] = "Guinea Bissau";
		countryNames [22] = "Kenya";
		countryNames [23] = "Liberia";
		countryNames [24] = "Libya";
		countryNames [25] = "Losotho";
		countryNames [26] = "Madagaskar";
		countryNames [27] = "Malawi";
		countryNames [28] = "Mali";
		countryNames [29] = "Mauritania";

		countryNames [30] = "Morocco";
		countryNames [31] = "Mozambique";
		countryNames [32] = "Namibia";
		countryNames [33] = "Niger";
		countryNames [34] = "Nigeria";
		countryNames [35] = "Rwanda";
		countryNames [36] = "Sierra Leone";
		countryNames [37] = "Somalia";
		countryNames [38] = "South Africa";
		countryNames [39] = "Sudan";

		countryNames [40] = "Swaziland";
		countryNames [41] = "Tanzania";
		countryNames [42] = "Togo";
		countryNames [43] = "Tunisia";
		countryNames [44] = "Uganda";
		countryNames [45] = "Western Sahara";
		countryNames [46] = "Zambia";
		countryNames [47] = "Zimbabwe";
		countryNames [48] = "A9";
		countryNames [49] = "A10";

	}

	void createBackground()
	{
		GameObject.Find ("backgroundCube").GetComponent<MeshRenderer> ().enabled = true;
		int i=1;
		while (GameObject.Find("statistic"+i)) {
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = false;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = false;
			i++;
		}
	
		GameObject background = GameObject.CreatePrimitive(PrimitiveType.Cube);
		background.transform.position = new Vector3 (0, 4, 0);

		float xForBackGround = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.25f, 1, Screen.height * 0.25f)).x - Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.75f, 1, Screen.height * 0.25f)).x;
		if(xForBackGround<0)
			xForBackGround *= -1;
		float yForBackGround = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.25f, 1, Screen.height * 0.5f)).z;
		
		if(yForBackGround<0)
			yForBackGround *= -1;
	
		background.transform.localScale = new Vector3(xForBackGround,0,yForBackGround);
		Material newMat = Resources.Load("forSend", typeof(Material)) as Material;
		background.GetComponent<MeshRenderer> ().material = newMat;
		background.transform.name = "backgroundForSend";
	}

	public IEnumerator countDate()
	{

	
		int counterDate=0;
		while(counterDate<globalTimePerDay)
		{
			yield return new WaitForSeconds(1);

			counterDate++;

		}

		yield return new WaitForSeconds (0);

		int i = 0;

		howManyToday = 0;

		while(i<howManyCelebreteComming)
		{
			if (checkingLong [i][0] > 0)
				checkingLong [i][0]--;
			else if(checkingLong [i][0]==0)
			{

				if(messeges[checkingLong [i][1]][checkingLong [i][2]][6]=="3")
				{
					todayEvent[howManyToday]=i;
					howManyToday++;
					Time.timeScale=0;

					StartCoroutine(finishWaiting(1,checkingLong [i][1],checkingLong [i][2],howMuchForResponse[checkingLong [i][1]]));
					howManyCelebreteComming--;

					Debug.Log("AAAA "+checkingLong [i][0]);

				}
				else
				{
					StartCoroutine(finishWaiting(1,checkingLong [i][1],checkingLong [i][2],howMuchForResponse[checkingLong [i][1]]));
					checkingLong [i][0]=-1;
					checkingLong [i][1]=-1;
					checkingLong [i][2]=-1;
				}
		
			}
			i++;
		}
		if(howManyToday>0)
		{
			if(showMakeSure!=2 && showMakeSure!=3)
			{
				showMakeSure=1;

				Time.timeScale=0;
				if(GameObject.Find("backgroundForSend"))
					Destroy(GameObject.Find("backgroundForSend"));
				showEmailForUser=0;

				createBackground();
			}

		}
		
		if (showMakeSure == 3)
			showMakeSure = 0;


		if(canShowEmailsAtAll==0)
		{
			date [0]++;

			if(date[0]==howManyDaysInMonth+1)
			{

				for(int i2=0; i2<howManyStuff; i2++)
				{
					if(stuff[i2][3]=="1")
					{
						money-=int.Parse(stuff[i2][4]);
					}
				}

				date[0]=1;
				date[1]++;
				if(date[1]!=2)
					howManyDaysInMonth=30;
				else
				{
					if(date[2]%4==0)
						howManyDaysInMonth=29;
					else
						howManyDaysInMonth=28;
				}
				if(date[1]==13)
				{
					date[1]=1;
					sumUpMoney ();

					date[2]++;
				}
			}
			giveMoney();
		
			StartCoroutine (countDate ());
		}
	}

	void setHelp(int id)
	{
		builedHelp [countHelp][1] = id;
		switch (id)
		{
		case 1:
			builedHelp [countHelp][2] = 1;
			builedHelp [countHelp][3] = 1;
			break;
		case 3:
			builedHelp [countHelp][2] = 2;

			break;
		case 5:
			builedHelp [countHelp][2] = 4;
			break;
		case 6:
			builedHelp [countHelp][2] = 5;
			break;
		}

		countHelp++;
	}
	void unlockNewBuilding(int howMany)
	{


		buildingPoints += howMany;
		for(int i2=0; i2<2; i2++)
		{
			for(int i=0; i<howManyBuildings[i2]; i++)
			{

				if(howMuchPointBuildingNeed[i2][i]<=buildingPoints)
					canBuildBuilding[i2][i]=1;
				if(whatBuilingAlreadyHave[i2][canShow[i2][i][1]]==1)
				{
					canShow[i2][i][0]=0;
				}

			}
		}



	}

	public void restartCountingDate()
	{

		StartCoroutine (countDate ());
	}

	void setBuildings()
	{
		costBuilding = new int[3][];
		buildingInformation = new string[4][][];
		howManyBuildings=new int[3];
		for(int i=0; i<3; i++)
		{
			costBuilding[i]=new int[1000];
			buildingInformation[i]=new string[1000][];
			bonusFromBuilding[i]=new int[1000][];
			canShow[i] = new int[1000][];
			bonusForMax[i]=new int[1000];
			protectionLevels[i]=new int[1000];
			for(int i3=0; i3<1000; i3++)
			{
				whatBuildingUnlockHelp[i3]=0;
				protectionLevels[i][i3]=0;
				buildingInformation[i][i3]=new string[4];
				bonusFromBuilding[i][i3]=new int[4];
				canShow[i][i3]=new int[5];
				builedHelp[i3]=new int[5];
				bonusForMax[i][i3]=0;
				for(int i4=0; i4<4; i4++)
					canShow[i][i3][i4]=0;
				
			}
			whatBuilingAlreadyHave[i]=new int[1000];
			howMuchPointBuildingNeed[i]=new int[1000];
			canBuildBuilding[i]=new int[1000];
		}

		whatBuildingUnlockHelp [1] = 1;
		whatBuildingUnlockHelp [3] = 1;
		whatBuildingUnlockHelp [5] = 1;
		whatBuildingUnlockHelp [6] = 1;


		bonusForMax[0][1] = 1000; //making max limit of resources higher when player buy building
		bonusForMax[0][3] = 3000;

		canBuildBuilding[0][0] = 1;

		canBuildBuilding[1][0] = 1;
		canBuildBuilding[1][1] = 1;

	
		buildingInformation [0][0][0] = "Office";
		buildingInformation [0][1][0] = "Managment room";
		buildingInformation [0][2][0] = "Sharing room";
		buildingInformation [0][3][0] = "Additional level";
		buildingInformation [0][4][0] = "Parking";
		buildingInformation [0][5][0] = "Feedback team";
		buildingInformation [0][6][0] = "Airplane spot";
		buildingInformation [0][7][0] = "Building no. 2";
		buildingInformation [0][8][0] = "Complex";
		buildingInformation [0][9][0] = "Offices across Europe.";


		whatHiredAirplane [1] = 1; //is this hired building send as airplane (that means straight to destiny);

		canShow [0] [5] [0] = 1;
		canShow [0] [7] [0] = 1;
		canShow [0] [9] [0] = 1;

		canShow [0] [5] [1] = 4;
		canShow [0] [7] [1] = 5;
		canShow [0] [9] [1] = 8;

		bonusFromBuilding [0] [0] [0] = 1;
		bonusFromBuilding [0] [0] [1] = 1;
		bonusFromBuilding [0] [0] [2] = 1;

		bonusFromBuilding [0] [1] [0] = 1;
		bonusFromBuilding [0] [1] [1] = 1;
		bonusFromBuilding [0] [1] [2] = 1;

		bonusFromBuilding [0] [2] [0] = 1;
		bonusFromBuilding [0] [2] [1] = 1;
		bonusFromBuilding [0] [2] [2] = 1;

		bonusFromBuilding [0] [3] [0] = 1;
		bonusFromBuilding [0] [3] [1] = 1;
		bonusFromBuilding [0] [3] [2] = 1;

		bonusFromBuilding [0] [4] [0] = 1;
		bonusFromBuilding [0] [4] [1] = 1;
		bonusFromBuilding [0] [4] [2] = 1;

		bonusFromBuilding [0] [5] [0] = 1;
		bonusFromBuilding [0] [5] [1] = 1;
		bonusFromBuilding [0] [5] [2] = 1;

		bonusFromBuilding [0] [6] [0] = 1;
		bonusFromBuilding [0] [6] [1] = 1;
		bonusFromBuilding [0] [6] [2] = 1;

		bonusFromBuilding [0] [7] [0] = 1;
		bonusFromBuilding [0] [7] [1] = 1;
		bonusFromBuilding [0] [7] [2] = 1;

		bonusFromBuilding [0] [8] [0] = 1;
		bonusFromBuilding [0] [8] [1] = 1;
		bonusFromBuilding [0] [8] [2] = 1;

		bonusFromBuilding [0] [9] [0] = 1;
		bonusFromBuilding [0] [9] [1] = 1;
		bonusFromBuilding [0] [9] [2] = 1;

		//size of building
		buildingInformation [0][0][1] = "small";
		buildingInformation [0][1][1] = "small";
		buildingInformation [0][2][1] = "small";
		buildingInformation [0][3][1] = "medium";
		buildingInformation [0][4][1] = "medium";
		buildingInformation [0][5][1] = "medium";
		buildingInformation [0][6][1] = "medium";
		buildingInformation [0][7][1] = "medium";
		buildingInformation [0][8][1] = "big";
		buildingInformation [0][9][1] = "big";


		protectionLevels[0][3] = 1;
		protectionLevels[0][5] = 1;
		protectionLevels[0][9] = 2;

		//how long gonna build
		buildingInformation [0][0][2] = "3";
		buildingInformation [0][1][2] = "4";
		buildingInformation [0][2][2] = "5";
		buildingInformation [0][3][2] = "7";
		buildingInformation [0][4][2] = "7";
		buildingInformation [0][5][2] = "8";
		buildingInformation [0][6][2] = "9";
		buildingInformation [0][7][2] = "9";
		buildingInformation [0][8][2] = "20";
		buildingInformation [0][9][2] = "24";

		//how much gonna give for build
		buildingInformation [0][0][3] = "150";
		buildingInformation [0][1][3] = "160";
		buildingInformation [0][2][3] = "160";
		buildingInformation [0][3][3] = "250";
		buildingInformation [0][4][3] = "250";
		buildingInformation [0][5][3] = "280";
		buildingInformation [0][6][3] = "320";
		buildingInformation [0][7][3] = "250";
		buildingInformation [0][8][3] = "500";
		buildingInformation [0][9][3] = "700";

		//how much need points to build
		howMuchPointBuildingNeed [0] [0] = 150;
		howMuchPointBuildingNeed [0] [1] = 150;
		howMuchPointBuildingNeed [0] [2] = 250;
		howMuchPointBuildingNeed [0] [3] = 450;
		howMuchPointBuildingNeed [0] [4] = 500;
		howMuchPointBuildingNeed [0] [5] = 500;
		howMuchPointBuildingNeed [0] [6] = 750;
		howMuchPointBuildingNeed [0] [7] = 1000;
		howMuchPointBuildingNeed [0] [8] = 1800;
		howMuchPointBuildingNeed [0] [9] = 2000;
	

		randomizeHiredBuilding ();

		costBuilding [0][0] = 12000;
		costBuilding [0][1] = 16000;
		costBuilding [0][2] = 23532;
		costBuilding [0][3] = 43244;
		costBuilding [0][4] = 23536;
		costBuilding [0][5] = 3244;
		costBuilding [0][6] = 432623;
		costBuilding [0][7] = 243234;
		costBuilding [0][8] = 23423;
		costBuilding [0][9] = 1111911;

		int i2=0;
		while(buildingInformation[0][i2][0]!=null)
		{
			howManyBuildings[0]++;
			i2++;
			
		}
		i2 = 0;
		while(buildingInformation[1][i2][0]!=null)
		{
			howManyBuildings[1]++;
			i2++;
			
		}

		for(int i=0; i<100; i++)
		{
			stuff[i]=new string[7];
			stuff[i][3]="0";
		}
		stuff [0] [0] = "Andrew";
		stuff [0] [1] = "Marketing";
		stuff [0] [2] = "25";
		stuff [0] [4] = "2500";
		stuff [0] [5] = "10";

		stuff [1] [0] = "Szymon";
		stuff [1] [1] = "Menager";
		stuff [1] [2] = "21";
		stuff [1] [4] = "3000";
		stuff [1] [5] = "25";

		stuff [2] [0] = "Micky";
		stuff [2] [1] = "Helper";
		stuff [2] [2] = "23";
		stuff [2] [4] = "1500";
		stuff [2] [5] = "20";
		howManyStuff = 3;

	}

	void randomizeHiredBuilding()
	{
		int numberForLoop = Random.Range (10, 20);
		for(int i=0; i<numberForLoop; i++)
		{
			int whatStage=0;
			if(i<numberForLoop/3)
				whatStage=0;
			else if(i<(numberForLoop*2)/3)
				whatStage=1;
			else
				whatStage=2;
			int idTemp=Random.Range(0,48);
			buildingInformation [1][i][0] = "Rent "+countryNames[idTemp]+" office ";

			bonusForMax[1][i] = Random.Range(1,5+(whatStage*5))*1000;

			int moneyTemp=0;
			string sizeTemp="";
			if(whatStage==0)
			{
				moneyTemp=10000;
				sizeTemp="small";

			}
			else if(whatStage==1)
			{
				moneyTemp=100000;
				sizeTemp="medium";
			}
			else
			{
				moneyTemp=1000000;
				sizeTemp="big";
			}


			bonusFromBuilding [1] [i] [0] = 1;
	
			buildingInformation [1][i][1] = sizeTemp;
			buildingInformation [1][i][2] = (Random.Range(1,7*(whatStage+1))).ToString();
			buildingInformation [1][i][3] = (Random.Range(2+(3*whatStage),11+(3*whatStage))*50).ToString();//"300";

			howMuchPointBuildingNeed [1] [i] = (whatStage+1)*500;

			costBuilding [1][i] = Random.Range(moneyTemp,moneyTemp*5);

			toWhatBelongHire [i] = idTemp;

			powerOfHired [i] = whatStage+1;

			protectionLevels[1][i] = whatStage;
		}

	}


	void Start () 
	{
		setCountry ();

		globalTimePerDay = 1f;

		messeges = new string[7][][];
		howManyEmails = new int[5];

		date = startDate;
		sumUpMoney ();
		setBuildings ();

		money = Random.Range (100000, 100001);

		StartCoroutine (countDate ());
	
		for(int i=0; i<6; i++)
		{
			messeges[i] = new string[10000][];
			for(int i2=0; i2<10000; i2++)
				messeges[i][i2] = new string[7];
		}
		for(int i=0; i<5; i++)
		{
			todayEvent[i]=-1;
			howManyEmails[i]=0;
		}
		for(int i=0; i<10000; i++)
		{
			checkingLong[i]=new int[3];
			for(int i2=0; i2<3; i2++)
				checkingLong[i][i2]=-1;
		}

		addEmail (0,"Welcome", "The Creator", "Welcome. All tutorial will be delivered directly to your email",0);
		addEmail (0,"First steps", "The Creator", "In main page you can see whole situation across continent. Look closely where there is need for help. Remember to gather resources and proper buildings first!",0);
		addEmail (0,"Make no mistakes", "The Creator", "Most of the important informations you will recieve here, but you can check more detailed information by clicking any country or red ball",0);
		addEmail (0,"Be fast", "The Creator", "During sending resources you need to press some keys (shown on the bottom of the screen) sometimes. During conversation your response need on time, or it will be seems strange. Mini game is not taking any time from you tho.",0);
		addEmail (0,"Mini game", "The Creator", "In mini game, you need to to fill all cores with as many green lights as possible. Red ones should be least. Blue light need to go thru half visible cores. You can acomplished it by rotating (clicking) cores. Switching colors by pressed '1', '2' or '3' number key or click on right place marked by these colors.",0);
		addEmail (0,"Interview how to", "The Creator", "During interview, you need to build sentence to fit the question expectetions. If you won't mark enough good answers, or even worse you will mixed up everything and answer the worst mix in current question, popularity of your company can be lower as before. Watch out for your promisess too!",0);
		addEmail (0,"Welcome among great people", "Global TV","Global TV station is welcome to invite you for interview about your startup company. You will have opurtunity to say something about your goals and ways to help Africa. Hope to see you soon!",1);
		addEmail (0,"Please help", "AfricaHelp","Please send money that we need. We are waiting for ",-1);
		addEmail (1,"Senior!", "b","Welcome, if you want to send some money, just do it!",0);

	
	}
	IEnumerator t()
	{
		yield return new WaitForSeconds (1);
		GameObject.Find("Main Camera").GetComponent<celebrating>().startConv();
	}

	public void addEmail(int whatKindOfEmail, string subject, string from, string text, int kind)
	{
	
		messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]] [0] = from;
		messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]][1]=subject;

		messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]][2]=text;
		messeges [whatKindOfEmail] [howManyEmails [whatKindOfEmail]] [3] = date [0] + "/" + date [1] + "/" + date [2];
		messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]][4]=kind+"";

		Debug.Log (whatKindOfEmail + " vs " + howManyEmails [whatKindOfEmail] + " vs " + messeges [whatKindOfEmail] [howManyEmails [whatKindOfEmail]].Length);

		messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]][6]="0";
		if(kind!=0)
		{
			int howLongTemp=Random.Range(10,31);
			messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]][5]=howLongTemp+"";

			if(kind>0)
			{
				checkingLong[howManyCelebreteComming][0]=howLongTemp;
				checkingLong[howManyCelebreteComming][1]=whatKindOfEmail;
				checkingLong[howManyCelebreteComming][2]=howManyEmails[whatKindOfEmail];
				howManyCelebreteComming++;
			}
			else
			{
				howMuchForResponse[howManyEmails[whatKindOfEmail]] = Random.Range (0, 11) * 1000;
				StartCoroutine(finishWaiting(howLongTemp,whatKindOfEmail,howManyEmails[whatKindOfEmail],howMuchForResponse[howManyEmails[whatKindOfEmail]]));

				messeges[whatKindOfEmail][howManyEmails[whatKindOfEmail]][2]+=howMuchForResponse[howManyEmails[whatKindOfEmail]];
			}

		}
		howManyEmails[whatKindOfEmail]++;
	}

	IEnumerator finishWaiting(int howLong, int whatKindOfEmail,int id, int howMuchMinus)
	{

		yield return new WaitForSeconds (howLong);
		if(messeges[whatKindOfEmail][id][6]!="3")
		{
			if(int.Parse(messeges[whatKindOfEmail][id][4])>0)
				punishmentForNotResponse (1);
			else
				GameObject.Find("country"+(int.Parse(messeges[whatKindOfEmail][id][4])*-1)).GetComponent<howIsDoing>().coop+=Random.Range(1,6);
			messeges[whatKindOfEmail][id][4]=0+"";
		}
		else 
		{
			if(int.Parse (messeges[whatKindOfEmail][id][4])>0)
			{

				StartCoroutine(waitForEffect(0,2, int.Parse (messeges[whatKindOfEmail][id][4])));
			}
			else if(int.Parse (messeges[whatKindOfEmail][id][4])<0)
			{
				StartCoroutine(waitForEffect(0,2, int.Parse (messeges[whatKindOfEmail][id][4])));
				
			}
		}
		resources -= howMuchMinus;
	
		messeges [whatKindOfEmail] [id] [4] = 0 + "";
	}

	void sumUpMoney()
	{
		sumOfRandomInDayPeople = 0;
		howManyPeopleGive=(int)(Mathf.Pow(calculatedNumberForPeople,(float)popularity)+calculatedNumberForPeople2);
		for(int i=0; i<howManyDaysInMonth; i++)
		{
			peopleInDayMoney[i]=Random.Range (1,101);
			sumOfRandomInDayPeople+=peopleInDayMoney[i];
		}
		for(int i=0; i<howManyDaysInMonth; i++)
		{
			peopleInDayMoney[i]=(int)(((float)peopleInDayMoney[i]/(float)sumOfRandomInDayPeople)*(float)howManyPeopleGive);


		}


	}
	int howManyPeopleGive;

	void giveMoney()
	{
		if(money==0)
		{
			money=Random.Range(10000,100000);
		}
		else
		{
			long addMoney=0;

			long howManyGivePerPerson=0;
			howManyGivePerPerson=Random.Range(1,100+(trustness*calculatedNumberForMoney));
		
			addMoney+=howManyGivePerPerson*peopleInDayMoney[date[0]-1];
		
			money+=addMoney;
		
		}
	}

	int canClick=0;
	void OnGUI()
	{

		if(showMakeSure==1)
		{

			for(int i=0; i<howManyToday; i++)
			{
				float startLeft=0, startTop=0;
				if(i==0)
				{
				if(howManyToday>1)
					startLeft=0;
				else
					startLeft=Screen.width*0.25f;
				if(howManyToday>2)
					startTop=0;
				else
					startTop=Screen.height*0.25f;
				}
				else
				{
					if(i==1 || i==3)
					{
						startLeft+=Screen.width*0.5f;

					}
					else
						startLeft=0;
					if(i>1)
						startTop+=Screen.height*0.5f;
					else 
						startTop=0;


				}
				GUI.color = Color.black;
				GUI.skin.button.alignment=TextAnchor.MiddleCenter;
				GUI.skin.label.alignment=TextAnchor.MiddleCenter;
				GUI.skin.label.fontSize=25;
			
				GUI.Box(new Rect(startLeft,Screen.height*0.25f,Screen.width*0.5f,Screen.height*0.5f),"");
				GUI.Label(new Rect(startLeft,Screen.height*0.25f,Screen.width*0.5f,Screen.height*0.4f),"This day you schedule an event to go. Do you still want to go?");
				GUI.skin.label.fontSize=15;
				canClick=1;
				if(GUI.Button(new Rect(startLeft,startTop+Screen.height*0.4f,Screen.width*0.25f,Screen.height*0.1f),"NO"))
				{
			
					howManyToday=0;
					if(GameObject.Find("backgroundForSend"))
						Destroy(GameObject.Find("backgroundForSend"));
					messeges[checkingLong [todayEvent[i]][1]][checkingLong [todayEvent[i]][2]][6]="1";
					GameObject.Find("backgroundCube").transform.localScale=new Vector3(0,0,0);
					for(int i2=0; i2<howManyToday; i2++)
					{
						if(i2!=i)
							messeges[checkingLong [todayEvent[i2]][1]][checkingLong [todayEvent[i]][2]][6]="1";
					}
					checkingLong [todayEvent[i]][0]=-1;
					checkingLong [todayEvent[i]][1]=-1;
					checkingLong [todayEvent[i]][2]=-1;
					canClick=0;
					Time.timeScale=1;
				}
				if(GUI.Button(new Rect(startLeft+Screen.width*0.25f,startTop+Screen.height*0.4f,Screen.width*0.25f,Screen.height*0.1f), "YES"))
				{

					howManyToday=0;
					if(GameObject.Find("backgroundForSend"))
						Destroy(GameObject.Find("backgroundForSend"));
					GameObject.Find("backgroundCube").transform.localScale=new Vector3(0,0,0);
					messeges[checkingLong [todayEvent[i]][1]][checkingLong [todayEvent[i]][2]][6]="3";
					for(int i2=0; i2<howManyToday; i2++)
					{
						if(i2!=i)
							messeges[checkingLong [todayEvent[i2]][1]][checkingLong [todayEvent[i]][2]][6]="1";
					}
					checkingLong [todayEvent[i]][0]=-1;
					checkingLong [todayEvent[i]][1]=-1;
					checkingLong [todayEvent[i]][2]=-1;

					showMakeSure=2;
					Time.timeScale=1;
					canClick=0;
					
				}
				GUI.color = Color.white;
			}

		}

		GUI.skin.box.alignment = TextAnchor.MiddleLeft;
		GUI.skin.button.alignment = TextAnchor.MiddleLeft;
		GUI.skin.box.padding = new RectOffset (10, 0, 0, 0);
	
		GUI.skin.label.alignment=TextAnchor.MiddleCenter;
		GUI.skin.label.fontSize = 30;
	
		if(canShowEmailsAtAll==0)
		{

			GUI.skin.label.fontSize = 15;
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;
			GUI.Box(new Rect((int)(0.8f*Screen.width),(int)(Screen.height*0.85f),(int)(0.2f*Screen.width),Screen.height*0.15f),"");
			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.85),(int)(0.2*Screen.width),50), "Popularity : ");
			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.89),(int)(0.2*Screen.width),50), "Trustness : ");
			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.93),(int)(0.2*Screen.width),50), "Prestige : ");
			
			
			GUI.skin.label.alignment=TextAnchor.MiddleRight;
			GUI.Label(new Rect((int)(0.945f*Screen.width),(int)(Screen.height*0.85),(int)(0.045f*Screen.width),50),popularity.ToString());
			GUI.Label(new Rect((int)(0.945f*Screen.width),(int)(Screen.height*0.89),(int)(0.045f*Screen.width),50),trustness.ToString());
			GUI.Label(new Rect((int)(0.945f*Screen.width),(int)(Screen.height*0.93),(int)(0.045f*Screen.width),50),respectness.ToString());
			
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;


			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 25;
			Vector2 labelRect = GUI.skin.label.CalcSize(new GUIContent(date[0].ToString("00")+"."+date[1].ToString("00")+"."+date[2]));
		
			GUI.Label (new Rect(Screen.width/2-(labelRect.x/2),10,labelRect.x,50),date[0].ToString("00")+"."+date[1].ToString("00")+"."+date[2]);
			GUI.skin.button.fontSize=25;
			GUI.skin.button.alignment=TextAnchor.MiddleCenter;

			if(globalTimePerDay>=10)
				GUI.color=new Color(0,0.1f*(globalTimePerDay-10),0);
			else
				GUI.color=new Color(25*(10-globalTimePerDay),0,0);

			if(GUI.Button (new Rect(Screen.width/2-(labelRect.x/2)-55,10,40,40),"-"))
			{
				if(globalTimePerDay<20)
					globalTimePerDay++;

			}
			if(globalTimePerDay<=10)
				GUI.color=new Color(0,0.1f*(10-globalTimePerDay),0);
			else
				GUI.color=new Color(0.1f*(globalTimePerDay-10),0,0);
			if(GUI.Button (new Rect(Screen.width/2+(labelRect.x/2)+15,10,40,40),"+"))
			{
				if(globalTimePerDay>1)
					globalTimePerDay--;
			}
			GUI.color=Color.white;
			GUI.skin.button.alignment=TextAnchor.MiddleLeft;
			GUI.skin.button.fontSize=15;
			GUI.skin.label.fontSize = 15;
			GUI.skin.label.alignment = TextAnchor.MiddleLeft;

			GUI.skin.button.alignment=TextAnchor.MiddleCenter;

			if(showMailBox==0)
			{

				if(GUI.Button (new Rect (0, 0, 75, Screen.height*0.05f), "email >"))
				{
					showMailBox=1;

				}
			}
			else
			{
				if(GUI.Button (new Rect ((int)(Screen.width*0.21f), 0, 75, Screen.height*0.05f), "< email"))
				{
					showMailBox=0;
					turnOffEmailCenter();
				}
			}
			GUI.skin.button.alignment = TextAnchor.MiddleLeft;

		}
		if(showMailBox==1)
		{
			scrollPosition2 = GUI.BeginScrollView(new Rect(0, 0, (Screen.width*0.21f), Screen.height), scrollPosition2, new Rect(0, 0, 0, (heightForEmails+(0.1f*Screen.height))));

			if(heightForEmails+(0.1f*Screen.height)<Screen.height)
				GUI.Box(new Rect(0,0,(int)(Screen.width*0.2f),(int)Screen.height),"");
			else
				GUI.Box(new Rect(0,0,(int)(Screen.width*0.2f),heightForEmails+(0.1f*Screen.height)),"");


			if(GUI.Button(new Rect(0,0,(int)(Screen.width*0.066f),(int)Screen.height*0.05f),"Inbox"))
				whatKindOfEmailsShow=0;
			if(GUI.Button(new Rect((Screen.width*0.066f),0,(int)(Screen.width*0.066f),(int)Screen.height*0.05f),"Spam"))
				whatKindOfEmailsShow=1;
			if(GUI.Button(new Rect((Screen.width*0.066f)*2,0,(int)(Screen.width*0.067f+1),(int)Screen.height*0.05f),"Trash"))
				whatKindOfEmailsShow=2;

			for(int i=howManyEmails[whatKindOfEmailsShow]-1; i>=0; i--)
			{
				heightForEmails=(0.05f*Screen.height)+(0.1f*Screen.height)*(howManyEmails[whatKindOfEmailsShow]-i-1);
				if((messeges[whatKindOfEmailsShow][i][6]=="0" || messeges[whatKindOfEmailsShow][i][6]=="2") && messeges[whatKindOfEmailsShow][i][4]!="0")
					GUI.color=Color.yellow;
				else if(messeges[whatKindOfEmailsShow][i][6]=="1" && messeges[whatKindOfEmailsShow][i][4]!="0")
					GUI.color=Color.red;
				else if(messeges[whatKindOfEmailsShow][i][6]=="3" && messeges[whatKindOfEmailsShow][i][4]!="0")
					GUI.color=Color.green;
				else
					GUI.color=Color.white;

				if(GUI.Button(new Rect(0,heightForEmails,0.19f*Screen.width,0.1f*Screen.height), "Email "+(i+1)+" ("+messeges[whatKindOfEmailsShow][i][3]+")\nFrom :"+messeges[whatKindOfEmailsShow][i][0]+"\nSubject :"+messeges[whatKindOfEmailsShow][i][1]))
				{
					showEmail(messeges[whatKindOfEmailsShow][i][0],messeges[whatKindOfEmailsShow][i][1],messeges[whatKindOfEmailsShow][i][2], i,whatKindOfEmailsShow, messeges[whatKindOfEmailsShow][i][3]);
				}

				GUI.color=Color.red;
				if(GUI.Button(new Rect(0.19f*Screen.width+1,heightForEmails+5,10,10),""))
				{
					sendToTrash(i, whatKindOfEmailsShow);
				}
				if(whatEmailUrgent[i]==1)
					GUI.color=Color.yellow;
				else
					GUI.color=Color.white;
				if(GUI.Button(new Rect(0.19f*Screen.width+1,heightForEmails+25,10,10),""))
				{
					whatEmailUrgent[i]=1;
				}
				GUI.color=Color.white;
			}
			GUI.EndScrollView();
		}
		if(showEmailForUser==1)
		{
	
			GUI.Box(new Rect(Screen.width*0.25f,Screen.height*0.25f,Screen.width*0.5f,Screen.height*0.5f),"");

			if(GUI.Button(new Rect(0.75f*Screen.width-25,Screen.height*0.25f,25,25),"X"))
				turnOffEmailCenter();
			GUI.Box(new Rect(Screen.width*0.25f,Screen.height*0.25f+25,Screen.width*0.5f,Screen.height*0.05f),"");
			GUI.Box(new Rect(Screen.width*0.25f,Screen.height*0.3f+25,Screen.width*0.5f,Screen.height*0.05f),"");
			GUI.Box(new Rect(Screen.width*0.25f,(Screen.height*0.35f)+25,Screen.width*0.5f,Screen.height*0.4f-25),"");

			GUI.Box(new Rect(Screen.width*0.25f,Screen.height*0.7f,Screen.width*0.5f,Screen.height*0.05f),"");
			GUI.color=Color.black;
			GUI.Label(new Rect(0.25f*Screen.width+5,Screen.height*0.25f,Screen.width*0.5f,25),"Message "+idCenter+" ("+fromWhereCenter+") "+dataCenter);
			GUI.Label(new Rect(0.25f*Screen.width+5,Screen.height*0.3f,Screen.width*0.5f,25),"From : "+fromWhoCenter);
			GUI.Label(new Rect(0.25f*Screen.width+5,Screen.height*0.35f,Screen.width*0.5f,25),"Subject : "+subjectCenter);

			GUI.skin.label.alignment=TextAnchor.UpperLeft;
			GUI.skin.box.padding = new RectOffset (10, 0, 10, 0);
			GUI.Label(new Rect(0.25f*Screen.width+5,Screen.height*0.39f,Screen.width*0.5f,Screen.height*0.4f-50),contentCenter);
			GUI.color=Color.white;
			if(messeges[globalKindOfEmail][globalIDofEmail][4]!="0")
			{

				GUI.skin.button.alignment = TextAnchor.MiddleCenter;
				GUI.color = Color.red;
				if(GUI.Button(new Rect(Screen.width*0.35f,Screen.height*0.7f,Screen.width*0.1f,Screen.height*0.05f), "Reply negative"))
					reply(0,whatKindIsShowing);
				GUI.color = Color.white;
				if(GUI.Button(new Rect(Screen.width*0.45f,Screen.height*0.7f,Screen.width*0.1f,Screen.height*0.05f), "Don't answer"))
					reply(1,whatKindIsShowing);
				GUI.color = Color.green;
			    if(GUI.Button(new Rect(Screen.width*0.55f,Screen.height*0.7f,Screen.width*0.1f,Screen.height*0.05f), "Reply possitive"))
					reply(2,whatKindIsShowing);
			
			}
			GUI.color = Color.white;
		}

		if(canShowEmailsAtAll==0)
		{
			GUI.Box (new Rect((int)(Screen.width*0.8f),Screen.height*0.7f,(int)(Screen.width*0.2f),(int)(Screen.height*0.15f)),"");
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;



			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.755f),(int)(0.19f*Screen.width),25),"Resources ("+costPerUnit+"$/unity): ");
			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.805f),(int)(0.19f*Screen.width),25),"Building points: ");

			GUI.color=Color.green;
			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.71f),(int)(0.19f*Screen.width),25),"MONEY : ");
			GUI.skin.label.alignment=TextAnchor.MiddleRight;
			GUI.skin.label.fontSize=17;
			if(money>=1000000)
				GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.71f),(int)(0.17f*Screen.width),25),(money/1000000)+"$");
			else
				GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.71f),(int)(0.17f*Screen.width),25),money+"$");
			GUI.skin.label.fontSize=15;
			GUI.color=Color.white;

			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.755f),(int)(0.17f*Screen.width),25),resources+"/"+maxResources);
			GUI.skin.button.alignment=TextAnchor.MiddleCenter;
			if(isBuyingRes==1)
				GUI.color=Color.yellow;
			else if(resources>=maxResources)
				GUI.color=Color.green;
			else
				GUI.color=Color.white;
			if(GUI.Button (new Rect(0.98f*Screen.width,Screen.height*0.755f,25f,25f),"+"))
			{
				if(isBuyingRes==0)
					StartCoroutine(buyResources());
			
			}
			GUI.color=Color.white;
			GUI.skin.button.alignment=TextAnchor.MiddleLeft;
			GUI.Label(new Rect((int)(0.805f*Screen.width),(int)(Screen.height*0.805f),(int)(0.17f*Screen.width),25),buildingPoints+"");

			GUI.skin.label.alignment=TextAnchor.MiddleLeft;

			if(heightOfBuildingBox<Screen.height*0.7f && whatKindOfBuildingsShow!=0)
				heightOfBuildingBox=Screen.height*0.701f;

			scrollPosition = GUI.BeginScrollView(new Rect((int)(Screen.width*0.8f), 0, (Screen.width*0.2f), Screen.height*0.7f), scrollPosition, new Rect(0, 0, 0, (heightOfBuildingBox)));

			GUI.Box(new Rect((int)(Screen.width*0.00f),0,(int)(Screen.width*0.19f),(int)(heightOfBuildingBox)),"");

			if(GUI.Button(new Rect(0,0,(int)(Screen.width*0.063f),(int)Screen.height*0.05f),"Your company"))
			{
				whatKindOfBuildingsShow=0;
				alreadyCalculatedHeightOfBox=0;
				heightOfBuildingBox=Screen.height*0.06f;
			}
			if(GUI.Button(new Rect((0+Screen.width*0.063f),0,(int)(Screen.width*0.063f),(int)Screen.height*0.05f),"Hired places"))
			{
				whatKindOfBuildingsShow=1;
				alreadyCalculatedHeightOfBox=0;
				heightOfBuildingBox=Screen.height*0.06f;
			}
			if(GUI.Button(new Rect((0+Screen.width*0.063f*2),0,(int)(Screen.width*0.063f),(int)Screen.height*0.05f),"Stuff"))
			{
				whatKindOfBuildingsShow=2;
				alreadyCalculatedHeightOfBox=0;
				heightOfBuildingBox=Screen.height*0.06f;
			}

			GUI.Label (new Rect(Screen.width/2,Screen.height/2,100,100),buildingPoints+"");
			countBuildings=0;
			if(whatKindOfBuildingsShow!=2)
			{
				for(int i=0; i<howManyBuildings[whatKindOfBuildingsShow]; i++)
				{
					try
					{
						if(canShow[whatKindOfBuildingsShow][i][0]==1)
							{}
					}
					catch(UnityException e)
					{
						Debug.Log(whatKindOfBuildingsShow+" vs "+i);
					}
					if(canShow[whatKindOfBuildingsShow][i][0]!=1)
					{
						heightOfBuildings=((0.05f*Screen.height)+((0.11f*Screen.height)*countBuildings));
						if(alreadyCalculatedHeightOfBox==0)
						{

							heightOfBuildingBox+=(int)(0.11*Screen.height);

						}

						countBuildings+=1;
					
						GUI.skin.button.fontSize=15;
						if(canBuildBuilding[whatKindOfBuildingsShow][i]==1)
						{
							GUI.skin.button.padding=new RectOffset(5,5,5,5);
							if(whatBuilingAlreadyHave[whatKindOfBuildingsShow][i]==1)
								GUI.color=Color.green;
							else if(whatBuilingAlreadyHave[whatKindOfBuildingsShow][i]==2)
								GUI.color=Color.yellow;
							else
								GUI.color=Color.white;
							GUI.skin.label.alignment=TextAnchor.MiddleRight;
							if(GameObject.Find("hiredBuilding"+i) && whatKindOfBuildingsShow==1)
								GUI.Label (new Rect(0,heightOfBuildings,0.18f*Screen.width,0.11f*Screen.height),GameObject.Find("hiredBuilding"+i).GetComponent<goForTrip>().resources+"/"+GameObject.Find("hiredBuilding"+i).GetComponent<goForTrip>().maxResources);
							GUI.skin.label.alignment=TextAnchor.MiddleCenter;
							if(GUI.Button(new Rect(0,heightOfBuildings,0.19f*Screen.width,0.11f*Screen.height), buildingInformation[whatKindOfBuildingsShow][i][0]+"\nCost: "+costBuilding[whatKindOfBuildingsShow][i]+"\nSize: "+buildingInformation[whatKindOfBuildingsShow][i][1]+"\nHow long: "+buildingInformation[whatKindOfBuildingsShow][i][2]))
							{
					
								if(costBuilding[whatKindOfBuildingsShow][i]<money && whatBuilingAlreadyHave[whatKindOfBuildingsShow][i]!=1)
								{
									whatBuilingAlreadyHave[whatKindOfBuildingsShow][i]=2;
									StartCoroutine(startBuild(int.Parse(buildingInformation[whatKindOfBuildingsShow][i][2]),i,whatKindOfBuildingsShow));
								}
								else if(whatBuilingAlreadyHave[whatKindOfBuildingsShow][i]!=0 && whatKindOfBuildingsShow==1)
								{
									additionalResources(GameObject.Find("hiredBuilding"+i));
								}

										

							}
							GUI.color=Color.white;
						}
						else
						{
							GUI.skin.box.fontSize=15;
							GUI.Box(new Rect((int)0,heightOfBuildings,0.19f*Screen.width,0.11f*Screen.height), buildingInformation[whatKindOfBuildingsShow][i][0]+"\nCost: "+costBuilding[whatKindOfBuildingsShow][i]+" $\nSize: "+buildingInformation[whatKindOfBuildingsShow][i][1]+"\nHow long: "+buildingInformation[whatKindOfBuildingsShow][i][2]);
						}
					}




				}
			}
			else
			{
				countBuildings=0;
				for(int i=0; i<howManyStuff; i++)
				{
					heightOfBuildings=((0.05f*Screen.height)+((0.11f*Screen.height)*countBuildings));
					if(alreadyCalculatedHeightOfBox==0)
						heightOfBuildingBox+=(int)(0.11*Screen.height);
					countBuildings+=1;
					if(stuff[i][3]=="0")
					{
						GUI.color=Color.white;
						if(GUI.Button(new Rect(0,heightOfBuildings,0.19f*Screen.width,0.11f*Screen.height), "Name :"+stuff[i][0]+"  ("+stuff[i][4]+"$/per month)\nAge :"+stuff[i][2]+"\nCompetences :"+stuff[i][1]+"  ("+stuff[i][5]+")"))
						{
							if(money>=int.Parse(stuff [0] [4]))
							{
								stuff[i][3]="1";
								if(stuff[i][1]=="Helper")
									powerOfHelp+=int.Parse(stuff[i][5]);
								if(stuff[i][1]=="Menager")
									powerOfMenage+=int.Parse(stuff[i][5]);
								if(stuff[i][1]=="Marketing")
									powerOfHelp+=int.Parse(stuff[i][5]);
								Debug.Log(int.Parse(stuff[i][5]));
							
							}
							
							
						}
					}
					else if(stuff[i][3]=="1")
					{
						GUI.color=Color.green;
						if(GUI.Button(new Rect(0,heightOfBuildings,0.19f*Screen.width,0.11f*Screen.height), "Name : "+stuff[i][0]+"  ("+stuff[i][4]+"$/per month)\nAge : "+stuff[i][2]+"\nCompetences :"+stuff[i][1]+"  ("+stuff[i][5]+")"))
						{
							stuff[i][3]="0";
							money-=int.Parse(stuff [0] [4]);
							if(stuff[i][1]=="Helper")
								powerOfHelp-=int.Parse(stuff[i][5]);
							if(stuff[i][1]=="Menager")
								powerOfMenage-=int.Parse(stuff[i][5]);
							if(stuff[i][1]=="Marketing")
								powerOfHelp-=int.Parse(stuff[i][5]);
						}
						GUI.color=Color.white;
					}
				}
			}
			alreadyCalculatedHeightOfBox=1;
			GUI.EndScrollView();
		}

	}

	IEnumerator waitForEffect(int howLong, int mode, int kind)
	{

		yield return new WaitForSeconds (howLong);

		if(kind==1)
		{
			if(mode==0)
			{
				punishmentForNotResponse(1);
			}
			else if(mode==2)
			{

				Time.timeScale=0;
				GameObject.Find("Main Camera").GetComponent<celebrating>().startConv();
			}
		}
		else if(kind==0)
		{
			if(mode==0)
			{
				punishmentForNotResponse(0);
			}
			else if(mode==2)
			{
				giveSomethingForResponse();
			}
		}
		else
		{
			if(mode==0)
			{
				GameObject.Find("country"+(kind*-1)).GetComponent<howIsDoing>().coop-=Random.Range(1,6);
			}
			if(mode==2)
				GameObject.Find("country"+(kind*-1)).GetComponent<howIsDoing>().coop+=Random.Range(1,6);
		}

	}
	void punishmentForNotResponse(int howBig)
	{
		int random = Random.Range (1, 4);
		int[] whatWas = new int[5]{0,0,0,0,0};
		int i2 = 0;
		int checkTemo = 0;
		for(int i=0; i<random; i++)
		{
			
			i2=Random.Range (0,3);
			while(whatWas[i2]==1 && checkTemo<100000)
			{
				
				i2=Random.Range (0,3);
				checkTemo++;
			}
			whatWas[i2]=1;
			int bigness=0;
			if(howBig==0)
				bigness=4;
			else if(howBig==1)
				bigness=11;
			if(i2==0)
				respectness -= Random.Range (1, bigness);
			else if(i2==1)
				popularity -= Random.Range (1, bigness);
			else
				trustness -= Random.Range (1, bigness);
		}
	}
	void giveSomethingForResponse()
	{
		int random = Random.Range (1, 4);
		int[] whatWas = new int[5]{0,0,0,0,0};
		int i2 = 0;
		int checkTemo = 0;
		for(int i=0; i<random; i++)
		{

			i2=Random.Range (0,3);
			while(whatWas[i2]==1 && checkTemo<100000)
			{

				i2=Random.Range (0,3);
				checkTemo++;
			}
			whatWas[i2]=1;
			if(i2==0)
				respectness += Random.Range (1, 4);
			else if(i2==1)
				popularity += Random.Range (1, 4);
			else
				trustness += Random.Range (1, 4);
		}

	}
	void reply(int mode, int kind)
	{
		turnOffEmailCenter();
		messeges [globalKindOfEmail] [globalIDofEmail] [6] = (1+mode)+"";
	
	}
	void additionalResources(GameObject helpHired)
	{
		if(resources>=1000)
		{
			GameObject rentBuilding = GameObject.CreatePrimitive(PrimitiveType.Cube);

			rentBuilding.GetComponent<MeshFilter>().mesh =(Mesh)Resources.Load("vehicles/carModel",typeof(Mesh));

			int i = 0;
			while(GameObject.Find("helpFromAbroad"+i))
			{
				i++;
			}
			rentBuilding.transform.name = "sendAbroud" + i;
			rentBuilding.AddComponent<goForTrip> ();
			rentBuilding.transform.position = new Vector3 (-20, 0, -20);
			rentBuilding.GetComponent<goForTrip>().protectionLevel=protectionOfCompany;
			rentBuilding.GetComponent<goForTrip> ().counterTrip2 = rentBuilding.GetComponent<goForTrip> ().whenBreakTripToNormal;
			

			GameObject.Find ("Main Camera").GetComponent<zipper> ().callZipper(helpHired, 1, rentBuilding,GameObject.Find ("Main Camera").GetComponent<playerInterface> ().resources,10000,0);
		}
	}

	IEnumerator buyResources()
	{
		isBuyingRes = 1;
		yield return new WaitForSeconds (2);
		if(resources<maxResources)
		{
			resources += 1000;
			if(resources>maxResources)
				resources=maxResources;
			money -= 1000 * costPerUnit;
			addEmail(0,"Bought resources","Trade Company","Welcome, in couple of days, your company should recive resources you need",0);
		}
		isBuyingRes = 0;
	}


	IEnumerator startBuild(int howLong, int id, int whatSideBuild)
	{
		money -= costBuilding [whatSideBuild] [id];
	
		for(int i=0; i<howLong; i++)
		{
			yield return new WaitForSeconds (globalTimePerDay);
		}
		whatBuilingAlreadyHave[whatSideBuild][id]=1;
		if(whatBuildingUnlockHelp[id]==1 || whatSideBuild==1)
			setHelp (id);

		unlockNewBuilding (int.Parse(buildingInformation [whatKindOfBuildingsShow] [id] [3]));
		if(whatSideBuild==0)
		{
			if(bonusForMax[0][id]!=0)
				maxResources+=bonusForMax[0][id];
		}
		if (whatSideBuild == 1)
			hireBuilding (id);
		else
			protectionOfCompany += protectionLevels [0] [id];
		doBonusFromBuilding (id,whatSideBuild);

	}

	void hireBuilding(int id)
	{
		GameObject rentBuilding = GameObject.CreatePrimitive(PrimitiveType.Cube);
		rentBuilding.transform.name = "hiredBuilding" + id;

		rentBuilding.GetComponent<BoxCollider> ().isTrigger = true;

		rentBuilding.AddComponent<goForTrip> ();
		rentBuilding.GetComponent<goForTrip> ().power = powerOfHired[id];
		rentBuilding.GetComponent<goForTrip> ().protectionLevel = protectionLevels[1][id];

		rentBuilding.GetComponent<goForTrip> ().maxResources = bonusForMax [1] [id];

		rentBuilding.GetComponent<goForTrip>().resources = Random.Range(0,3001);
		if(whatHiredAirplane[id]==1)
			rentBuilding.GetComponent<goForTrip> ().counterTrip2 = rentBuilding.GetComponent<goForTrip> ().whenBreakTripToNormal;
		else
			rentBuilding.GetComponent<goForTrip> ().counterTrip2 = 0;
		float rand1 = Random.Range (0f, 1f);
		float rand2 = Random.Range (0f, 1f);
		rentBuilding.transform.position = new Vector3(GameObject.Find("country"+toWhatBelongHire[id]).transform.position.x+rand1,GameObject.Find("country"+toWhatBelongHire[id]).transform.position.y,GameObject.Find("country"+toWhatBelongHire[id]).transform.position.z+rand2);
	}

	void doBonusFromBuilding (int id, int whatSide)
	{
		popularity += bonusFromBuilding [whatSide] [id] [0];
		trustness += bonusFromBuilding [whatSide] [id] [1];
		respectness += bonusFromBuilding [whatSide] [id] [2];
	}


	void showEmail(string messageFromShow,string messageSubjectShow,string messageContentShow, int id, int from, string data)
	{
		if(GameObject.Find("backgroundForSend"))
			Destroy(GameObject.Find("backgroundForSend"));

		GameObject.Find ("backgroundCube").GetComponent<MeshRenderer> ().enabled = true;
		int i=1;
		while (GameObject.Find("statistic"+i)) {
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = false;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = false;
			i++;
		}
	
		fromWhoCenter = messageFromShow;
		subjectCenter = messageSubjectShow;
		contentCenter = messageContentShow;
		dataCenter = data;
		idCenter = id+"";
		if (from == 0)
			fromWhereCenter = "Inbox";
		else if (from == 1)
			fromWhereCenter = "Spam";
		else if (from == 2)
			fromWhereCenter = "Trash";
		i = 1;
		while(GameObject.Find("statistic"+i))
		{
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=1;
			i++;
		}
		GameObject background = GameObject.CreatePrimitive(PrimitiveType.Cube);
		background.transform.position = new Vector3 (0, 4, 0);

		float xForBackGround = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.25f, 1, Screen.height * 0.25f)).x - Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.75f, 1, Screen.height * 0.25f)).x;
		if(xForBackGround<0)
			xForBackGround *= -1;
		float yForBackGround = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.25f, 1, Screen.height * 0.5f)).z;

		if(yForBackGround<0)
			yForBackGround *= -1;

		Debug.Log (Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.25f, 1, Screen.height * 0.5f)).z);
		background.transform.localScale = new Vector3(xForBackGround,0,yForBackGround);
		Material newMat = Resources.Load("forSend", typeof(Material)) as Material;
		background.GetComponent<MeshRenderer> ().material = newMat;
		background.transform.name = "backgroundForSend";

		Debug.Log (messeges[from][id][4]);
		whatKindIsShowing=int.Parse(messeges[from][id][4]);
		globalIDofEmail = id;
		globalKindOfEmail = from;
		if(canClick==0)
			showEmailForUser = 1;

	}

	public void turnOffEmailCenter()
	{
		int i = 1;
		while(GameObject.Find("statistic"+i))
		{
			GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=0;
			GameObject.Find ("statistic" + i).GetComponent<Text> ().enabled = true;
			GameObject.Find ("arrow" + i).GetComponent<Image> ().enabled = true;


			i++;
		}
		showEmailForUser=0;
		Destroy(GameObject.Find("backgroundForSend"));
		GameObject.Find ("backgroundCube").GetComponent<MeshRenderer> ().enabled = false;
	}
	void sendToTrash(int id, int fromWhatType)
	{

		addEmail (2, messeges [fromWhatType] [id] [0], messeges [fromWhatType] [id] [1], messeges [fromWhatType] [id] [2],int.Parse(messeges [fromWhatType] [id] [4]));
		messeges[fromWhatType][id][0] = null;
		messeges[fromWhatType][id][1] = null;
		messeges[fromWhatType][id][2] = null;
		for(int i=id; i<howManyEmails[fromWhatType]; i++)
		{
			messeges[fromWhatType][i][0]=messeges[fromWhatType][i+1][0];
			messeges[fromWhatType][i][1]=messeges[fromWhatType][i+1][1];
			messeges[fromWhatType][i][2]=messeges[fromWhatType][i+1][2];

		}

		howManyEmails [fromWhatType]--;

	}
	int dateForSave=0, dateForLoad=0;
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		if(Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel("africa start");
		}

		if(Input.GetKey(KeyCode.F1) && dateForSave!=date[0])
		{
			loadAndSave las = new loadAndSave ();
			playerInterface intt = this.GetComponent<playerInterface>();
			las.SaveData (intt);
			dateForSave=date[0];
		}
		if(Input.GetKey(KeyCode.F2)  && dateForLoad!=date[0])
		{
			Debug.Log("ladowanie!!!");
			loadAndSave las = new loadAndSave ();
			playerInterface intt = this.GetComponent<playerInterface>();
			las.loadData (intt);
			dateForLoad=date[0];
		}

	}
}
