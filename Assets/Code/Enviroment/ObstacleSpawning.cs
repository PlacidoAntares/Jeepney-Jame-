using UnityEngine;
using System.Collections;

public class ObstacleSpawning : MonoBehaviour {
	
	public GameObject [] Obstacles;
	//public GameObject PointPrefab;
	//public GameObject []Points = new GameObject[3];
	public float SpawnTimer;
	private Vector3 [] SpawnPoints_O = new Vector3[3];
	// Use this for initialization
	void Start () {
		SpawnPoints_O[0] = this.gameObject.transform.position + new Vector3(-3, 0, 0);
		SpawnPoints_O[1] = this.gameObject.transform.position;
		SpawnPoints_O[2] = this.gameObject.transform.position + new Vector3(3, 0, 0);


	}

		//Instantiate(Vehicles[0],SpawnPoints[0],this.gameObject.transform.rotation);
		//Instantiate(Vehicles[0],SpawnPoints[2],this.gameObject.transform.rotation);




	// Update is called once per frame
	void Update () {

	}
}
