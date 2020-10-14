using UnityEngine;
using System.Collections;

public class StageMovement : MonoBehaviour {

	public float Stage_MovementSpeed;
	public float ExpireTimer;

	// Use this for initialization
	void Start () {
		DestroyObject (this.gameObject, ExpireTimer);
	}
	
	// Update is called once per frame
	void Update () {
		//print (Time.time);
		this.gameObject.transform.position += (Vector3.back * Stage_MovementSpeed) * Time.deltaTime;

	}
}
