using UnityEngine;
using System.Collections;

public class VehicleCreator : MonoBehaviour {

	public GameObject[] VehicleTypes;
	public float LaneWidth;
	public float SpawnInterval;
	public float[]SpawnChance = new float[3];
	public int LaneOccupied;
	public bool[] Occupied = new bool[3];
	private Vector3[]SpawnPoints = new Vector3[3];
	public int[] RolledNumbers = new int[3];
	private bool RunSpawn_C;
	// Use this for initialization
	void Start () {
		RunSpawn_C = true;
		SpawnPoints [0] = this.gameObject.transform.position + new Vector3 (LaneWidth, 0.0f,0.0f);
		SpawnPoints [1] = this.gameObject.transform.position;
		SpawnPoints [2] = this.gameObject.transform.position + new Vector3 (-LaneWidth, 0.0f,0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (RunSpawn_C == true) {

			StartCoroutine(SpawnVehicles(SpawnInterval));
		}
	}

	IEnumerator SpawnVehicles(float waitTimer)
	{
		RolledNumbers [0] = Random.Range (0, 100);
		RolledNumbers [1] = Random.Range (0, 100);
		RolledNumbers [2] = Random.Range (0, 100);
		LaneOccupied = Random.Range (0, 3);
		switch (LaneOccupied) {
		case 0:
			Occupied[0] = true;
			Occupied[1] = false;
			Occupied[2] = false;
			break;
		case 1:
			Occupied[0] = false;
			Occupied[1] = true;
			Occupied[2] = false;
			break;
		case 2:
			Occupied[0] = false;
			Occupied[1] = false;
			Occupied[2] = true;
			break;
		}
		Instantiate_V ();
		RunSpawn_C = false;
		yield return new WaitForSeconds(waitTimer);
		RunSpawn_C = true;
	}
	void Instantiate_V()
	{
		if (Occupied [0] != true && RolledNumbers [0] <= SpawnChance[0]) {
			Instantiate(VehicleTypes[0],this.gameObject.transform.position,this.gameObject.transform.rotation);
		}
	}
}
