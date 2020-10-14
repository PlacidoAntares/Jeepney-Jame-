using UnityEngine;
using System.Collections;

public class VehicleSpawning : MonoBehaviour {

	public GameObject [] Vehicles;
	//public GameObject PointPrefab;
	//public GameObject []Points = new GameObject[3];
	public float SpawnTimer;
	public float SpawnTimeMax;
	bool RunSpawnCoroutine;
	public int []SpawnChance = new int[3];
	public float LaneWidth;
	public int [] OccupiedChance = new int[3];
	public bool []LanesOccupied = new bool[3];
	public int [] NumberRolled = new int[3]; //values to check if equal to spawn chance.
	public int VehicleID;
	private Vector3 [] SpawnPoints_V = new Vector3[3];
	// Use this for initialization
	void Start () {
		SpawnPoints_V[0] = this.gameObject.transform.position + new Vector3(-LaneWidth, 0, 0);
		SpawnPoints_V[1] = this.gameObject.transform.position;
		SpawnPoints_V[2] = this.gameObject.transform.position + new Vector3(LaneWidth, 0, 0);
		RunSpawnCoroutine = true;
	}
	// Update is called once per frame
	void Update () {
		if(RunSpawnCoroutine == true)
		{
			StartCoroutine(VehicleCoroutine(SpawnTimer));
		}
	}
	IEnumerator VehicleCoroutine(float wait)
	{
		VehicleID = Random.Range (0, Vehicles.Length);
		SpawnTimer = Random.Range (1.2f, SpawnTimeMax);
		SpawnVehicles();
		//print(Time.time + " " + text1);	
		//---Happens in the first frame
		RunSpawnCoroutine = false;
		yield return new WaitForSeconds(wait);
		//----waits for a timer to run out before running.
		//print(Time.time + " " + text2);
		RunSpawnCoroutine = true;
	}
	void SpawnVehicles()
	{ 
		OccupiedChance[0] = Random.Range(0,100);
		OccupiedChance[1] = Random.Range(0,100);
		OccupiedChance[2] = Random.Range(0,100);
		//
		if(OccupiedChance[0] <= SpawnChance[0])
		{
			print ("Left lane occupied");
			LanesOccupied[0] = true;
		}
		else if(OccupiedChance[0] >= SpawnChance[0])
		{
			print("Left lane vacant");
			LanesOccupied[0] = false;
		}
		if(OccupiedChance[1] <= SpawnChance[1])
		{
			print ("Middle lane occupied");
			LanesOccupied[1] = true;
		}
		else if(OccupiedChance[1] >= SpawnChance[1])
		{
			print("Middle lane vacant");
			LanesOccupied[1] = false;
		}
		if(OccupiedChance[2] <= SpawnChance[2])
		{
			print ("Right lane occupied");
			LanesOccupied[2] = true;
		}
		else if(OccupiedChance[2] >= SpawnChance[2])
		{
			print("Right lane vacant");
			LanesOccupied[2] = false;
		}
		//
		NumberRolled[0] = Random.Range(0,100);
		NumberRolled[1] = Random.Range(0,100);
		NumberRolled[2] = Random.Range(0,100);
		if(NumberRolled[0] <= SpawnChance[0] && LanesOccupied[0] != true)
		{
		Instantiate(Vehicles[VehicleID],SpawnPoints_V[0],this.gameObject.transform.rotation);
			print ("Spawning at left lane");
		}
		if(NumberRolled[1] <= SpawnChance[1] && LanesOccupied[1] != true)
		{
			print ("Spawning at mid lane");
			Instantiate(Vehicles[VehicleID],SpawnPoints_V[1],this.gameObject.transform.rotation);
		}
		if(NumberRolled[2] <= SpawnChance[2] && LanesOccupied[2] != true)
		{
			print("Spawning at right lane");
			Instantiate(Vehicles[VehicleID],SpawnPoints_V[2],this.gameObject.transform.rotation);
		}

	}
}
