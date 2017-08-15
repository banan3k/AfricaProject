using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class loadAndSave : MonoBehaviour {

	//public playerInterface CopyData;
	// Use this for initialization
	public Vector3 a2 =new Vector3(0,0,0);
	public string b2= "aa";
	public bool c3=true;

	int sizeArray=10000;
	void Start () 
	{
	
	}
	public void loadData (System.Object classToLoad)
	{
		string nameValueToSave = this.GetType ().GetFields ().GetValue (0).ToString ().Split (' ').GetValue (1).ToString();
		Debug.Log ("start "+this.GetType ().GetField (nameValueToSave).GetValue(this).ToString());

		string textFromFile = System.IO.File.ReadAllText ("Saves/" + classToLoad.ToString () + ".txt");
		Debug.Log (textFromFile);
		string[] firstDivide = textFromFile.Split ('/');

		System.Object[][] valueLoadArray=new System.Object[sizeArray][];
		System.Object[][][] valueLoadArrayDouble=new System.Object[sizeArray][][];
		System.Object[][][][] valueLoadArrayTriple=new System.Object[sizeArray][][][];
		for(int i=0; i<10; i++)
		{
			//valueLoadArray[i]=new System.Object[sizeArray];
			valueLoadArrayDouble[i]=new System.Object[sizeArray][];
			valueLoadArrayTriple[i]=new System.Object[sizeArray][][];
			for(int i2=0; i2<10; i2++)
			{
			//	valueLoadArrayDouble[i][i2]=new System.Object[sizeArray];
				valueLoadArrayTriple[i][i2]=new System.Object[sizeArray][];

				//Array.Copy(
			/*	for(int i3=0; i3<10; i3++)
				{
					valueLoadArrayTriple[i][i2][i3]=new System.Object[sizeArray];
				}*/
			}
		}

	
		System.Object[] valueLoad=new System.Object[sizeArray];
		for(int i=0; i<firstDivide.Length; i++)
		{
			if(firstDivide[i].IndexOf("*")>=0)
			{
				//triple ARRAY
				for(int i2=0; i2<firstDivide[i].Split('*').Length; i2++)
				{
					for(int i3=0; i2<firstDivide[i3].Split(';').Length; i3++)
					{
						for(int i4=0; i2<firstDivide[i4].Split('+').Length; i4++)
						{
						//	valueLoadArrayTriple[i][i2][i3][i4]=firstDivide[i].Split('*')[i2].Split(';')[i3].Split('+')[i4];
						}
						valueLoadArrayTriple[i][i2][i3]=new System.Object[firstDivide[i].Split('*')[i2].Split(';')[i3].Split('+').Length];
						Array.Copy(firstDivide[i].Split('*')[i2].Split(';')[i3].Split('+'),valueLoadArrayTriple[i][i2][i3],firstDivide[i].Split('*')[i2].Split(';')[i3].Split('+').Length);
					}
				}
			}
			if(firstDivide[i].IndexOf(";")>=0)
			{
				//DOUBLE ARRAY
				for(int i2=0; i2<firstDivide[i].Split(';').Length; i2++)
				{
/*					for(int i3=0; i2<firstDivide[i3].Split('+').Length; i3++)
					{
						//valueLoadArrayDouble[i][i2][i3]=firstDivide[i].Split(';')[i2].Split('+')[i3];
					}*/
					valueLoadArrayDouble[i][i2]=new System.Object[firstDivide[i].Split(';')[i2].Split('+').Length];
					Array.Copy(firstDivide[i].Split(';')[i2].Split('+'),valueLoadArrayDouble[i][i2],firstDivide[i].Split(';')[i2].Split('+').Length);
				}
			}
			else if(firstDivide[i].IndexOf("+")>=0)
			{

				for(int i2=0; i2<firstDivide[i].Split('+').Length; i2++)
				{
				//	valueLoadArray[i][i2]=firstDivide[i].Split('+')[i2];
				}
				valueLoadArray[i]=new System.Object[firstDivide[i].Split('+').Length-1];
//				Debug.Log (firstDivide[i].Split('+')[49]);
				Array.Copy(firstDivide[i].Split('+'),valueLoadArray[i],firstDivide[i].Split('+').Length-1);
			}
			else
			{
				//normal variable
				Debug.Log(firstDivide+" devition: "+firstDivide[i].Split(':')[1]);
				valueLoad[i]=firstDivide[i].Split(':')[1];
			}
		}



		int limitOfValues = 0;
		while(limitOfValues<classToLoad.GetType ().GetFields ().Length )//&& limitOfValues<1)
		{
			string kindValueToSave = classToLoad.GetType ().GetFields ().GetValue (limitOfValues).ToString ().Split (' ').GetValue (0).ToString();

			if(kindValueToSave.ToLower().IndexOf("[][][]")>=0)
			{
				if(kindValueToSave.IndexOf("Vector3")>=0)
				{
					Vector3[][][] tempFloatArray= new Vector3[valueLoadArrayTriple[limitOfValues].Length][][];
					for(int i=0; i<valueLoadArrayTriple[limitOfValues].Length; i++)
					{
						//Debug.Log(valueLoadArrayDouble[limitOfValues][i][0]);
						tempFloatArray[i]= new Vector3[valueLoadArrayTriple[limitOfValues][i].Length][];
						for(int i2=0; i2<valueLoadArrayTriple[limitOfValues][i].Length; i2++)
						{
							if(valueLoadArrayTriple[limitOfValues][i][i2]!=null)
							{
								tempFloatArray[i][i2]=Array.ConvertAll<System.Object,Vector3>(valueLoadArrayTriple[limitOfValues][i][i2],delegate(System.Object t) {
									Vector3 temp=new Vector3();
									temp.x=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[0]);
									temp.y=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[1]);
									temp.z=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[2]);
									
									return temp;
									
								});
							}
						}

					}
					
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempFloatArray);
				}
				else if(kindValueToSave.IndexOf("Single")>=0)
				{
					float[][][] tempFloatArray= new float[valueLoadArrayTriple[limitOfValues].Length][][];
					for(int i=0; i<valueLoadArrayTriple[limitOfValues].Length; i++)
					{
						tempFloatArray[i]= new float[valueLoadArrayTriple[limitOfValues][i].Length][];
						for(int i2=0; i2<valueLoadArrayTriple[limitOfValues][i].Length; i2++)
						{
							if(valueLoadArrayTriple[limitOfValues][i][i2]!=null)
							{
								tempFloatArray[i][i2]=Array.ConvertAll<System.Object,float>(valueLoadArrayTriple[limitOfValues][i][i2],delegate(System.Object t) {
									Debug.Log(t.ToString()+" vs "+i+" vs "+limitOfValues);
									try
									{
										return float.Parse(t.ToString());
									}
									catch(Exception)
									{
										return float.Parse(t.ToString().Split(':')[1]);
									}
									
								});
							}
						}

					}
					
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempFloatArray);
				}
				else if(kindValueToSave.IndexOf("Int")>=0)
				{
					
					int[][][] tempIntArray= new int[valueLoadArrayTriple[limitOfValues].Length][][];
					for(int i=0; i<valueLoadArrayTriple[limitOfValues].Length; i++)
					{
						//Debug.Log(valueLoadArrayDouble[limitOfValues][i][0]);
						tempIntArray[i]= new int[valueLoadArrayTriple[limitOfValues][i].Length][];
						for(int i2=0; i2<valueLoadArrayTriple[limitOfValues][i].Length; i2++)
						{
							if(valueLoadArrayTriple[limitOfValues][i][i2]!=null)
							{
								tempIntArray[i][i2]=Array.ConvertAll<System.Object,int>(valueLoadArrayTriple[limitOfValues][i][i2],delegate(System.Object t) {
									//							Debug.Log(t.ToString()+" vs "+i+" vs "+limitOfValues);
									try
									{
										return int.Parse(t.ToString());
									}
									catch(Exception)
									{
										return int.Parse(t.ToString().Split(':')[1]);
									}
									
								});
							}
						}
					}
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempIntArray);
				}
				else 
				{
					
					string[][][] tempStringArray= new string[valueLoadArrayTriple[limitOfValues].Length][][];
					for(int i=0; i<valueLoadArrayTriple[limitOfValues].Length; i++)
					{
						tempStringArray[i]= new string[valueLoadArrayTriple[limitOfValues][i].Length][];
						for(int i2=0; i2<valueLoadArrayTriple[limitOfValues][i].Length; i2++)
						{
							tempStringArray[i][i2]=Array.ConvertAll<System.Object,string>(valueLoadArrayTriple[limitOfValues][i][i2],delegate(System.Object t) {
								return t.ToString();
							});
						}
					}
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempStringArray);
				}


				//classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,valueLoadArrayTriple[limitOfValues]);
			}
			else if(kindValueToSave.ToLower().IndexOf("[][]")>=0)
			{

				if(kindValueToSave.IndexOf("Vector3")>=0)
				{
					Vector3[][] tempFloatArray= new Vector3[valueLoadArrayDouble[limitOfValues].Length][];
					for(int i=0; i<valueLoadArrayDouble[limitOfValues].Length; i++)
					{
						//Debug.Log(valueLoadArrayDouble[limitOfValues][i][0]);
						if(valueLoadArrayDouble[limitOfValues][i]!=null)
						{
							tempFloatArray[i]=Array.ConvertAll<System.Object,Vector3>(valueLoadArrayDouble[limitOfValues][i],delegate(System.Object t) {
								Vector3 temp=new Vector3();
								temp.x=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[0]);
								temp.y=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[1]);
								temp.z=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[2]);
								
								return temp;
								
							});
						}
					}
					
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempFloatArray);
				}
				else if(kindValueToSave.IndexOf("Single")>=0)
				{
					float[][] tempFloatArray= new float[10][];
					for(int i=0; i<valueLoadArrayDouble[limitOfValues].Length; i++)
					{
						//Debug.Log(valueLoadArrayDouble[limitOfValues][i][0]);
						if(valueLoadArrayDouble[limitOfValues][i]!=null)
						{
							tempFloatArray[i]=Array.ConvertAll<System.Object,float>(valueLoadArrayDouble[limitOfValues][i],delegate(System.Object t) {
								Debug.Log(t.ToString()+" vs "+i+" vs "+limitOfValues);
								try
								{
									return float.Parse(t.ToString());
								}
								catch(Exception)
								{
									return float.Parse(t.ToString().Split(':')[1]);
								}
								
							});
						}
					}

					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempFloatArray);
				}
				else if(kindValueToSave.IndexOf("Int")>=0)
				{

					int[][] tempIntArray= new int[valueLoadArrayDouble[limitOfValues].Length][];
					for(int i=0; i<valueLoadArrayDouble[limitOfValues].Length; i++)
					{
						//Debug.Log(valueLoadArrayDouble[limitOfValues][i][0]);
						if(valueLoadArrayDouble[limitOfValues][i]!=null)
						{
						tempIntArray[i]=Array.ConvertAll<System.Object,int>(valueLoadArrayDouble[limitOfValues][i],delegate(System.Object t) {
//							Debug.Log(t.ToString()+" vs "+i+" vs "+limitOfValues);
							try
							{
								return int.Parse(t.ToString());
							}
							catch(Exception)
							{
								return int.Parse(t.ToString().Split(':')[1]);
							}
					
							});
						}
					}
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempIntArray);
				}
				else 
				{

					string[][] tempStringArray= new string[valueLoadArrayDouble[limitOfValues].Length][];
					for(int i=0; i<valueLoadArrayDouble[limitOfValues].Length; i++)
					{
						tempStringArray[i]=Array.ConvertAll<System.Object,string>(valueLoadArrayDouble[limitOfValues][i],delegate(System.Object t) {
							return t.ToString();
						});
					}
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempStringArray);
				}

				//classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,valueLoadArrayDouble[limitOfValues]);
			}
			else if(kindValueToSave.IndexOf("[]")>=0)
			{
				if(kindValueToSave.IndexOf("Vector3")>=0)
				{
					Vector3[] tempVectorArray;
					tempVectorArray=Array.ConvertAll<System.Object,Vector3>(valueLoadArray[limitOfValues],delegate(System.Object t) {
						Vector3 temp=new Vector3();
						temp.x=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[0]);
						temp.y=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[1]);
						temp.z=float.Parse(t.ToString().Remove(t.ToString().IndexOf('(')).Remove(t.ToString().IndexOf(')')).Split(',')[2]);

						return temp;
					});
					//	.float.Parse(valueLoad[limitOfValues].ToString());
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempVectorArray);
				}
				else if(kindValueToSave.IndexOf("Single")>=0)
				{
					float[] tempFloatArray;
					tempFloatArray=Array.ConvertAll<System.Object,float>(valueLoadArray[limitOfValues],delegate(System.Object t) {
						return float.Parse(t.ToString().Split(':')[1]);
					});
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempFloatArray);
				}
				else if(kindValueToSave.IndexOf("Int")>=0)
				{
					int[] tempIntArray;
					tempIntArray=Array.ConvertAll<System.Object,int>(valueLoadArray[limitOfValues],delegate(System.Object t) {
						return int.Parse(t.ToString().Split(':')[1]);
					});
					
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempIntArray);
				}
				else 
				{
					string[] tempStringArray;
					tempStringArray=Array.ConvertAll<System.Object,string>(valueLoadArray[limitOfValues],delegate(System.Object t) {
						return t.ToString();
					});

					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,tempStringArray);
				}
			}
			else 
			{
//				Debug.Log (kindValueToSave+" vs "+firstDivide[limitOfValues]+" vs "+valueLoad[limitOfValues]);
				if(kindValueToSave.IndexOf("Vector3")>=0)
				{
					Vector3 temp = new Vector3();
					temp.x=float.Parse(valueLoad[limitOfValues].ToString().Remove(valueLoad[limitOfValues].ToString().IndexOf('(')).Remove(valueLoad[limitOfValues].ToString().IndexOf(')')).Split(',')[0]);
					temp.x=float.Parse(valueLoad[limitOfValues].ToString().Remove(valueLoad[limitOfValues].ToString().IndexOf('(')).Remove(valueLoad[limitOfValues].ToString().IndexOf(')')).Split(',')[1]);
					temp.x=float.Parse(valueLoad[limitOfValues].ToString().Remove(valueLoad[limitOfValues].ToString().IndexOf('(')).Remove(valueLoad[limitOfValues].ToString().IndexOf(')')).Split(',')[2]);
					//	.float.Parse(valueLoad[limitOfValues].ToString());
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,temp);
				}
				else if(kindValueToSave.IndexOf("Single")>=0)
				{
					float temp = float.Parse(valueLoad[limitOfValues].ToString());
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,temp);
				}
				else if(kindValueToSave.IndexOf("Int")>=0)
				{
					int temp = int.Parse(valueLoad[limitOfValues].ToString());
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,temp);
				}
				else
					classToLoad.GetType ().GetFields ()[limitOfValues].SetValue(classToLoad,valueLoad[limitOfValues].ToString());

				
			}
		//	Debug.Log(classToLoad.GetType ().GetFields ().GetValue (limitOfValues).ToString ());




			limitOfValues++;
		}
	}
	public void SaveData(System.Object classToSave)
	{
	//	UnityEngine.Object[] listT = Fin(typeof(int));

		Debug.Log ("listaInt "+classToSave.GetType ().GetFields ().GetValue (0).ToString());
		//Debug.Log ("listaInt "+this.GetType ().GetField ("a2").GetValue(this).ToString());

		string valueToSave="null", nameValueToSave;
		int limitOfValues = 0, breakLimit=0;
		System.Object[] arrayToSaveObj = new System.Object[100];
		System.Int32[] arrayToSaveInt = new System.Int32[100];
		float[] arrayToSaveFloat = new float[100];
		Vector3[] arrayToSaveVector = new Vector3[100];
		System.String[] arrayToSaveString = new System.String[100];

		System.Int32[][] arrayToSaveDoubleInt = new System.Int32[1000][];
		float[][] arrayToSaveDoubleFloat = new float[1000][];
		Vector3[][] arrayToSaveDoubleVector = new Vector3[1000][];
		System.String[][] arrayToSaveDoubleMain=new System.String[1000][];
		System.Int32[][][] arrayToSaveTripleInt = new System.Int32[1000][][];
		string[][][] arrayToSaveTripleMain=new string[1000][][];
		/*for (int i=0; i<1000; i++) {
			arrayToSaveTripleInt[i]=new int[1000][];
			arrayToSaveTripleMain[i]=new string[1000][];
			//for(int i2=0; i2<100; i2++)
			//	arrayToSaveTripleMain[i][i2]=new string[10];
		}*/

		string[][][] arrayToSaveTripleMainNew=new string[10][][];

		string saveContent = "";
		while(breakLimit==0 && limitOfValues<classToSave.GetType ().GetFields ().Length)
		{
			try
			{
				nameValueToSave = classToSave.GetType ().GetFields ().GetValue (limitOfValues).ToString ().Split (' ').GetValue (1).ToString();
				valueToSave=classToSave.GetType ().GetField (nameValueToSave).GetValue(classToSave).ToString();
				if(valueToSave.IndexOf("System.")>=0 && valueToSave.IndexOf("[][][]")>=0)
				{
					valueToSave=nameValueToSave+":";
					System.Reflection.FieldInfo doubleArray=(classToSave.GetType ().GetField (nameValueToSave));
					if(doubleArray.ToString().IndexOf("String")>=0)
					{
						//arrayToSaveTripleMain=((System.String[][][])(doubleArray.GetValue(classToSave)));
						string[][][] ttt2=new string[10][][];
						for(int i=0; i<((System.String[][][])(doubleArray.GetValue(classToSave))).Length-1; i++)
						{
							string[][] ttt;
							ttt=((System.String[][][])(doubleArray.GetValue(classToSave)))[i];
							ttt2[i]=ttt;
						//	Debug.Log(ttt[0][0]+" vs "+((System.String[][][])(doubleArray.GetValue(classToSave))).Length);
						}




						arrayToSaveTripleMainNew=ttt2;
						//arrayToSaveTripleMain=ttt3;
						//GameObject.Find("Main Camera").GetComponent<playerInterface>().messeges=arrayToSaveTripleMain;
						//arrayToSaveTripleMain[0]=((System.String[][][])(doubleArray.GetValue(classToSave)));
						//Debug.Log(((System.String[][][])(doubleArray.GetValue(classToSave)))[0][0][0]);
					//	arrayToSaveTripleMain[0]=ttt;

					}
					if(doubleArray.ToString().IndexOf("Int32")>=0)
					{
						arrayToSaveTripleInt=((System.Int32[][][])(doubleArray.GetValue(classToSave)));
					//	Debug.Log(arrayToSaveTripleInt[0][0][0]+" yolo "+arrayToSaveTripleInt.Length);

						string[][][] ttt2=new string[1000][][];
						for(int i=0; i<arrayToSaveTripleInt.Length-1; i++)
						{
							string[][] ttt=new string[1000][];
//							ttt=arrayToSaveTripleInt[i];

							//Debug.Log(arrayToSaveTripleInt[i].Length);
							for(int i2=0; i2<arrayToSaveTripleInt[i].Length-1; i2++)
							{
								ttt[i2]=Array.ConvertAll<int,string>(arrayToSaveTripleInt[i][i2],delegate(int t) {
									return t.ToString();
								});
							}
							ttt2[i]=ttt;
						}
						arrayToSaveTripleMainNew=ttt2;
						/*for(int i=0; i<1000; i++)
						{
							try
							{
							for(int i2=0; i2<1000; i2++)
							{

								arrayToSaveTripleMain[i][i2]=Array.ConvertAll<int,string>(arrayToSaveTripleInt[i][i2],delegate(int t) {
									return t.ToString();
								});
								
							}
							}catch(Exception ex){i=arrayToSaveTripleInt.Length; break;};
						}*/
					}

					for(int i=0; i<1000; i++)
					{


						try
						{
						for(int i2=0; i2<1000; i2++)
						{

								if(arrayToSaveTripleMainNew[i][i2]!=null)
							{
							//	Debug.Log(i2+"len");
							
									for(int i3=0; i3<arrayToSaveTripleMainNew[i][i2].Length; i3++)
							{
										valueToSave+=arrayToSaveTripleMainNew[i][i2][i3];
										if(i3<arrayToSaveTripleMainNew[i][i2].Length-1)
											valueToSave+="+";
							}
							if(i2<999)//arrayToSaveTripleMain[i].Length-1)
								valueToSave+=";";
							}
							
							//	Debug.Log(arrayToSaveDoubleMain[i2][i]+" vs "+i2);
						}
						}catch(Exception ex){i=1000;};
						if(i<arrayToSaveTripleMainNew.Length-1)
							valueToSave+="*";
						else
							valueToSave+="/";
						
					}
					//valueToSave="a";
					saveContent+=valueToSave;

				}
				else if(valueToSave.IndexOf("System.")>=0 && valueToSave.IndexOf("[][]")>=0)
				{

					valueToSave=nameValueToSave+":";

					System.Reflection.FieldInfo doubleArray=(classToSave.GetType ().GetField (nameValueToSave));
					if(doubleArray.ToString().IndexOf("String")>=0)
					{
						arrayToSaveDoubleMain=((System.String[][])(doubleArray.GetValue(classToSave)));
					}
					else //
					{
						if(doubleArray.ToString().IndexOf("Int32")>=0)
						{
							arrayToSaveDoubleInt=((System.Int32[][])(doubleArray.GetValue(classToSave)));
						//	Debug.Log (arrayToSaveDoubleInt[0][0]);
							for(int i=0; i<1000; i++)
							{
									
								try
								{
									arrayToSaveDoubleMain[i]=Array.ConvertAll<int,string>(arrayToSaveDoubleInt[i],delegate(int t) {
										return t.ToString();
									});
								}catch(Exception ex){i=1000;};
							}
						}
						if(doubleArray.ToString().IndexOf("Single")>=0)
						{
							arrayToSaveDoubleFloat=((float[][])(doubleArray.GetValue(classToSave)));
							//	Debug.Log (arrayToSaveDoubleInt[0][0]);
							for(int i=0; i<1000; i++)
							{
								try
								{
									arrayToSaveDoubleMain[i]=Array.ConvertAll<float,string>(arrayToSaveDoubleFloat[i],delegate(float t) {
										return t.ToString();
									});
								}catch(Exception ex){i=1000;};
							}
						}
						if(doubleArray.ToString().IndexOf("Vector3")>=0)
						{
							arrayToSaveDoubleVector=((Vector3[][])(doubleArray.GetValue(classToSave)));
							//	Debug.Log (arrayToSaveDoubleInt[0][0]);
							for(int i=0; i<1000; i++)
							{
								arrayToSaveDoubleMain[i]=Array.ConvertAll<Vector3,string>(arrayToSaveDoubleVector[i],delegate(Vector3 t) {
									return t.ToString();
								});
							}
						}
					}

					//Debug.Log (valueToSave);
					for(int i2=0; i2<arrayToSaveDoubleMain.Length; i2++)
					{
						try
						{
						//for(int i=0; i<arrayToSaveDoubleMain[i2].Length; i++)
						for(int i=0; i<1000; i++)
						{
							
							
							valueToSave+=arrayToSaveDoubleMain[i2][i];
							if(i<arrayToSaveDoubleMain[i2].Length-1)
								valueToSave+="+";
							
						//	Debug.Log(arrayToSaveDoubleMain[i2][i]+" vs "+i2);
						}
						}catch(Exception ex){};
						if(i2<arrayToSaveDoubleMain.Length-1 && arrayToSaveDoubleMain[i2]!=null)
							valueToSave+=";";
						else if(arrayToSaveDoubleMain[i2]!=null)
							valueToSave+="/";

					}
				
					saveContent+=valueToSave;
					//arrayToSave=arrayToSaveDouble[0][0];
				//	System.Object[] arrayToSave2=new System.Object[10];//=(System.Object[])arrayToSave[0];
				//	Array.Copy(arrayToSave[0],arrayToSave2,5);
				//	Debug.Log (((System.Object[][])(t.GetValue(classToSave)))[0][0]);
//					Debug.Log(arrayToSaveDoubleMain[0][0]+" vs "+arrayToSaveDoubleMain.LongLength);
				}
				else if(valueToSave.IndexOf("System.")>=0 && valueToSave.IndexOf("[]")>=0)
				{
			//		Debug.Log(valueToSave);
					valueToSave=nameValueToSave+":";

					int numberOfArrays=0;

					System.Reflection.FieldInfo singleArray=(classToSave.GetType ().GetField (nameValueToSave));

					if(singleArray.ToString().IndexOf("String")>=0)
					{

						arrayToSaveString=((System.String[])(singleArray.GetValue(classToSave)));
						//Debug.Log(arrayToSaveString[0] +" patola");
						numberOfArrays = arrayToSaveString.Length-1;
					}
					else //
					{
						//arrayToSaveInt=((System.Int32[])(singleArray.GetValue(classToSave)));
						//
						if(singleArray.ToString().IndexOf("Int32")>=0)
						{
							arrayToSaveInt=((System.Int32[])(singleArray.GetValue(classToSave)));
							arrayToSaveString = new string[10000];
							for(int i=0; i<1000; i++)
							{
//								Debug.Log (nameValueToSave+" vs"+i);
								if(i<arrayToSaveInt.Length)
									arrayToSaveString[i] = arrayToSaveInt[i].ToString();
								else
									i=1000;

								numberOfArrays++;

							}
						}
						else if(singleArray.ToString().IndexOf("Single")>=0)
						{
							arrayToSaveFloat=((float[])(singleArray.GetValue(classToSave)));
							arrayToSaveString = new string[10000];
							for(int i=0; i<1000; i++)
							{
								if(i<arrayToSaveFloat.Length)
									arrayToSaveString[i] = arrayToSaveFloat[i].ToString();
								else
									i=1000;

								numberOfArrays++;

							}
						}
						else if(singleArray.ToString().IndexOf("Vector3")>=0)
						{
							arrayToSaveVector=((Vector3[])(singleArray.GetValue(classToSave)));
							arrayToSaveString = new string[10000];
							for(int i=0; i<1000; i++)
							{
								if(i<arrayToSaveFloat.Length)
									arrayToSaveString[i] = arrayToSaveVector[i].ToString();
								else
									i=1000;
								
								numberOfArrays++;
								
							}
						}
						else 
						{
							arrayToSaveObj=((System.Object[])(singleArray.GetValue(classToSave)));
							arrayToSaveString = new string[10000];
							for(int i=0; i<1000; i++)
							{
								if(i<arrayToSaveFloat.Length)
									arrayToSaveString[i] = arrayToSaveObj[i].ToString();
								else
									i=1000;
								
								numberOfArrays++;
								
							}
						}
					}
						
						



					for(int i=0; i<numberOfArrays; i++)
					{
						valueToSave+=arrayToSaveString[i];
						if(i<numberOfArrays-2)
							valueToSave+="+";
						else if(i<numberOfArrays-1)
							valueToSave+="/";
					}
					saveContent+=valueToSave;
				//	Debug.Log("array "+arrayToSave[0].ToString());
				}
				else
				{
//					Debug.Log (nameValueToSave+" : "+valueToSave);
					saveContent+=nameValueToSave+":"+valueToSave+"/";
				}

				limitOfValues++;
			}
			catch(Exception ex)
			{
				breakLimit=1;
			//	string nameValueToSave2 = classToSave.GetType ().GetFields ().GetValue (limitOfValues).ToString ().Split (' ').GetValue (1).ToString();

			//	string valueToSave2=classToSave.GetType ().GetField (nameValueToSave2).GetValue(classToSave).ToString();

				Debug.Log(ex);
			}
			//breakLimit=0;
		}
		saveContent=saveContent.Substring(0,saveContent.Length-1);




		if (!Directory.Exists ("Saves"))
			Directory.CreateDirectory ("Saves");
		

			
		try
		{
			StreamWriter save = new StreamWriter("Saves/"+classToSave.ToString()+".txt");
			Debug.Log (saveContent);
			save.Write(saveContent);
			save.Flush();


		}
		catch(Exception ex)
		{
			Debug.Log("error while saving "+ex.ToString());
		}



	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
