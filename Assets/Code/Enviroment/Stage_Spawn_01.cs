using UnityEngine;
using System.Collections;

public class Stage_Spawn_01 : MonoBehaviour {

	public GameObject[] StagePieces;
	public GameObject[] Uniques;
	public GameObject SpawnedUnique;
	public int StageID;
	public int UniqueS_ID;
	public float UniqueChance;
	float UC_Check; // UniqueChance Check
	public Vector3 EnviromentPositionBuffer;
	public Vector3 []SpawnPosBuffer = new Vector3[3];
	public float S_PInterval;
	public bool SpawnUnique;
	bool RunS_PCoroutine;
	public int Tile_Count;
	int TileCounter;
	// Use this for initialization
	void Start () {
		Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer, this.gameObject.transform.rotation);
		Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[0], this.gameObject.transform.rotation);
		Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[1], this.gameObject.transform.rotation);
		//Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[2], this.gameObject.transform.rotation);
		RunS_PCoroutine = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (RunS_PCoroutine == true) {
			StartCoroutine (InstantiateStage (S_PInterval));
		}
	}
	
	IEnumerator InstantiateStage(float waitTimer)
	{
		if (TileCounter < Tile_Count) {
			UC_Check = Random.Range (0, 100);
			if (UC_Check <= UniqueChance) {
				SpawnUnique = true;
				Debug.Log (SpawnUnique);
			} else if (UC_Check > UniqueChance) {
				SpawnUnique = false;
				Debug.Log (SpawnUnique);
			}
			TileCounter += 1;
		} 
		else if (TileCounter >= Tile_Count) 
		{
			TileCounter = 0;
			StageID = Random.Range(0,StagePieces.Length);
		}
		TileSpawning ();
		RunS_PCoroutine = false;
		yield return new WaitForSeconds(waitTimer);
		RunS_PCoroutine = true;
		
	}
	void TileSpawning()
	{
		if (SpawnUnique != true) {
			Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[2], this.gameObject.transform.rotation);
		} 
		else 
		{
			if(SpawnedUnique == null)
			{
			UniqueS_ID = Random.Range (0,Uniques.Length);
			SpawnedUnique = Instantiate (Uniques[UniqueS_ID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[2], this.gameObject.transform.rotation) as GameObject;			
			}
			else if(SpawnedUnique != null)
			{
			Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[2], this.gameObject.transform.rotation);
			}
		}
	}
//	//---Will only run if Spawn Unique is False---
//	if (TileCounter < Tile_Count) {
//		TileCounter += 1;
//	}  
//	else if (TileCounter => Tile_Count) {
//		TileCounter = 0;
//		print("Tile Counter:" + TileCounter);
//		StageID = Random.Range(0,StagePieces.Length);
//	}
//	Instantiate (StagePieces [StageID], this.gameObject.transform.position + EnviromentPositionBuffer + SpawnPosBuffer[2], this.gameObject.transform.rotation);
//	//---Will only run if Spawn Unique is False---
}
