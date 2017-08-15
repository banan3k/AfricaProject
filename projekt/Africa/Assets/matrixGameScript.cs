using UnityEngine;
using System.Collections;

public class matrixGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		for(int i=0; i<100; i++)
		{
			haveColors[i]=new int[4];
			colorAlready[i]=new float[4];

			for(int i2=0; i2<4; i2++)
				colorAlready[i][i2]=0;


		}
		for(int i2=0; i2<divide; i2++)
			whatVisibleForce[i2]=0;


	}

	int[] whatVisibleForce = new int[100];
	int[][] alreadyPut = new int[2][];

	void setMove(int id)
	{

		isRotating[id] = 1;

	}

	public int howManyCores=25;
	GameObject[] core = new GameObject[100];


	int winningColor=0, losingColor=0, pointingColor=0;
	int[] whatCoreBonus = new int[100];


	int divide=0;

	UnityEngine.UI.Text counter;
	void setCounter()
	{
		int sizeFont = 50;

		GameObject counterObject = new GameObject();
		counter = counterObject.AddComponent<UnityEngine.UI.Text>();
		counter.text= "aaaa";
		counter.transform.parent=GameObject.Find("Canvas").transform;
		counterObject.name="counter";
		Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		counter.font = ArialFont;
		counter.fontSize=sizeFont;


		counter.rectTransform.localPosition = new Vector3(150,-sizeFont,0);

		counter.rectTransform.anchorMin = new Vector2(0, 1);
		counter.rectTransform.anchorMax = new Vector2(0, 1);
		


		counter.rectTransform.sizeDelta = new Vector2(250,100);
		counter.text = leftTime.ToString();
	}
	
	int[][] positioningOfStart=new int[2][];
	GameObject[] lightForInterface = new GameObject[3];
	public void letStart(int colorToScore, int timeForGame)
	{
		makeItStop = 0;
		timeToBackGame = 5;
		leftTime = timeForGame;

		winningColor = colorToScore;
		do
		{
			losingColor=Random.Range(0,3);
		}while(losingColor==winningColor);
		do
		{
			pointingColor=Random.Range(0,3);
		}while(pointingColor==winningColor || pointingColor==losingColor);


		whatShowing [winningColor] = 1;

		int checkExist=0;
		if(!GameObject.Find("core0"))
		{

			setCounter();

			while(divide*divide!=howManyCores)
			{
				divide++;
			}

			for(int i=0; i<divide; i++)
			{

				do
				{
					checkExist=0;
					whatCoreBonus[i]=Random.Range(0,howManyCores);
					for(int i2=0; i2<i; i2++)
					{
						if(i2!=i && whatCoreBonus[i]==whatCoreBonus[i2])
						{
							checkExist=1;
						}
					}


				}while(checkExist==1);

			}



			int level=0;
			for(int i=0; i<howManyCores; i++)
			{
				if(i%divide==0 && i>0)
					level++;

				int whatShape = Random.Range(0,3);
				if(whatShape==0)
				{
					core[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
					core[i].transform.Rotate(new Vector3(0,90*Random.Range(0,4),0));
				}
				else if(whatShape==1)
				{
					core[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					core[i].transform.Rotate(new Vector3(0,90*Random.Range(0,4),0));
				}
				else
				{
					core[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
					core[i].transform.localRotation = new Quaternion(0,0,0,0);
					core[i].transform.Rotate(new Vector3(270,90*Random.Range(0,4),0));

					core[i].GetComponent<MeshFilter>().mesh = (Mesh)Resources.Load("Triangle",typeof(Mesh));
				}

				core[i].transform.name="core"+i;
				core[i].transform.parent = GameObject.Find("MatrixGame").transform;
				core[i].transform.localPosition = new Vector3(((i%divide)-(divide/2))*1.5f,0,(((divide/2)-level)*1.5f));
				core[i].transform.localScale = new Vector3(1,1,1);


				core[i].transform.GetComponent<MeshRenderer>().material = Resources.Load("Materials/Material", typeof(Material)) as Material;



				drawShrines(i, whatShape);

			}


			alreadyPut[0]=new int[5]{-1,-1,-1,-1,-1};
			alreadyPut[1]=new int[5]{-1,-1,-1,-1,-1};
			core[howManyCores] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			core[howManyCores].transform.localRotation = new Quaternion(0,0,0,0);
	
			core[howManyCores].GetComponent<MeshFilter>().mesh = (Mesh)Resources.Load("Triangle",typeof(Mesh));
			core[howManyCores].transform.name="startCore";
			core[howManyCores].transform.parent = GameObject.Find("MatrixGame").transform;

			core[howManyCores+1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			core[howManyCores+1].transform.localRotation = new Quaternion(0,0,0,0);
			core[howManyCores+1].GetComponent<MeshFilter>().mesh = (Mesh)Resources.Load("Triangle",typeof(Mesh));
			core[howManyCores+1].transform.name="endCore";
			core[howManyCores+1].transform.parent = GameObject.Find("MatrixGame").transform;

			positioningOfStart[0]=new int[2];
			positioningOfStart[1]=new int[2];
			positioningOfStart[0][0]=Random.Range (0,4);
			do
			{
				positioningOfStart[1][0]=Random.Range(0,4);
			}while(positioningOfStart[1][0]==positioningOfStart[0][0]);
			positioningOfStart[0][1]=Random.Range(0,divide);
			positioningOfStart[1][1]=Random.Range(0,divide);

			lightForInterface[0]=GameObject.CreatePrimitive(PrimitiveType.Cube);
			lightForInterface[1]=GameObject.CreatePrimitive(PrimitiveType.Cube);
			lightForInterface[2]=GameObject.CreatePrimitive(PrimitiveType.Cube);
			lightForInterface[0].transform.localScale = new Vector3(1,1,1);
			lightForInterface[1].transform.localScale = new Vector3(1,1,1);
			lightForInterface[2].transform.localScale = new Vector3(1,1,1);
			lightForInterface[0].transform.parent = GameObject.Find("MatrixGame").transform;
			lightForInterface[1].transform.parent = GameObject.Find("MatrixGame").transform;
			lightForInterface[2].transform.parent = GameObject.Find("MatrixGame").transform;
			lightForInterface[0].transform.localPosition = new Vector3(8.5f,0,4.5f);
			lightForInterface[1].transform.localPosition = new Vector3(8.5f,0,4.1f);
			lightForInterface[2].transform.localPosition = new Vector3(8.5f,0,3.7f);
			lightForInterface[0].transform.name = "myMatrixLight1";
			lightForInterface[1].transform.name = "myMatrixLight2";
			lightForInterface[2].transform.name = "myMatrixLight3";

			lightForInterface[0].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);
			lightForInterface[1].transform.GetComponent<MeshRenderer>().material.color = new Color(0,1,0,1);
			lightForInterface[2].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);


			for(int i=0; i<2; i++)
			{
				if(positioningOfStart[i][0]==0)
				{
					core[howManyCores+i].transform.localPosition = new Vector3(((divide/2)+1)*1.5f,0,((divide/2)-positioningOfStart[i][1])*1.5f);
					core[howManyCores+i].transform.Rotate(new Vector3(270,90,0));
				}
				else if(positioningOfStart[i][0]==1)
				{
					core[howManyCores+i].transform.localPosition = new Vector3(((divide/2)+1)*1.5f*-1,0,((divide/2)-positioningOfStart[i][1])*1.5f);
					core[howManyCores+i].transform.Rotate(new Vector3(270,270,0));
				}
				else if(positioningOfStart[i][0]==2)
				{
					core[howManyCores+i].transform.localPosition = new Vector3(((divide/2)-positioningOfStart[i][1])*1.5f,0,((divide/2)+1)*1.5f);
					core[howManyCores+i].transform.Rotate(new Vector3(270,360,0));
				}
				else if(positioningOfStart[i][0]==3)
				{
					core[howManyCores+i].transform.localPosition = new Vector3(((divide/2)-positioningOfStart[i][1])*1.5f,0,((divide/2)+1)*1.5f*-1);
					core[howManyCores+i].transform.Rotate(new Vector3(270,180,0));
				}
			}

			core[howManyCores].transform.localScale = new Vector3(1,1,1);
			core[howManyCores+1].transform.localScale = new Vector3(1,1,1);


			LineRenderer lineRenderer;
			lineRenderer = core[howManyCores].AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			

			lineRenderer.SetColors(Color.white, Color.white);
			lineRenderer.SetWidth(0.5F, 0.5F);
			lineRenderer.SetVertexCount(2);


			lineRenderer.SetPosition(1, new Vector3(0,1.5f,0));

			lineRenderer = core[howManyCores+1].AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			
			
			lineRenderer.SetColors(Color.white, Color.white);
			lineRenderer.SetWidth(0.5F, 0.5F);
			lineRenderer.SetVertexCount(2);
		

			lineRenderer.SetPosition(1, new Vector3(0,1.5f,0));

		}
		setColors();
		fillArray ();
	}

	void setColors()
	{
		for(int i=0; i<howManyCores; i++)
		{
			 
			int shape=0,angle=0;
			int[] colorsOfShape = new int[4];
			if(core[i].transform.localRotation.eulerAngles.y!=0)
				angle=(int)(core[i].transform.localRotation.eulerAngles.y/90);
			else
				angle=(int)(core[i].transform.localRotation.eulerAngles.z/90);

			for(int i2=0; i2<4; i2++)
			{
				colorsOfShape[i2]=haveColors[i][i2];

			}


			core[i].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);

		}
	}

	int[] matrixArray = new int[100];
	int idStart = 0, idEnd=0;
	void fillArray()
	{
	
		if(positioningOfStart[0][0]==0)
		{
			idStart=divide*positioningOfStart[0][1]+divide-1;
		}
		else if(positioningOfStart[0][0]==1)
		{
			idStart=divide*positioningOfStart[0][1];
		}
		else if(positioningOfStart[0][0]==2)
		{
			idStart=divide-positioningOfStart[0][1]-1;
		}
		else if(positioningOfStart[0][0]==3)
		{
			idStart=howManyCores-positioningOfStart[0][1]-1;
		}

		if(positioningOfStart[1][0]==0)
		{
			idEnd=divide*positioningOfStart[1][1]+divide-1;
		}
		else if(positioningOfStart[1][0]==1)
		{
			idEnd=divide*positioningOfStart[1][1];
		}
		else if(positioningOfStart[1][0]==2)
		{
			idEnd=divide-positioningOfStart[1][1]-1;
		}
		else if(positioningOfStart[1][0]==3)
		{
			idEnd=howManyCores-positioningOfStart[1][1]-1;
		}

		filling (idStart, winningColor);
		reCheck (winningColor);

	}

	void endingGame()
	{
		float score = 0;
		makeItStop = 1;
		int[] isEndProperly = new int[3]{0,0,0};
		if ((core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.r == whiteOrBlack && winningColor == 0) || (core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.g == whiteOrBlack && winningColor == 1) || (core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.b == whiteOrBlack && winningColor == 2))
			isEndProperly [0] = 1;
		if ((core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.r == whiteOrBlack && losingColor == 0) || (core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.g == whiteOrBlack && losingColor == 1) || (core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.b == whiteOrBlack && losingColor == 2))
			isEndProperly [1] = 1;
		if ((core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.r == whiteOrBlack && pointingColor == 0) || (core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.g == whiteOrBlack && pointingColor == 1) || (core [idEnd].transform.GetComponent<MeshRenderer> ().material.color.b == whiteOrBlack && pointingColor == 2))
			isEndProperly [2] = 1;
		for(int i=0; i<howManyCores; i++)
		{

			if(isEndProperly[0]==1)
			{
				if((core[i].transform.GetComponent<MeshRenderer>().material.color.r == whiteOrBlack && winningColor==0) || (core[i].transform.GetComponent<MeshRenderer>().material.color.g == whiteOrBlack && winningColor==1) || (core[i].transform.GetComponent<MeshRenderer>().material.color.b == whiteOrBlack && winningColor==2))
				{
					score+=100;
				}
			}
			if((core[i].transform.GetComponent<MeshRenderer>().material.color.r == whiteOrBlack && losingColor==0) || (core[i].transform.GetComponent<MeshRenderer>().material.color.g == whiteOrBlack && losingColor==1) || (core[i].transform.GetComponent<MeshRenderer>().material.color.b == whiteOrBlack && losingColor==2))
			{
				if(isEndProperly[1]==0)
				{
					score-=100;
				}
				else
				{
					score-=(100*3);
				}
			}

			for(int i2=0; i2<divide; i2++)
			{
				if(whatCoreBonus[i2]==i && ((core[i].transform.GetComponent<MeshRenderer>().material.color.r == whiteOrBlack && pointingColor==0) || (core[i].transform.GetComponent<MeshRenderer>().material.color.g == whiteOrBlack && pointingColor==1) || (core[i].transform.GetComponent<MeshRenderer>().material.color.b == whiteOrBlack && pointingColor==2)))
				{
					if(isEndProperly[2]==0)
						score-=100;
					else
						score+=100;
				}
			}

		}
		int additionForComplet = 0;
		for(int i =0; i<3; i++)
		{
			if(isEndProperly[i]==1)
				additionForComplet++;
		}
		if (additionForComplet == 3)
			score += 300;

		Destroy (GameObject.Find ("counter").transform.gameObject);

		score /= ((howManyCores/2) * 100);
		Debug.Log ("and the score is :" + score);
		GameObject temp = GameObject.Find ("Main Camera").transform.GetComponent<eventSystem> ().matrixTempObject;
		temp.transform.GetComponent<goForTrip> ().resaultOfReach (score);

	}


	Vector3 returnVector(int newId, int shape, int i)
	{
		Vector3 whereToPut = new Vector3(0,0,0);

		if(core[newId].GetComponent<MeshFilter>().mesh.name[0]=='C')
		{
			if(i==0)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z-7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z+7.5f);
			}
			else if(i==1)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z+7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z-7.5f);
			}
			else if(i==2)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z-7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z+7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z);
			}
			else
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z+7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z-7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z);
			}
		}
		else if(core[newId].GetComponent<MeshFilter>().mesh.name[0]=='T')
		{
			if(i==0)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z-7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x,-10, core[newId].transform.position.z+7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z);
			}
			else if(i==1)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z+7.5f);
			}
			else
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z-7.5f);
				
				
				
				
			}
			
			
		}
		else
		{
			if(i==0)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z+7.5f);
			}
			else if(i==1)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z-7.5f);
			}
			else if(i==2)
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z+7.5f);
			}
			else
			{
				if(shape==0)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==1)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z+7.5f);
				if(shape==2)
					whereToPut = new Vector3(core[newId].transform.position.x+7.5f,-10, core[newId].transform.position.z-7.5f);
				if(shape==3)
					whereToPut = new Vector3(core[newId].transform.position.x-7.5f,-10, core[newId].transform.position.z-7.5f);
				
			}
			
			
		}

		return whereToPut;

	}

	int isFilling=0;

	Color colorWin;

	float[][] colorAlready=new float[100][];
	int whiteOrBlack = 1; //1 for white
	void filling(int id, int whatColorToWin)
	{
		isFilling++;

		if (whatColorToWin == 0)
		{
			colorWin = Color.red;
			colorAlready[id][0]=whiteOrBlack;
		}

		else if (whatColorToWin == 1)
		{
			colorWin = Color.green;
			colorAlready[id][1]=whiteOrBlack;
		}		
		else
		{
			colorWin = Color.blue;
			colorAlready[id][2]=whiteOrBlack;
		}

	

		core [id].transform.GetComponent<MeshRenderer> ().material.color = new Color (colorAlready[id][0], colorAlready[id][1], colorAlready[id][2],1); //colorWin;
	
		int idToRun = -1;
		for(int i=0; i<core[id].transform.childCount; i++)
		{
			if(haveColors[id][i]==whatColorToWin)
			{
				int shape=Mathf.FloorToInt((core[id].transform.eulerAngles.y)/90);

				RaycastHit hit2;
		
				Vector3 whereToPut = new Vector3(0,0,0);
				int newId=id;



				whereToPut=returnVector(newId,shape,i);
			


				if(Physics.SphereCast(whereToPut, 1, Vector3.up, out hit, Mathf.Infinity))
				{
					if(hit.transform.name[0]=='c')
					{
						idToRun = int.Parse(hit.transform.name.Substring(4));
						if((core[idToRun].transform.GetComponent<MeshRenderer>().material.color.r == 0 && core[idToRun].transform.GetComponent<MeshRenderer>().material.color.g==0 && core[idToRun].transform.GetComponent<MeshRenderer>().material.color.b==0)
						   || (core[idToRun].transform.GetComponent<MeshRenderer>().material.color.r != whiteOrBlack && whatColorToWin==0) || (core[idToRun].transform.GetComponent<MeshRenderer>().material.color.g != whiteOrBlack && whatColorToWin==1) || (core[idToRun].transform.GetComponent<MeshRenderer>().material.color.b != whiteOrBlack && whatColorToWin==2))
						{
							filling(idToRun, whatColorToWin);
						}

					}
				}

			}

		}

	}
 

	void reCheck(int whatColorToWin)
	{
		int[] idForNow = new int[9];
		Vector3 whereToPut= new Vector3(0,0,0);
		int idToRun = -1;
		for(int i=0; i<howManyCores; i++)
		{

			if((core[i].transform.GetComponent<MeshRenderer>().material.color.r == whiteOrBlack && whatColorToWin==0) || (core[i].transform.GetComponent<MeshRenderer>().material.color.g == whiteOrBlack && whatColorToWin==1) || (core[i].transform.GetComponent<MeshRenderer>().material.color.b == whiteOrBlack && whatColorToWin==2))
			{
				idForNow[0]=i-divide-1;
				idForNow[1]=i-divide;
				idForNow[2]=i-divide+1;
				idForNow[3]=i-1;
				idForNow[4]=i+1;
				idForNow[5]=i+divide-1;
				idForNow[6]=i+divide;
				idForNow[7]=i+divide+1;

				for(int i2=0; i2<8; i2++)
				{
					if(idForNow[i2]<0)
						idForNow[i2]=0;
					else if(idForNow[i2]>howManyCores-1)
						idForNow[i2]=howManyCores-1;

					int shape=Mathf.FloorToInt((core[idForNow[i2]].transform.eulerAngles.y)/90);
					for(int i3=0; i3<core[idForNow[i2]].transform.childCount; i3++)
					{
						if(haveColors[idForNow[i2]][i3]==whatColorToWin)
						{
							whereToPut=returnVector(idForNow[i2],shape,i3);

							if(Physics.SphereCast(whereToPut, 1, Vector3.up, out hit, Mathf.Infinity))
							{

								if(hit.transform.name[0]=='c')
								{
									idToRun = int.Parse(hit.transform.name.Substring(4));
									

									if(hit.transform.name==core[i].transform.name)
									{
										if((core[idForNow[i2]].transform.GetComponent<MeshRenderer>().material.color.r == 0 && core[idForNow[i2]].transform.GetComponent<MeshRenderer>().material.color.g==0 && core[idForNow[i2]].transform.GetComponent<MeshRenderer>().material.color.b==0)
										   || (core[idForNow[i2]].transform.GetComponent<MeshRenderer>().material.color.r != whiteOrBlack && whatColorToWin==0) || (core[idForNow[i2]].transform.GetComponent<MeshRenderer>().material.color.g != whiteOrBlack && whatColorToWin==1) || (core[idForNow[i2]].transform.GetComponent<MeshRenderer>().material.color.b != whiteOrBlack && whatColorToWin==2))
										{
										
											filling(idForNow[i2], whatColorToWin);
										}
									}
									
								}
							}
						}


					}
				}
			}
		}
	}


	int[][] haveColors = new int[100][];
	void drawShrines(int id, int shape)
	{
		LineRenderer lineRenderer;

		int[] colors = new int[4];
		for (int i=0; i<4; i++)
			colors [i] = 0;

		Color[] color = new Color[4];
		color [0] = Color.red;
		color [1] = Color.green;
		color [2] = Color.blue;
		color [3] = Color.magenta;

		int whatChoosed = 0;
		if(shape==0)
		{
			GameObject lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][0]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);

			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(1.5f,5,0));

			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][1]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(-1.5f,5,0));

			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][2]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(0,5,-1.5f));


			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][3]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(0,5,1.5f));


		}
		else if(shape==1)
		{
			GameObject lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][0]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);

			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(1.5f,5,1.5f));

			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][1]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);

			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(-1.5f,5,-1.5f));


			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][2]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(1.5f,5,-1.5f));

			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,4);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][3]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,5,0));
			lineRenderer.SetPosition(1, new Vector3(-1.5f,5,1.5f));


		}
		else
		{
			GameObject lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,3);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][0]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,0,5));
			lineRenderer.SetPosition(1, new Vector3(0,1.5f,5));

			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,3);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][1]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,0,5));
			lineRenderer.SetPosition(1, new Vector3(1.5f,-1.5f,5));


			lineForShape = new GameObject ();
			lineForShape.transform.parent = core [id].transform;
			lineRenderer = lineForShape.AddComponent<LineRenderer> ();
			lineRenderer.enabled=true;
			lineRenderer.useWorldSpace=false;
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			do
			{
				whatChoosed=Random.Range(0,3);
			}while(colors[whatChoosed]==1);

			colors[whatChoosed]=1;
			if(whatChoosed==3)
				whatChoosed=Random.Range(0,3);
			haveColors[id][2]=whatChoosed;
			lineRenderer.SetColors(color[whatChoosed],color[whatChoosed]);
			lineRenderer.SetWidth(0.5F, 0.5F);
			
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, new Vector3(0,0,5));
			lineRenderer.SetPosition(1, new Vector3(-1.5f,-1.5f,5));


		}
		for(int i=0; i<core[id].transform.childCount; i++)
		{
			core[id].transform.GetChild(i).transform.localScale=new Vector3(1,1,1);

			core[id].transform.GetChild(i).transform.localPosition=new Vector3(0,0,0);

			core[id].transform.GetChild(i).transform.localRotation= new Quaternion(0,0,0,0);



			core[id].transform.GetChild(i).transform.name = "line"+i;

			if(haveColors[id][i]==0)
				core[id].transform.GetChild(i).transform.name += "A";
			if(haveColors[id][i]==1)
				core[id].transform.GetChild(i).transform.name += "B";
			if(haveColors[id][i]==2)
				core[id].transform.GetChild(i).transform.name += "C";
			if(haveColors[id][i]==3)
				core[id].transform.GetChild(i).transform.name += "D";

			if(haveColors[id][i]!=winningColor)
				core[id].transform.GetChild(i).GetComponent<LineRenderer>().enabled=false;

		}


		
	}

	public void letDestroy()
	{
		int i = 0;
		while(GameObject.Find("core"+i))
		{
			GameObject.Destroy(GameObject.Find("core"+i));

			i++;
		}
	}

	int[] isRotating=new int[100], stepRotate=new int[100];

	Ray ray;
	RaycastHit hit;

	int turningOffCores=0;

	int triggerFilling=0;

	int[] whatShowing= new int[4]{0,0,0,0};


	int shouldChangeVisible=0;


	float leftTime=150;
	float timeToBackGame=5;
	void stoper()
	{
		if(leftTime>0)
		{
			leftTime -= 0.1f;
			counter.text=((int)leftTime).ToString();

		}
		else
		{

			if(makeItStop==0)
				endingGame();
			timeToBackGame-=0.1f;
			if(timeToBackGame<=0)
			{
				startStoper=0;
				GameObject.Find ("Main Camera").transform.GetComponent<eventSystem> ().matrixOn = 2;
			}
		}
	}


	public int startStoper=0;


	int makeItStop=0;

	Color visibleColor;
	// Update is called once per frame
	void Update () 
	{

		if(isFilling!=triggerFilling)
		{
			triggerFilling=isFilling;

			for(int i=0; i<3; i++)
			{
				if(whatShowing[i]==1)
				{
					reCheck(i);
				}
			}
		}

		if(startStoper==1)
			stoper();

		/*else if(triggerFilling==1)
		{
			Debug.Log("now!");
		}*/
		if(GameObject.Find("core0") && shouldChangeVisible==0)
		{



			for(int i=0; i<divide; i++)
			{

				visibleColor=GameObject.Find("core"+whatCoreBonus[i]).transform.GetComponent<MeshRenderer>().material.color;
				if((visibleColor.a>0.5f && whatVisibleForce[i]==0) || (visibleColor.a>=1 && whatVisibleForce[i]==2))
					whatVisibleForce[i]=1;
				else if(visibleColor.a<=0.5f)
					whatVisibleForce[i]=2;

				if(whatVisibleForce[i]==1)
					visibleColor.a -= 0.01f;
				else
					visibleColor.a += 0.01f;

				GameObject.Find("core"+whatCoreBonus[i]).transform.GetComponent<MeshRenderer>().material.color = visibleColor;
			}
		}

		if (Input.GetKeyDown(KeyCode.Return) && startStoper!=0)
		{
			leftTime=0;
			endingGame();
		}

		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			if(shouldChangeVisible==0)
			{
				shouldChangeVisible=1;
				for(int i=0; i<divide; i++)
				{
					whatVisibleForce[i]=0;
					visibleColor=GameObject.Find("core"+whatCoreBonus[i]).transform.GetComponent<MeshRenderer>().material.color;
					visibleColor.a=1;
					GameObject.Find("core"+whatCoreBonus[i]).transform.GetComponent<MeshRenderer>().material.color = visibleColor;
				}

			}
			else
				shouldChangeVisible=0;

		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			turningOffCores=0;
			if(lightForInterface[0].transform.GetComponent<MeshRenderer>().material.color.r==0)
				lightForInterface[0].transform.GetComponent<MeshRenderer>().material.color = new Color(1,0,0,1);
			else
				lightForInterface[0].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);

			while(GameObject.Find("core"+turningOffCores))
			{

				for(int i=0; i<core[turningOffCores].transform.childCount; i++)
				{
					if(core[turningOffCores].transform.GetChild(i).transform.name[core[turningOffCores].transform.GetChild(i).transform.name.Length-1]=='A')
					{
						if(core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled==true)
						{
							core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled=false;
							whatShowing[0]=0;

							if(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color!=new Color(0,0,0,1))//Color.white)
							{
								colorAlready[turningOffCores][0]=0;
								if(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.g==0 && GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.b==0)
								{
									GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);

									Debug.Log("zmiana na szare");
								}
								else		
								{
									GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color = new Color(0, GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.g,GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.b,1);
									Debug.Log("zmiana na inne "+lightForInterface[0].transform.GetComponent<MeshRenderer>().material.color );
								}
							}
						}
						else
						{
							core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled=true;
							whatShowing[0]=1;

							filling (idStart, 0);
						}

					}

				}
				turningOffCores++;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			turningOffCores=0;

			if(lightForInterface[1].transform.GetComponent<MeshRenderer>().material.color.g==0)
				lightForInterface[1].transform.GetComponent<MeshRenderer>().material.color = new Color(0,1,0,1);
			else
				lightForInterface[1].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);
			while(GameObject.Find("core"+turningOffCores))
			{

				for(int i=0; i<core[turningOffCores].transform.childCount; i++)
				{
					if(core[turningOffCores].transform.GetChild(i).transform.name[core[turningOffCores].transform.GetChild(i).transform.name.Length-1]=='B')
					{
						if(core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled==true)
						{
							core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled=false;
							whatShowing[1]=0;

							if(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color!=new Color(0,0,0,1))//Color.white)
							{
								colorAlready[turningOffCores][1]=0;
								if(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.r==0 && GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.b==0)
									GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);
								else								
									GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color = new Color(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.r,0,GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.b,1);

							}
						}
						else
						{
							core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled=true;
							whatShowing[1]=1;

							filling (idStart, 1);
						}

					}

				}
				turningOffCores++;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			turningOffCores=0;
			if(lightForInterface[2].transform.GetComponent<MeshRenderer>().material.color.b==0)
				lightForInterface[2].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,1,1);
			else
				lightForInterface[2].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);
			while(GameObject.Find("core"+turningOffCores))
			{
				for(int i=0; i<core[turningOffCores].transform.childCount; i++)
				{
					if(core[turningOffCores].transform.GetChild(i).transform.name[core[turningOffCores].transform.GetChild(i).transform.name.Length-1]=='C')
					{
						if(core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled==true)
						{
							core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled=false;
							whatShowing[2]=0;

							if(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color!=new Color(0,0,0,1))//Color.white)
							{
								colorAlready[turningOffCores][2]=0;
								if(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.r==0 && GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.g==0)
									GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);
								else								
									GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color = new Color(GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.r,GameObject.Find("core"+turningOffCores).transform.GetComponent<MeshRenderer>().material.color.g,0,1);
							}
						}
						else
						{
							core[turningOffCores].transform.GetChild(i).GetComponent<LineRenderer>().enabled=true;
							whatShowing[2]=1;

							filling (idStart, 2);
						}

					}
				}
				turningOffCores++;
			}
		}


		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.transform.name.Substring(0,4)=="core")
			{
				if(Input.GetMouseButtonUp(0))
				{
					string numberHited = "";
					if(hit.transform.name.Length==6)
						numberHited = hit.transform.name[hit.transform.name.Length-2].ToString()+hit.transform.name[hit.transform.name.Length-1].ToString();
					else
						numberHited = hit.transform.name[hit.transform.name.Length-1].ToString();


					setMove(int.Parse(numberHited));

				}
			}

		}

		for(int i=0; i<100; i++)
		{
			if(isRotating[i]!=0)
			{
				if(stepRotate[i]==0)
				{
					setToWholeAngle = GameObject.Find ("core" + i).transform.eulerAngles;

					setToWholeAngle.y+=90;
				}
				if(stepRotate[i]<45)
				{

					if(core[i].GetComponent<MeshFilter>().mesh.name.Substring(0,8) == "Triangle")
						GameObject.Find ("core" + i).transform.Rotate (new Vector3 (0, 0, 2));
					else
						GameObject.Find ("core" + i).transform.Rotate (new Vector3 (0, 2, 0));
					stepRotate[i]++;
				}
				else
				{

					isRotating[i]=0;
					stepRotate[i]=0;
					GameObject.Find ("core" + i).transform.eulerAngles = setToWholeAngle;

					restartColor();

				}
				
			}
		}

	}
	Vector3 setToWholeAngle;
	void restartColor()
	{
		for(int i=0; i<howManyCores; i++)
		{
			core[i].transform.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,1);//Color.white;
		}

		for(int i=0; i<3; i++)
		{
			if(whatShowing[i]==1)
			{
				filling(idStart, i);
				reCheck (i);
			}
		}
	}
}
