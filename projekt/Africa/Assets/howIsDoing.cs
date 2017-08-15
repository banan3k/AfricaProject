using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class howIsDoing : MonoBehaviour {



	public GUIStyle skinBars;
	public float heightOfHistoryBox=0.125f;
	public int[] conditionValue; // ! 0 - death rate, 1 - hunger, 2 -  condition of life!
	public int center = 101;
	public int additionalDifference=20;
	public int difficulty=1; // ! 0 - easy, 1 - normal, 2 - hard, 3 - life is INSANE
	public int maxVector=3;
	public int possibilityToEvent=10;
	public int population = 1000000;
	public int maxTaxes=2000;
	public int averagePopulationAdd=1000;
	public int possibilityToZero=20;
	public int stopZoomingOut=0;
	public int Stop=0;

	public Font fontM;

	Ray ray;
	RaycastHit hit;

	GUIStyle moneyFont;

	Vector3 force;
	Vector3 toWhatCompere;
	Vector2 scrollPosition = Vector2.zero;

	GameObject cameraPositionAtStart;
	GameObject stats, arrow;

	string[] historyText;
	string markForHappy="";

	long howMuchMoneyThisMonth=0, howMuchMoneyThisMonth2=0;
	long money=0, howRespondMoney=0, averageMonet=1000000000;

	float[] tempDiff=new float[3];
	float[] tempZ;
	float colorG=0,colorR=0, colorB=0;
	float tempStartZ;
	float labelsForBars=0.8f;
	float additionalMoney, spendMoney, taxes;
	float cameraSpeed=0.05f;
	float boxWidthAnimation=0, boxHeightAnimation=0, moneyHeightAnimation=-30;

	int[] bracket;
	int howManyCondition=3;
	int howManyEventToShow=0;
	int startZcondition=0;
	int positionYHBox=0;
	int scrollHeight=0;
	int showGUI=0;
	int sumUpX=0,sumUpY=0,sumUpZ=0;
	int howManyDays=0, howManyMonths=0;
	int heightBars=0;
	int differenceBar=0, tempDifference=0,differenceBar2=0,differenceBar3=0;
	int startY1=0,startY2=0,startY3=0;

	int limitLine=30, tempLimit=0;
	int howManyMoneyAddThisMonth=0;
	int addPopulation = 0;
	int happines=0;
	long howManyAddForPeople=0;
	int howManyPassForPeople=0;
	int sumUpPopulation2;
	int whatWayHappy=0;
	int countZoom=0;
	int howManyYears=0;
	int sumUpPopulation=0, sumUpHappy=0;
	int clickedEscapeGui=0;
	int endAnimationGui=0;
	int scrollWidth=0;
	int showInformation=0;



	
	void OnCollisionStay(Collision collision)
	{
		Debug.Log (collision.transform.name);
	}



	void election()
	{
		string addText = "", addText2="";
		int tempRand = 0;
		howRespondMoney = Random.Range (0, 4);
		int howManyPassForPeopleTemp = Random.Range (25, 75);
		float difference = howManyPassForPeopleTemp - howManyPassForPeople;
		difference/=100;
		difference *= 10;
		tempRand = (int)difference;
		if (howManyPassForPeopleTemp > howManyPassForPeople)
		{
			addText = "more";
			addText2="+";
		}
		else
		{
			addText = "less";
			addText2="";
		}
		happines += tempRand;
		howManyPassForPeople = howManyPassForPeopleTemp;
		historyText[howManyEventToShow]="There was election! \nIt seems new goverment gonna\nspend "+addText+" money for people \nPeople are "+addText+" happy.("+addText2+tempRand+")";
		whatLevelOfStory [howManyEventToShow] = 2;
	}
	int[] whatLevelOfStory = new int[10000];
	void randomizeAtStart()
	{


		stats = Instantiate(GameObject.Find ("statisticX")) as GameObject;
		stats.transform.SetParent (GameObject.Find ("Canvas").transform);
		int numberOfStatistic = 1;
		while(GameObject.Find("statistic"+numberOfStatistic))
		{
			numberOfStatistic++;
		}

		for(int i5=0; i5<10000; i5++)
			whatLevelOfStory [i5] = 0;
	
		howMuchForHelp = Random.Range (1000, 10000);
		coop = Random.Range (0, 11);
		howMuchForCoop = Random.Range (1000, 10000);
		howMuchForInf = Random.Range (1000, 10000);

		stats.transform.name = "statistic"+numberOfStatistic;

		stats.transform.GetComponent<RectTransform>().anchorMin=new Vector2(0,0);

		stats.transform.GetComponent<RectTransform>().anchorMax=new Vector2(0,0);

			stats.transform.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(this.transform.GetChild(0).transform.position);
			stats.transform.GetComponent<RectTransform>().transform.Translate(25,0,0);
			stats.SetActive(false);


		moneyFont.fontSize = 25;
		moneyFont.font = fontM;

		if(!GameObject.Find("positionCamera"))
		{
			cameraPositionAtStart = new GameObject ();
			cameraPositionAtStart.name = "positionCamera";
			cameraPositionAtStart.transform.position = GameObject.Find ("Main Camera").transform.position;
		}
		else
		{
			cameraPositionAtStart=GameObject.Find("positionCamera");
		}

		if(difficulty==1)
		{
			center-=25;
		}

		money = (long)(Random.Range (0, averageMonet+1) - (averageMonet/4));
		howRespondMoney = Random.Range (0, 4);
		howManyPassForPeople = Random.Range (25, 75);
		howMuchMoneyThisMonth = Random.Range ((int)(averageMonet*3)+1, (int)(averageMonet * 6));
		if (howMuchMoneyThisMonth < 0)
			howMuchMoneyThisMonth *= -1;

		int howBigDifference = center / howManyCondition;
		for(int i=0; i<howManyCondition-1; i++)
		{
			if(i>0)
			{
				do
				{
					conditionValue[i]=Random.Range(-center+conditionValue[i-1]+additionalDifference,center+conditionValue[i-1]+additionalDifference);
				}while(conditionValue[i]<-center || conditionValue[i]>center);
			}
			else
				conditionValue[0]=Random.Range(-center,center);
			center-=howBigDifference;
			
		}
		
		conditionValue [2] = (conditionValue [0] + conditionValue [1]) / 2;
		toWhatCompere.x = conditionValue [0];
		toWhatCompere.y = conditionValue [1];
		toWhatCompere.z = conditionValue [2];

		startZcondition = conditionValue [2];
		tempStartZ=(float)startZcondition;
		tempStartZ=(jumpZLine * (tempStartZ/100));
		tempStartZ = -startZForLine + tempStartZ;

		calculateHappy ();
	}


	void sumUpMonth()
	{
		if (sumUpHappy > happines)
			whatWayHappy = 1;
		else
			whatWayHappy = 0;
		sumUpHappy = happines;
		howManyMonths++;
		string whatConditionIs;
		if (sumUpZ > 0)
			whatConditionIs = "plus";
		else if (sumUpZ < 0)
			whatConditionIs = "minus";
		else
			whatConditionIs = "zero";
		string[] withPlus = new string[3];
		if (sumUpX > 0)
			withPlus [0] = "+";
		else
			withPlus [0] = "";
		if (sumUpY > 0)
			withPlus [1] = "+";
		else
			withPlus [1] = "";
		if (sumUpZ > 0)
			withPlus [2] = "+";
		else
			withPlus [2] = "";
		historyText[howManyEventToShow]="The month "+howManyMonths+" is on "+whatConditionIs+"!: \n "+withPlus [0]+sumUpX+": death rate\n"+withPlus [1]+sumUpY+": hunger\n"+withPlus [2]+sumUpZ+": condition of life";
		whatLevelOfStory [howManyEventToShow] = 1;
		howManyEventToShow++;

		drawLine ();

		howManyMoneyAddThisMonth = 0;
		sumUpX = 0;
		sumUpY = 0;
		sumUpZ = 0;
		howMuchMoneyThisMonth = howMuchMoneyThisMonth2;
		howMuchMoneyThisMonth2=0;
		sumUpPopulation = sumUpPopulation2;
		sumUpPopulation2 = 0;


		if (howManyMonths % 12 == 0)
			howManyYears++;
		if(howManyYears%4==0 && howManyYears!=0)
		{
			election();
		}
	}


	IEnumerator waitForStart()
	{

		int counterDate=0;
		while(counterDate<GameObject.Find("Main Camera").GetComponent<playerInterface>().globalTimePerDay)
		{
			yield return new WaitForSeconds(1);
			counterDate++;

		}

		yield return new WaitForSeconds (0);
		if (Stop == 0)
			StartCoroutine (changeVectorC ());
		else
			StartCoroutine (waitForStart ());
	}
	IEnumerator changeVectorC()
	{
		int counterDate=0;
		while(counterDate<GameObject.Find("Main Camera").GetComponent<playerInterface>().globalTimePerDay)
		{
			yield return new WaitForSeconds(1);
			counterDate++;

		}
		
		yield return new WaitForSeconds (0);
		howManyDays++;

			sumUpMonth ();
		if (Stop == 0)
			StartCoroutine (changeVectorC ());
		else
			StartCoroutine (waitForStart ());
		calculateVectorC ();
	}

	void randomEvent()
	{
		if(Random.Range(0,possibilityToEvent)==5)
		{
			int howBigEvent=Random.Range(1,5);
			if(howBigEvent>=4)
				howBigEvent=Random.Range(3,5);
			else if(howBigEvent>=3)
				howBigEvent=Random.Range(2,5);
			else if(howBigEvent>=2)
				howBigEvent=Random.Range(1,5);
			int whatKindEvent = Random.Range(0,2);
			int isItPossitive = Random.Range(0,4);
			if(isItPossitive!=0)
				howBigEvent*=-1;
			conditionValue[whatKindEvent]+=howBigEvent;
			if(whatKindEvent==0)
				force.x+=howBigEvent;
			else
				force.y+=howBigEvent;
			if(howBigEvent<0)
				historyText[howManyEventToShow]="In this country there was a sad situation: \n"+howBigEvent;
			else
				historyText[howManyEventToShow]="In this country there was a good situation: \n+"+howBigEvent;
			howManyEventToShow++;
		}
	}

	int randomBracket(int plus, int minus)
	{

		float temp = (float)plus;
		int howManyZeroP = (int)((temp / 100) * possibilityToZero);
		int howManyZeroM = possibilityToZero - howManyZeroP;
		for(int i=0; i<101; i++)
		{
			if(i<plus-howManyZeroP)
				bracket[i]=1;
			else if(i<plus)
				bracket[i]=0;
			else if(i<plus+(minus-howManyZeroM))
				bracket[i]=-1;
			else
				bracket[i]=0;
		}
		
		int rand = Random.Range (0, 100);
		rand = bracket [rand];

		return rand;
	}


	void calculateHappy()
	{
		happines=(int)((conditionValue[0]+conditionValue[1]+conditionValue[2])/3);
		float tempHappy=happines;
		tempHappy=(tempHappy+100)/200;
		tempHappy*=100;
		happines=(int)tempHappy;
	}

	void calculateMoney()
	{
		additionalMoney=conditionValue[2];
		additionalMoney+=100;
		additionalMoney/=200;
		taxes=population*maxTaxes;
		additionalMoney*=taxes;
		if(howRespondMoney==0)
			spendMoney=Random.Range (50,200);
		else if(howRespondMoney==1)
			spendMoney=Random.Range (25,150);
		else
			spendMoney=Random.Range (1,200);
		spendMoney/=100;
		spendMoney*=additionalMoney;

		float tempFloatMoney=(float)(howManyPassForPeople)/100;
		if(money>-1500000000 || (int)(additionalMoney-spendMoney)>0)
		{
			money+=(int)(additionalMoney-spendMoney);
			howMuchMoneyThisMonth2+=(int)((float)(spendMoney)*tempFloatMoney);
			howManyAddForPeople+=(int)((spendMoney)*tempFloatMoney);
		}
		if(howManyAddForPeople>howMuchMoneyThisMonth && howManyMoneyAddThisMonth<howRespondMoney+1)
		{
			howManyMoneyAddThisMonth++;
			string forWhatMoney="";
			float plus = ((float)howManyAddForPeople);
			plus/=averageMonet;
			plus*=5;
			plus=(int)plus;

			int randT=(int)plus;
			randT=Random.Range(randT-2,6);
			plus=randT;

			if(plus>10)
				plus=Random.Range(7,11);
			
			int rendTemp=Random.Range(0,3);
			conditionValue[rendTemp]+=(int)plus;
			if(rendTemp==0)
			{
				force.x+=plus/5;
				forWhatMoney="stop violence";
			}
			if(rendTemp==1)
			{
				force.y+=plus/5;
				forWhatMoney="feed people";
			}
			if(rendTemp==2)
			{
				force.z+=plus/5;
				forWhatMoney="build new place \nfor leaving";
			}
			historyText[howManyEventToShow]="Goverment spend additional\nmoney for "+forWhatMoney+" (+"+plus+")";
			whatLevelOfStory [howManyEventToShow] = 3;
			howManyEventToShow++;
			howManyAddForPeople=0;
		}

	}

	void calculatePopulation()
	{
		float tempP=conditionValue[2]-25;
		tempP/=100;
		if(tempP<0)
			tempP*=-1;
		addPopulation=population/averagePopulationAdd;
		tempP=addPopulation-(tempP*addPopulation);
		addPopulation=addPopulation-(int)tempP;
		population+=addPopulation;
		if(population<1000)
		{
			population=1000-Random.Range(0,100);
			
		}
	}

	public int addX=0, addY=0, addZ=0;
	void calculateVectorC ()
	{
		int whatSide;
		int sumOfTwo = 0;
		int addFromCompare1 = 0, addFromCompare2 = 0;
		int possibilityPlus, possibilityMinus;
		if(difficulty==1)
		{
			if(force.x>=1)
			{
				possibilityPlus=(int)(50-((force.x*16)+1));
				if(force.x==maxVector)
					possibilityPlus=0;
				possibilityMinus=100-possibilityPlus;
			}
			else if(force.x<=-1)
			{
				possibilityMinus=(int)(50+((force.x*16)-1));
				possibilityPlus=100-possibilityMinus;
			}
			else
			{
				possibilityPlus=50;
				possibilityMinus=50;
			}
			whatSide=randomBracket(possibilityPlus,possibilityMinus);
			force.x+=whatSide;

			if(force.y>=1)
			{
				possibilityPlus=(int)(50-((force.y*16)+1));
				if(force.y==maxVector)
					possibilityPlus=0;
				possibilityMinus=100-possibilityPlus;
			}
			else if(force.y<=-1)
			{
				possibilityMinus=(int)(50+((force.y*16)-1));
				possibilityPlus=100-possibilityMinus;
			}
			else
			{
				possibilityPlus=50;
				possibilityMinus=50;
			}
			whatSide=randomBracket(possibilityPlus,possibilityMinus);
			force.y+=whatSide;

			if(addX!=0)
			{
				force.x-=addX;
				addX=0;

			}
			if(addY!=0)
			{
				force.y-=addY;
				addY=0;
			}

			force.z=((force.x+force.y)/2);
			if(addZ!=0)
			{
				force.z-=addZ;
				addZ=0;
			}
			conditionValue[0]+=(int)force.x;
			conditionValue[1]+=(int)force.y;
			conditionValue[2]+=(int)force.z;

			calculateHappy();

			calculateMoney();


			calculatePopulation();


			checkPopulationCorrect();

			sumUpForce ((int)force.x,(int)force.y,(int)force.z);

			sumUpPopulation2+=addPopulation;

			colorCountry();
		
		}
	}

	void sumUpForce(int x, int y, int z)
	{
		sumUpX+=x;
		sumUpY+=y;
		sumUpZ+=z;
	}

	void checkPopulationCorrect()
	{
		if(conditionValue[0]<-100)
			conditionValue[0]=-100;
		else if(conditionValue[0]>100)
			conditionValue[0]=100;
		if(conditionValue[1]<-100)
			conditionValue[1]=-100;
		else if(conditionValue[1]>100)
			conditionValue[1]=100;
		if(conditionValue[2]<-100)
			conditionValue[2]=-100;
		else if(conditionValue[2]>100)
			conditionValue[2]=100;
	}



	void colorCountry()
	{


		if(conditionValue[2]>=0)
		{
			float temp=conditionValue[2];
			temp/=100;
			colorG=temp;
			colorB=1-colorG;
			colorR=0;
		}
		else if(conditionValue[2]<0)
		{
			float temp=conditionValue[2];
			temp/=100;
			colorR=-1*temp;
			colorB=1-colorR;
			colorG=0;
		}
		this.GetComponent<MeshRenderer>().material.color=new Color(colorR,colorG,colorB);
	}


	void turnGUI(bool mode)
	{
		if(mode==true)
		{
			Time.timeScale = 0;
			showGUI=1;
.
			Stop=1;
			int i=1;
			while(GameObject.Find("statistic"+i))
			{
				GameObject.Find("statistic"+i).GetComponent<Text>().enabled=false;

				GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=1;
				i++;
			}
			i=1;
			while(GameObject.Find("event"+i))
			{
				GameObject.Find("event"+i).GetComponent<MeshRenderer>().enabled=false;
				i++;
			}
			GameObject.Find("Main Camera").GetComponent<playerInterface>().canShowEmailsAtAll=1;
			waitForChart();
		}
		else
		{
			Time.timeScale = 1;

			showGUI=2;
			Stop=0;
			int i=1;
			clickedEscapeGui=1;
			StartCoroutine(waitForGuiClose());
			while(GameObject.Find("event"+i))
			{
				GameObject.Find("event"+i).GetComponent<MeshRenderer>().enabled=true;
				i++;
			}
			i=1;
			while(GameObject.Find("statistic"+i))
			{
				GameObject.Find("statistic"+i).GetComponent<Text>().enabled=true;

				GameObject.Find("country"+i).GetComponent<howIsDoing>().Stop=0;
				GameObject.Find("country"+i).GetComponent<howIsDoing>().stopZoomingOut=0;
				i++;
			}
			stopZoomingOut=2;
			i=1;
			while(GameObject.Find ("country"+i))
			{
				GameObject.Find ("country"+i).GetComponent<MeshRenderer>().enabled=true;
				i++;
			}
			GameObject.Find("Main Camera").GetComponent<playerInterface>().canShowEmailsAtAll=0;

			GameObject.Find("Main Camera").GetComponent<playerInterface>().restartCountingDate();
			StartCoroutine(animationForCloseGUI());

			transform.GetComponent<LineRenderer>().enabled=false;
		}
	}

	IEnumerator animationForCloseGUI()
	{
		yield return new WaitForSeconds (0.01f);
		scrollWidth = 0;

		endAnimationGui = 0;
		if(boxHeightAnimation>0)	
			boxHeightAnimation-=0.01f;
		else
		{
			boxHeightAnimation=0;
			endAnimationGui++;
		}
		if(boxWidthAnimation>0)
			boxWidthAnimation-=0.01f;
		else
		{
			boxWidthAnimation=0;
			endAnimationGui++;
		}
		if(moneyHeightAnimation>-30)
			moneyHeightAnimation-=2;
		else
		{
			moneyHeightAnimation=-30;
			endAnimationGui++;
		}
			
		if(endAnimationGui!=3)
			StartCoroutine (animationForCloseGUI ());
		else
		{
			showGUI=0;
			Debug.Log("patola");
		}

	}
	IEnumerator waitForGuiClose()
	{
		int i = 1;
		yield return new WaitForSeconds (0.25f);


	}
	void waitForChart()
	{
	
		int i = 1;
		if(Stop==1)
		{
			while(GameObject.Find ("country"+i))
			{
				if("country"+i!=this.transform.name)
					GameObject.Find ("country"+i).GetComponent<MeshRenderer>().enabled=false;
				i++;
			}

			transform.GetComponent<LineRenderer>().enabled=true;
		}
	}

	float leftForGui=0;
	int addleft=10;
	void OnGUI()
	{
	
		if(showInformation==1 && Stop==0)
		{
			if(GameObject.Find("Main Camera").GetComponent<playerInterface>().showMailBox==0)
				leftForGui=0;
			else
				leftForGui=Screen.width*0.2f;
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;
			GUI.Box(new Rect(leftForGui,(int)(Screen.height*0.75f-Screen.height*0.04),(int)(0.15*Screen.width)+20,Screen.height*0.29f),"");

			GUI.Label(new Rect(leftForGui+((int)(0.15*Screen.width)/2),(int)(Screen.height*0.75f-Screen.height*0.04),(int)(0.2*Screen.width),50), GameObject.Find("Main Camera").GetComponent<playerInterface>().countryNames[thisID-1]);
			GUI.Label(new Rect(leftForGui+addleft,(int)(Screen.height*0.75f),(int)(0.2*Screen.width),50), "Death rate : ");

			GUI.Label(new Rect(leftForGui+addleft,(int)(Screen.height*0.75f+Screen.height*0.04),(int)(0.2*Screen.width),50), "Hunger : ");
			GUI.Label(new Rect(leftForGui+addleft,(int)(Screen.height*0.75f+Screen.height*0.08),(int)(0.2*Screen.width),50), "Life Condition : ");
			GUI.Label(new Rect(leftForGui+addleft,(int)(Screen.height*0.75f+Screen.height*0.12),(int)(0.2*Screen.width),50), "Money : ");
			GUI.Label(new Rect(leftForGui+addleft,(int)(Screen.height*0.75f+Screen.height*0.16),(int)(0.2*Screen.width),50), "Happienes : ");

			GUI.skin.label.alignment=TextAnchor.MiddleRight;
			GUI.skin.label.alignment=TextAnchor.MiddleRight;
			GUI.Label(new Rect((int)(Screen.width*0.1f)+leftForGui+addleft,(int)(Screen.height*0.75),(int)(0.045f*Screen.width),50),conditionValue[0].ToString());
			GUI.Label(new Rect((int)(Screen.width*0.1f)+leftForGui+addleft,(int)((Screen.height*0.75f)+Screen.height*0.04),(int)(0.045f*Screen.width),50),conditionValue[1].ToString());
			GUI.Label(new Rect((int)(Screen.width*0.1f)+leftForGui+addleft,(int)((Screen.height*0.75f)+Screen.height*0.08),(int)(0.045f*Screen.width),50),conditionValue[2].ToString());
			GUI.Label(new Rect((int)(Screen.width*0.1f)+leftForGui+addleft-(Screen.width*0.015f),(int)((Screen.height*0.75f)+Screen.height*0.12),(int)(0.06f*Screen.width),50),(money/1000000)+" mln");
			GUI.Label(new Rect((int)(Screen.width*0.1f)+leftForGui+addleft,(int)((Screen.height*0.75f)+Screen.height*0.16),(int)(0.045f*Screen.width),50),happines+"%");
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;
		}
		if(showGUI==1 || showGUI==2)
		{
			GUI.skin.box.alignment=TextAnchor.MiddleLeft;
			GUI.skin.box.padding = new RectOffset(25,0,0,0);
			GUI.skin.button.alignment=TextAnchor.MiddleCenter;
			if(GUI.Button(new Rect(Screen.width*0.21f, 10, 50,50),"X"))
			{
				stopZoomingOut=0;
				turnGUI(false);

			}
			if(showGUI!=2)
			{
				if(boxWidthAnimation<0.2f)
				{
					boxWidthAnimation+=0.001f;
				}
				else
				{
					boxWidthAnimation=0.2f;
				}
			}
			scrollPosition = GUI.BeginScrollView(new Rect(0, 0, Screen.width*boxWidthAnimation, Screen.height), scrollPosition, new Rect(0, 0, scrollWidth, scrollHeight));
			if(scrollHeight>Screen.height)
				GUI.Box (new Rect (0, 0, Screen.width*0.2f, scrollHeight), "");
			else
				GUI.Box (new Rect (0, 0, Screen.width*0.2f, Screen.height), "");
			positionYHBox = -(int)heightOfHistoryBox;


			for (int i=0; i<howManyEventToShow; i++) 
			{
				if(whatLevelOfStory [i] <= levelOfInformation)
				{

					positionYHBox+=(int)heightOfHistoryBox;
					GUI.Box (new Rect (0, positionYHBox, Screen.width * boxWidthAnimation, heightOfHistoryBox), historyText[howManyEventToShow-1-i]);
				}
			}
		

			scrollHeight=positionYHBox+(int)heightOfHistoryBox;
			GUI.EndScrollView();


			GUI.Box (new Rect (Screen.width*0.8f+((0.2f*Screen.width)-(Screen.width*boxWidthAnimation)), 0, (int)(Screen.width*boxWidthAnimation), Screen.height), "");
			tempDiff[0]=conditionValue[0];
			if(boxWidthAnimation==0.2f)
			{
				heightBars=(int)(0.75f*(Screen.height*(conditionValue[0]+101)/200));
				if(differenceBar==0)
					differenceBar=heightBars;
				tempDifference=heightBars-differenceBar;

				if((tempDiff[0]+100)/200>=0.67f)
					GUI.backgroundColor=Color.green;
				else if((tempDiff[0]+100)/200>=0.34f)
					GUI.backgroundColor=Color.blue;
				else
					GUI.backgroundColor=Color.red;

				GUI.backgroundColor =Color.red;
				if(startY1==0)
					startY1=(int)((Screen.height/calculatedPositionOfBar)+((Screen.height/calculatedPositionOfBar2)-heightBars));

		
				GUI.Button (new Rect (Screen.width*0.85f, startY1-tempDifference, (int)(Screen.width*0.01f), heightBars+1), "");
				GUI.Label(new Rect(Screen.width*0.85f, Screen.height*labelsForBars,100,50),"Death\nrate :\n"+conditionValue[0]);

				tempDiff[1]=conditionValue[1];
				heightBars=(int)(0.75f*(Screen.height*(conditionValue[1]+101)/200));
				if(differenceBar2==0)
					differenceBar2=heightBars;
				tempDifference=heightBars-differenceBar2;
				if((tempDiff[01]+100)/200>=0.67f)
					GUI.backgroundColor=Color.green;
				else if((tempDiff[1]+100)/200>=0.34f)
					GUI.backgroundColor=Color.blue;
				else
					GUI.backgroundColor=Color.red;

				if(startY2==0)
					startY2=(int)((Screen.height/calculatedPositionOfBar)+((Screen.height/calculatedPositionOfBar2)-heightBars));

				GUI.Button (new Rect (Screen.width*0.9f, startY2-tempDifference, (int)(Screen.width*0.01f), heightBars+1), "");
				GUI.Label(new Rect(Screen.width*0.9f, Screen.height*labelsForBars,100,50),"Hunger :\n"+conditionValue[1]);

				tempDiff[2]=conditionValue[2];
				heightBars=(int)(0.75f*(Screen.height*(conditionValue[2]+101)/200));
				if(differenceBar3==0)
					differenceBar3=heightBars;
				tempDifference=heightBars-differenceBar3;
				if((tempDiff[2]+100)/200>=0.67f)
					GUI.backgroundColor=Color.green;
				else if((tempDiff[2]+100)/200>=0.34f)
					GUI.backgroundColor=Color.blue;
				else
					GUI.backgroundColor=Color.red;

				if(startY3==0)
					startY3=(int)((Screen.height/calculatedPositionOfBar)+((Screen.height/calculatedPositionOfBar2)-heightBars));

			
				GUI.Button (new Rect (Screen.width*0.95f, startY3-tempDifference, (int)(Screen.width*0.01f), heightBars+1), "");
				GUI.Label(new Rect(Screen.width*0.95f, Screen.height*labelsForBars,100,50),"Life\ncondition :\n"+conditionValue[2]);
			}
			if(showGUI!=2)
			{
				if(boxHeightAnimation<0.3f)
					boxHeightAnimation+=0.0015f;
				else
				{
					boxHeightAnimation=0.3f;
				}
			}
			GUI.Box (new Rect ((int)(Screen.width*0.2f)+1, (int)(Screen.height*0.7f+((0.3f*Screen.height)-(Screen.height*boxHeightAnimation))), (int)(Screen.width*0.6f), (int)(Screen.height*0.3)), "");

			if(boxHeightAnimation==0.3f)
			{
				GUI.skin.label.fontSize=15;

				if(sumUpPopulation>=0)
					GUI.Label(new Rect((int)(Screen.width*0.375f),(int)(Screen.height*0.93),300,35),"Population : \n"+population+" (+"+sumUpPopulation+")");
				else
					GUI.Label(new Rect((int)(Screen.width*0.375f),(int)(Screen.height*0.93),300,35),"Population : \n"+population+" ("+sumUpPopulation+")");

				if(whatWayHappy==0)
					markForHappy="+";
				else
					markForHappy="-";

				GUI.Label(new Rect((int)(Screen.width*0.475f),(int)(Screen.height*0.93),100,35),"Happienes : \n"+happines+"% ("+markForHappy+")");
				GUI.Label(new Rect((int)(Screen.width*0.575f),(int)(Screen.height*0.93),100,35),"Cooperation : \n"+coop+"%");

				GUI.Box (new Rect ((int)(Screen.width*0.25f), (int)(Screen.height*0.71f), (int)(Screen.width*0.5f), (int)(Screen.height*0.225)), "");

				GUI.Label(new Rect((int)(Screen.width*0.225f),(int)(Screen.height*0.71f-12),100,25),"+100");
				GUI.Label(new Rect((int)(Screen.width*0.235f),(int)(Screen.height*0.71f-12+(Screen.height*0.1)),100,50),"0");
				GUI.Label(new Rect((int)(Screen.width*0.225f),(int)(Screen.height*0.71f-12+(Screen.height*0.2)),100,50),"-100");
			}
			if(showGUI!=2)
			{
				if(moneyHeightAnimation<2)
					moneyHeightAnimation+=1;
				else
					moneyHeightAnimation=2;
			}

			GUI.skin.label.fontSize=15;

			GUI.Box(new Rect((int)((Screen.width*0.8f)),0,Screen.width*0.2f,moneyHeightAnimation+77),"");
			GUI.skin.label.alignment=TextAnchor.MiddleRight;
			if(money<1000000)
				GUI.Label(new Rect((int)((Screen.width*0.81f)),moneyHeightAnimation,Screen.width*0.185f,50),money.ToString()+"$");
			else
				GUI.Label(new Rect((int)((Screen.width*0.81f)),moneyHeightAnimation,Screen.width*0.185f,50),(money/1000000)+"mln/$");
			GUI.color=Color.green;
			GUI.Label(new Rect((int)((Screen.width*0.81f)),moneyHeightAnimation+30,Screen.width*0.185f,50),GameObject.Find("Main Camera").GetComponent<playerInterface>().money+"$");
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;
			GUI.Label(new Rect((int)((Screen.width*0.81f)),moneyHeightAnimation+30,Screen.width*0.2f,50),"Your money : ");
			GUI.color=Color.white;
			GUI.Label(new Rect((int)((Screen.width*0.81f)),moneyHeightAnimation,Screen.width*0.2f,50),"Goverment money : ");


			GUI.skin.label.alignment=TextAnchor.MiddleLeft;
			GUI.skin.box.alignment=TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize=12;

			GUI.backgroundColor=Color.white;
			GUI.color=Color.white;
			GUI.Box(new Rect(Screen.width*0.8f,Screen.height-75,Screen.width*0.2f,Screen.width*0.04f+25),"");

			GUI.skin.label.alignment=TextAnchor.MiddleCenter;

			if(coop<100)
			{
				if(GUI.Button (new Rect(Screen.width*0.8f,Screen.height-75,Screen.width*0.04f,Screen.width*0.04f),"CoOp"))
				{
					if(GameObject.Find("Main Camera").GetComponent<playerInterface>().money>=howMuchForCoop)
					{
						coop+=Random.Range (5,16);
						if(coop>100)
							coop=100;

						GameObject.Find("Main Camera").GetComponent<playerInterface>().money-=howMuchForCoop;
						howMuchForCoop+=Random.Range(0,10000);
					}
				}
				
				GUI.Box(new Rect(Screen.width*0.8f,Screen.height-20,Screen.width*0.04f,20),"");
				GUI.Label(new Rect(Screen.width*0.8f,Screen.height-20,Screen.width*0.04f,20),"1000$");
			}
			else
			{
				GUI.Box (new Rect(Screen.width*0.8f,Screen.height-75,Screen.width*0.04f,Screen.width*0.04f),"CoOp");
			}
			if(happines<100)
			{
				if(GUI.Button (new Rect(Screen.width*0.8f+Screen.width*0.08f,Screen.height-75,Screen.width*0.04f,Screen.width*0.04f),"Help"))
				{
					if(GameObject.Find("Main Camera").GetComponent<playerInterface>().money>=howMuchForHelp)
					{
						int help=Random.Range (0,11);
						happines+=help;
						if(happines>100)
							happines=100;

						GameObject.Find("Main Camera").GetComponent<playerInterface>().money-=howMuchForHelp;
						howMuchForHelp+=Random.Range(1000,10000);
					}
				}
				GUI.Box(new Rect(Screen.width*0.8f+Screen.width*0.08f,Screen.height-20,Screen.width*0.04f,20),"");
				GUI.Label(new Rect(Screen.width*0.8f+Screen.width*0.08f,Screen.height-20,Screen.width*0.04f,20),"1000$");
			}
			else
			{
				GUI.Box (new Rect(Screen.width*0.8f+Screen.width*0.08f,Screen.height-75,Screen.width*0.04f,Screen.width*0.04f),"Help");
			}
			if(levelOfInformation<5)
			{
				if(GUI.Button (new Rect(Screen.width*0.8f+Screen.width*0.04f,Screen.height-75,Screen.width*0.04f,Screen.width*0.04f),"Inf"))
				{
					levelOfInformation+=1;
					GameObject.Find("Main Camera").GetComponent<playerInterface>().money-=howMuchForInf;
				}
				howMuchForInf+=Random.Range(1000,10000);
			}
			else
			{
				GUI.Box	 (new Rect(Screen.width*0.8f+Screen.width*0.04f,Screen.height-75,Screen.width*0.04f,Screen.width*0.04f),"Inf");
			}
			GUI.Box(new Rect(Screen.width*0.8f+Screen.width*0.04f,Screen.height-20,Screen.width*0.04f,20),"");
			GUI.Label(new Rect(Screen.width*0.8f+Screen.width*0.04f,Screen.height-20,Screen.width*0.04f,20),"1000$");
			GUI.skin.label.alignment=TextAnchor.MiddleLeft;

		}

	}
	int howMuchForHelp;
	int howMuchForCoop;
	int howMuchForInf;
	public int coop=0;
	int levelOfInformation=0;
	float calculatedPositionOfBar=2.3f,calculatedPositionOfBar2=2.8f;
	void drawLine()
	{
		LineRenderer lineRenderer;
		if (!gameObject.GetComponent<LineRenderer> ())
		{
			lineRenderer = gameObject.AddComponent<LineRenderer> ();
			lineRenderer.enabled=false;
			lineRenderer.useWorldSpace=false;
		}
		else
			lineRenderer = gameObject.GetComponent<LineRenderer> ();

		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(Color.red, Color.red);
		lineRenderer.SetWidth(0.1F, 0.1F);

		if(howManyMonths>0)
		{
			if(howManyMonths>limitLine)
			{
				tempZ[limitLine-1] = (float)conditionValue[2];
				tempZ[limitLine-1] = (jumpZLine * (tempZ[limitLine-1] / 100));

				tempZ[howManyMonths-1] = -startYForLine + tempZ[howManyMonths-1];

				for(int i=0; i<limitLine; i++)
				{
					tempZ[i]=tempZ[i+1];
				}
				tempZ[limitLine+1]=0;
				tempLimit=limitLine;
			}
			else
			{
				tempLimit=howManyMonths+1;
				tempZ[howManyMonths-1] = (float)conditionValue[2];
				tempZ[howManyMonths-1] = (jumpZLine * (tempZ[howManyMonths-1] / 100));

				tempZ[howManyMonths-1] = -startYForLine + tempZ[howManyMonths-1];
			}

			lineRenderer.SetVertexCount(tempLimit);

			float floatI=0;
			for(int i=0; i<tempLimit; i++)
			{
				floatI=i;
			
				if(i==0)
					lineRenderer.SetPosition(0, new Vector3(-startXForLine+(floatI*0.2f),-startYForLine+addYtempOnStart,1));
				else
					lineRenderer.SetPosition(i, new Vector3(-startXForLine+(floatI*0.2f),tempZ[i-1],1));
			}
		}
		else
		{
			lineRenderer.SetVertexCount(2);



			lineRenderer.SetPosition(0, new Vector3(-startXForLine,-startYForLine+addYtempOnStart,1));
			lineRenderer.SetPosition(1, new Vector3(-startXForLine,-startYForLine+0.1f+addYtempOnStart,1));
		}
		lineRenderer.enabled = false;
	}

	float startYforLineNew=0.002f, startZforLineNew=-0.0005f;


	int thisID=0;
	void Start () 
	{
		thisID = int.Parse(this.transform.name.Substring (7, this.transform.name.Length - 7));

		Camera.main.orthographicSize = 10;
		Vector2 b = Camera.main.ScreenToWorldPoint (new Vector2(Camera.main.pixelWidth,Camera.main.pixelHeight));
		calculatedXForLine = 2.05f;
		float tempMinusX = Screen.width;
		tempMinusX=(tempMinusX-1245)/900;


		calculatedYForLine = 3.7f;
		calculatedZForLine = 5500;
		calculatedJumpForZLine = 11.1f;
		startXForLine = b.x / calculatedXForLine;
		startYForLine = b.y / calculatedYForLine;
		startZForLine = b.y / calculatedZForLine;
		jumpZLine = b.y / calculatedJumpForZLine;

		startXForLine+=tempMinusX;


		Camera.main.orthographicSize = 25;

		force = new Vector3();
		conditionValue = new int[howManyCondition];
		historyText = new string[10000];
		tempZ = new float[10000];
		bracket = new int[101];
		moneyFont = new GUIStyle ();

		force.x=0;
		force.y=0;
		force.z=0;
				
		heightOfHistoryBox *= Screen.height;
							
		randomizeAtStart ();
		colorCountry ();
		StartCoroutine (changeVectorC ());

		addYtempOnStart= conditionValue[2];
		addYtempOnStart=(jumpZLine * (addYtempOnStart / 100));

	
		if(this.transform.name=="country14")
			Debug.Log(this.transform.position+" ulozenie : " + startXForLine + " vs " + startYForLine + " vs " + Screen.width+" and "+tempMinusX);

		drawLine ();
	}
	float addYtempOnStart=0;
	float timeNew=0;
	float startXForLine=0, startZForLine=0, jumpZLine=0, startYForLine;



	void Update () 
	{

	

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit) && showGUI==0 && Camera.main.orthographicSize==25)
		{
	
			if(hit.transform.name==this.transform.name)
			{
				stats.SetActive(true);
			
				if(showInformation==0)
				{
					showInformation=1;

				}
			
			}
			else
			{
				showInformation=0;
				stats.SetActive(false);
				if(this.transform.position.y>0)
				{
				
				}
				else if(this.transform.position.y!=0)
				{
				
					showInformation=0;

				}
			}
		}
		else if(showGUI==0)
		{
			showInformation=0;
			stats.SetActive(false);
			if(this.transform.position.y>0)
			{
		
			}
			else if(this.transform.position.y!=0)
			{

			}
		}



		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if(hit.transform.name==this.transform.name && Camera.main.orthographicSize==25)
				{

					stopZoomingOut=1;
					turnGUI(true);
					Debug.Log(this.transform.name);
				
					System.Type type = hit.transform.GetComponent<LineRenderer>().GetType();
				
					GameObject clone = (GameObject)Instantiate(hit.transform.gameObject, new Vector3(0,0,0), new Quaternion(0,0,0,0));
					clone.name="wykresTemp";
					clone.transform.GetComponent<howIsDoing>().enabled=false;
					clone.transform.parent=GameObject.Find("Main Camera").transform;
					clone.transform.position=new Vector3(0,0,0);
					clone.transform.rotation=new Quaternion(0,0,0,0);
					clone.transform.localScale = new Vector3(1,1,1);
			
					cameraIsGoingToThis=hit.transform.GetChild(0).transform.position;
				
				}

			}
		}
	
		timeNew = 0.016f;

		if(stopZoomingOut==1)
		{
	
			GameObject.Find("Main Camera").transform.position=Vector3.Lerp(GameObject.Find("Main Camera").transform.position, cameraIsGoingToThis,0.1f);
			if(Camera.main.orthographicSize>10)
				Camera.main.orthographicSize-=0.5f;
		
		}
		else if(stopZoomingOut==2)
		{

			if(GameObject.Find ("Main Camera").transform.parent!=null)
				GameObject.Find ("Main Camera").transform.SetParent(null);

			GameObject.Find("Main Camera").transform.position=Vector3.Lerp(GameObject.Find("Main Camera").transform.position, cameraPositionAtStart.transform.position,0.1f);
			if(Camera.main.orthographicSize<25)
				Camera.main.orthographicSize+=0.5f;
			else
			{
				Camera.main.orthographicSize=25;
				stopZoomingOut=0;
				GameObject.Find("Main Camera").transform.position=cameraPositionAtStart.transform.position;
				Destroy(GameObject.Find("wykresTemp"));
			}
		}

	}

	Vector3 cameraIsGoingToThis;

	Transform temp;
	float calculatedXForLine=7.2f, calculatedZForLine=17.86f, calculatedJumpForZLine=60, calculatedYForLine=10;
	void setTemp(GameObject toWhat)
	{
		GameObject.Find ("Main Camera").transform.SetParent (toWhat.transform);
	}
	IEnumerator zoomCamera(GameObject toWhat, int zoom)
	{
		yield return new WaitForSeconds (0.0001f);
		countZoom++;


		float distance;
		if(zoom==0)
			distance= Vector3.Distance (GameObject.Find ("Main Camera").transform.localPosition, new Vector3(0,55,-0.25f));
		else
			distance= Vector3.Distance (GameObject.Find ("Main Camera").transform.localPosition, toWhat.transform.position);

		if(zoom==0)
		{
			GameObject.Find ("Main Camera").transform.SetParent (toWhat.transform);
			if(distance>0.05f)	
				GameObject.Find("Main Camera").transform.localPosition=Vector3.Lerp(GameObject.Find("Main Camera").transform.localPosition, new Vector3(0,55,-0.25f), Time.deltaTime * 2);

		}
		else
		{
			GameObject.Find ("Main Camera").transform.SetParent (null);
			GameObject.Find("Main Camera").transform.position=Vector3.Lerp(GameObject.Find("Main Camera").transform.localPosition, toWhat.transform.position, Time.deltaTime * 2);
		}

		if((toWhat.transform.name=="positionCamera" && stopZoomingOut==0) || toWhat.transform.name!="positionCamera")
		{
			if(showGUI==1)
			{
				if(zoom==0)
					StartCoroutine(zoomCamera(toWhat, 0));
			}
			else 
			{
				if(toWhat.transform.name=="positionCamera" && distance<=0.05f)
				{

				}
				else
					StartCoroutine(zoomCamera(cameraPositionAtStart, 1));
			}
		}


	}
}
