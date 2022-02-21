using UnityEngine;
using System.Collections;

public class ExplodePassengers : MonoBehaviour {
	
	public GameObject[] PrefabSpawned;
	public int PrefabMax;
	public Vector3 Instantiate_Point;
	public bool InstantiatePrefabs;
	public float Explode_Force;
	int PrefabID;
	int PrefabCounter;
	GameObject Prefab;
	Rigidbody Prefab_RB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (InstantiatePrefabs == true) {
			Instantiating_Prefabs();
		}
	}
	
	void Instantiating_Prefabs()
	{
		if (PrefabCounter < PrefabMax) {
			Prefab = Instantiate (PrefabSpawned [PrefabID], this.gameObject.transform.position + Instantiate_Point, this.gameObject.transform.rotation) as GameObject;
			Prefab_RB = Prefab.GetComponent<Rigidbody> ();
			Prefab_RB.AddForce(transform.up * Explode_Force);
			Prefab_RB.AddForce((transform.right * Random.Range(-1,1)) * (Explode_Force * 0.5f));
			Prefab_RB.AddForce((transform.forward * Random.Range(-1,1)) * (Explode_Force * 0.5f));
			PrefabID = Random.Range (0, PrefabSpawned.Length);
			PrefabCounter += 1;
		} 
		else if (PrefabCounter >= PrefabMax) {
			PrefabCounter = 0;
			InstantiatePrefabs = false;
		}
	}
}

