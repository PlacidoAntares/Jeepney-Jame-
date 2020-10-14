using UnityEngine;
using System.Collections;

public class FillUp_Jeep : MonoBehaviour {
	public GameObject [] Jeep_Seats;
	Pass_Glue P_Glue;
	public GameObject [] Leg_Types;
	private int LegID;
	public int SeatAmount;
	public int SeatID;
	public int Pass_Count;
	public bool spawn_Leg;
	public bool Delete_Legs;
	// Use this for initialization
	void Start () {
		//Jeep_Seats = GameObject.FindGameObjectsWithTag ("Passenger_slots");
		spawn_Leg = false;
	}
	
	// Update is called once per frame
	void Update () {
		Spawn_Legs ();
		Leg_CleanUp ();
	}

	void Leg_CleanUp()
	{
		if (Delete_Legs == true & Pass_Count <= 0) {
			if(SeatID > Jeep_Seats.Length - 1)
			{
				SeatID = Jeep_Seats.Length - 1;
			}
			P_Glue = Jeep_Seats[SeatID].GetComponent<Pass_Glue>();
			P_Glue.Delete_Leg = true;
			if(SeatID > 0)
				SeatID -= 1;
		}
		else if (SeatID < 0) {
			SeatID = 0;
			Delete_Legs = false;
		}
	}
	void Spawn_Legs()
	{
		if (Pass_Count > 0 & spawn_Leg == true & SeatID < Jeep_Seats.Length) {
			LegID = Random.Range (0, Leg_Types.Length);
			Instantiate (Leg_Types [LegID], Jeep_Seats [SeatID].transform.position, Jeep_Seats [SeatID].transform.rotation);
			if (SeatID < Jeep_Seats.Length) {
				SeatID += 1;
			}
		} 
		spawn_Leg = false;

	}
}
