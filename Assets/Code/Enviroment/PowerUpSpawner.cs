using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {
	public GameObject[] PowerUps;
	public float LaneWidth;
	public float Spawn_Timer_Min;
	public float Spawn_Timer_Max;
	public float SpawnChance;
	float SpawnTimer;
	int Pow_ID;
	private bool RunSpawnCoroutine;
	private float SpawnRolled;
	private int LaneID;
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
					StartCoroutine(PowerUpCoroutine(SpawnTimer));
				}
	}

	
	IEnumerator PowerUpCoroutine(float wait)
	{
		SpawnRolled = Random.Range(0,100);
		SpawnTimer = Random.Range (Spawn_Timer_Min, Spawn_Timer_Max);
		if (SpawnRolled <= SpawnChance) {
			SpawnPowerUp();
		}
		//print(Time.time + " " + text1);	
		//---Happens in the first frame
		RunSpawnCoroutine = false;
		yield return new WaitForSeconds(wait);
		//----waits for a timer to run out before running.
		//print(Time.time + " " + text2);
		RunSpawnCoroutine = true;
	}
	void SpawnPowerUp()
	{
		Pow_ID = Random.Range (0, PowerUps.Length);
		LaneID = Random.Range (0, SpawnPoints_V.Length);
		Instantiate(PowerUps[Pow_ID],SpawnPoints_V[LaneID],this.gameObject.transform.rotation); 
	}
	}