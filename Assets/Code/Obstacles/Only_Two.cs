using UnityEngine;
using System.Collections;

public class Only_Two : MonoBehaviour {
	public bool [] VehicleDetected = new bool[2];
	public float RaySize;
	Vector3 X;
	// Use this for initialization
	void Start () {
	X = transform.TransformDirection (Vector3.left);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(this.transform.position,X * RaySize);
		if (Physics.Raycast (transform.position, X, RaySize))
		{
			print ("There is something to the left of the object!");
			VehicleDetected[0] = true;
		}
		else if (Physics.Raycast (transform.position, X, -RaySize)) {
			print ("There is something to the right of the object!");
			VehicleDetected[1] = true;
		}
		DeleteThisVehicle();
	}

	void DeleteThisVehicle()
	{
		if ((VehicleDetected [0] == true) && (VehicleDetected [1] == true)) 
		{
			Destroy(this.gameObject);
		}
	}
}
