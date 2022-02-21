
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionDetect : MonoBehaviour {
	
	private GameObject JLM_Container;
	private JeepLaneMovement jeep;
	//public GameObject ObjCollided;
	private VehicleAttributes V_A;
	private BoxCollider V_BC;
	private int multiplier = 0;
	public GameObject SB_Container;
	public shieldBar shieldGauge;
	private bool invincible = false;
	public GameObject Fill_Pass;
	ExplodePassengers Ex_P;
	FillUp_Jeep FU_J;
	//Sounds
	private AudioSource source;
	public AudioClip[] clip;
	public float Vehicle_Penalty;
	void Start()
	{
		JLM_Container = GameObject.Find("JeepManager").gameObject;
		//jeep = GameObject.FindWithTag("Jeepney").GetComponent<JeepLaneMovement>();
		jeep = JLM_Container.GetComponent<JeepLaneMovement>();
		SB_Container = GameObject.Find("UI").gameObject;
		//shieldGauge = GameObject.FindWithTag("UI").GetComponent<shieldBar>();
		shieldGauge = SB_Container.GetComponent<shieldBar>();
		source = GetComponent<AudioSource>();
		ScoreManager.score = 0;
		Fill_Pass = GameObject.FindGameObjectWithTag("Jeep_Prefab");
		FU_J = Fill_Pass.GetComponent<FillUp_Jeep> ();
		Ex_P = Fill_Pass.GetComponent<ExplodePassengers> ();
	}
	
	void Update()
	{
		//shieldGauge.visible = true;
		//shieldGauge.enabled = true;

		if (shieldGauge.visible == true || shieldGauge.shieldGauge.activeSelf == true)
		{
			invincible = true;
			//Debug.Log("SHIELD ON");
		}
		else if (shieldGauge.visible == false || shieldGauge.shieldGauge.activeSelf == false)
		{
			invincible = false;
			//Debug.Log("SHIELD OFF");
		}
	}
	
	void Multiply()
	{
		multiplier += 1;
		if (multiplier % 5 == 0 && multiplier != 0)
		{
			jeep.currentMulti += 1;
			jeep.pop = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "Passenger")
		{
			source.PlayOneShot(clip[0], 0.5f);
			//AudioSource.PlayClipAtPoint(clip[0], Camera.main.transform.position);
			ScoreManager.score += 300;
			ScoreManager.pass += 1;
			FU_J.Pass_Count += 1;
			//FU_J.SeatID += 1;
			FU_J.spawn_Leg = true;
			print("passenger pick up");
			GameObject Pas_Obj = other.gameObject;
			Destroy(Pas_Obj);
			Multiply();
		}
		else if (other.tag == "Vehicle" && invincible == false)
		{
			source.PlayOneShot(clip[1], 0.5f);
			//AudioSource.PlayClipAtPoint(clip[1], Camera.main.transform.position);
			V_A = other.gameObject.GetComponent<VehicleAttributes>();
			V_BC = other.gameObject.GetComponent<BoxCollider>();
			Ex_P.PrefabMax = ScoreManager.pass;
			Ex_P.InstantiatePrefabs = true;
			ScoreManager.score += 12;
			ScoreManager.score -= V_A.Size;
			ScoreManager.pass = 0;
			FU_J.Pass_Count = 0;
			FU_J.Delete_Legs = true;
			jeep.currentHealth -= V_A.Size;
			jeep.currentMulti = 1;
			multiplier = 0;
			V_BC.enabled = false;
			print (ScoreManager.score);
			print (ScoreManager.pass);
		}
		
		else if (other.tag == "PowerUp") {
			ScoreManager.score += 120;
			PowerUps P_up = other.GetComponent<PowerUps>();
			GameObject Power_Up = other.gameObject;
			source.PlayOneShot(clip[0], 0.5f);
			//AudioSource.PlayClipAtPoint(clip[0], Camera.main.transform.position);
			//if(P_up.Sub_Tag == "Shield")
			//{
			shieldGauge.visible = true;
			print("Picked up shield");
			Destroy(Power_Up);
			//}
		}
		
		else if (other.tag == "Checkpoint"){
			source.PlayOneShot(clip[2]);
			if(multiplier != 0) //updated in build 148
			{
				ScoreManager.score = ScoreManager.score * multiplier;//updated in build 148
			}	//updated in build 148 (taking checkpoint with 0 multiplier no longer causes total score to go back to 0)
			multiplier = 0;
			ScoreManager.pass = 0;
			FU_J.Pass_Count = 0;
			FU_J.Delete_Legs = true;
			jeep.currentHealth = jeep.maxHealth;
			//AudioSource.PlayClipAtPoint(clip[2], Camera.main.transform.position);
		}
	}
}