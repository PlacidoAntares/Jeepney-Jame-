using UnityEngine;
using System.Collections;

public class VehicleLaneSpawner : MonoBehaviour {

	public GameObject [] Vehicles;
	public float LaneWidth;
	public float Spawn_Timer_Min;
	public float Spawn_Timer_Max; //Will be the starting value of SpawnTimer;
	public float SpawnChance; //value must be no greater than 100 or less than 0
	public float SingleLane_Ch;
	float SpawnTimer;
	private float SpawnRolled;
	private int VehicleID;
	private GameObject [] Lane_Spawns = new GameObject[3];
	private int LaneID;
	private bool RunSpawnCoroutine;
	private bool Only_One;
	private int Only_OneDice;
	private Vector3 [] SpawnPoints_V = new Vector3[3];
	// Use this for initialization
	void Start () {
		SpawnPoints_V[0] = this.gameObject.transform.position + new Vector3(-LaneWidth, 0, 0);
		SpawnPoints_V[1] = this.gameObject.transform.position;
		SpawnPoints_V[2] = this.gameObject.transform.position + new Vector3(LaneWidth, 0, 0);
		RunSpawnCoroutine = true;
		SpawnTimer = Spawn_Timer_Max;
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
		SpawnRolled = Random.Range(0,100);
		SpawnTimer = Random.Range (Spawn_Timer_Min, Spawn_Timer_Max);
		if (SpawnRolled <= SpawnChance) {
			SpawnVehicles();
		}
		Set_Num_Cars ();
		//print(Time.time + " " + text1);	
		//---Happens in the first frame
		RunSpawnCoroutine = false;
		yield return new WaitForSeconds(wait);
		//----waits for a timer to run out before running.
		//print(Time.time + " " + text2);
		RunSpawnCoroutine = true;
	}

	void Set_Num_Cars()
	{
		Only_OneDice = Random.Range(0,100);
		if (Only_OneDice <= SingleLane_Ch) {
			Only_One = true;
		}

		else if (Only_OneDice >= SingleLane_Ch) {
			Only_One = false;
		}
	}
	void SpawnVehicles()
	{
		VehicleID = Random.Range (0, Vehicles.Length);
		Lane_Spawns [0] = Instantiate (Vehicles [VehicleID], SpawnPoints_V [0], this.gameObject.transform.rotation) as GameObject;
		Lane_Spawns [1] = Instantiate (Vehicles [VehicleID], SpawnPoints_V [1], this.gameObject.transform.rotation) as GameObject;
		Lane_Spawns [2] = Instantiate (Vehicles [VehicleID], SpawnPoints_V [2], this.gameObject.transform.rotation) as GameObject;
		LaneID = Random.Range (0, Lane_Spawns.Length);
		if (Lane_Spawns [LaneID] != null) {
			Destroy (Lane_Spawns [LaneID]);
			Debug.Log("Deleted Vehicle");
			//
			if(Only_One == true)
			{
				LaneID = Random.Range(0,Lane_Spawns.Length);
				if(Lane_Spawns[LaneID] != null)
				{
					Destroy(Lane_Spawns[LaneID]);
					Debug.Log("Deleted Vehicle");
				}
			}
		}

	}

}
