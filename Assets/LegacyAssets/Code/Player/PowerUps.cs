using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	public string Sub_Tag;
	public float Rotation_smooth;
	public float Rotation_SPD;
	float Rotation_tiltAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rotate_PowerUp ();
	}

	void Rotate_PowerUp()
	{
		if (Rotation_tiltAngle < 360) {
			Rotation_tiltAngle += Rotation_SPD;
		} else if (Rotation_tiltAngle >= 360) {
			Rotation_tiltAngle = 0;
		}
		float tiltAroundY = Rotation_tiltAngle;
		Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);
		this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * Rotation_smooth);

	}
}
