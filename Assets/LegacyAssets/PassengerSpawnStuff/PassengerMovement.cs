using UnityEngine;
using System.Collections;

public class PassengerMovement : MonoBehaviour {

	public float passengerScrollSpeed;
	public float expireTimer;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,expireTimer);

	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position += (Vector3.back * passengerScrollSpeed) * Time.deltaTime;
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

}
