using UnityEngine;
using System.Collections;

public class PowerUp_Movement : MonoBehaviour {
	public float MovementSpeed;
	public float ExpireTimer;
	Rigidbody ObjRigidBody;
	// Use this for initialization
	void Start () {
		ObjRigidBody = this.gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		ObjRigidBody.AddForce(new Vector3(0,0,MovementSpeed));
		DestroyObject(this.gameObject,ExpireTimer);
	}
}
