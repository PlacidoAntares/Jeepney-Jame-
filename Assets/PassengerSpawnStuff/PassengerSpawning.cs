using UnityEngine;
using System.Collections;

public class PassengerSpawning : MonoBehaviour 
{
	public GameObject [] passenger;
	public Vector3 Passenger_Pos;
	public int PassengerID;
	public float initialDelay;
	public float PresistentTimer;
	public float SpawnChance;
	float SpawnValidator;
	// Use this for initialization
	void Start () {

		StartCoroutine(spawnPassenger(initialDelay));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawnPassenger(float delay)
	{
		yield return new WaitForSeconds(delay);
		PassengerID = Random.Range (0, passenger.Length);
		SpawnValidator = Random.Range (0, 100);
		if (SpawnValidator <= SpawnChance) {
			Instantiate (passenger [PassengerID], this.gameObject.transform.position + Passenger_Pos, this.gameObject.transform.rotation);
		}
		StartCoroutine(spawnPassenger(Random.Range(1,PresistentTimer)));
	}
	
}
