using UnityEngine;
using System.Collections;

public class Pass_Glue : MonoBehaviour {

	public GameObject Pass_Legs;
	public bool Delete_Leg;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Pass_Legs != null && Pass_Legs.transform.position != this.gameObject.transform.position) {
			Pass_Legs.transform.position = Vector3.MoveTowards (Pass_Legs.transform.position, this.gameObject.transform.position, 5.0f * Time.deltaTime);
		} 

		else if (Delete_Leg == true) {
			Destroy(Pass_Legs);
			Pass_Legs = null;
			Delete_Leg = false;
		}
	}

	void OnTriggerEnter(Collider Legs)
	{
		if (Legs.gameObject.CompareTag("Legs_P")) {
			Pass_Legs = Legs.gameObject;
		}
	}
}
