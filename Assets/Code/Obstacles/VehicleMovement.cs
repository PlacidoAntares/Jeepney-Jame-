using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

	public float MovementSpeed;
	public float ExpireTimer;
	public GameObject T_Collider; //Trigger Collider Prefab
	public GameObject Trigger_C; //Trigger Collider Assigned to the Object.
	Rigidbody ObjRigidBody;
	// Use this for initialization
	void Start () {
		ObjRigidBody = this.gameObject.GetComponent<Rigidbody>();
		Trigger_C = Instantiate(T_Collider,this.gameObject.transform.position,this.gameObject.transform.rotation) as GameObject;
	}
	// Update is called once per frame
	void Update () {
		if(Trigger_C.transform.position != this.gameObject.transform.position)
		{
			Trigger_C.transform.position = Vector3.MoveTowards(Trigger_C.transform.position,this.gameObject.transform.position, -MovementSpeed);
			Trigger_C.transform.rotation = this.gameObject.transform.rotation;
		}
		ObjRigidBody.AddForce(new Vector3(0,0,MovementSpeed));
		DestroyObject(Trigger_C,ExpireTimer);
		DestroyObject(this.gameObject,ExpireTimer);
	}
}
