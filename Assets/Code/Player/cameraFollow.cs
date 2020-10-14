using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    private Camera cam;
    private Transform jeep;

	void Awake () {
        jeep = this.GetComponent<Transform>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	void Update () {
        cam.transform.position = new Vector3(jeep.position.x, cam.transform.position.y, -4.63f);
	}
}
