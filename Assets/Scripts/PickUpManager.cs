using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public GameObject[] pickUpPrefabs;
    public GameObject passenger;
    public Vector3[] spawnPoints;
    public float pickUpMS;
    public float spawnRate;
    public float objDur;
    public float pickUpSpeed;
    public int passAmt; //amount of passengers to spawn before a waiting shed spawns
    private int passCount;
    private GameObject tempHolder;
    private int passengerChance;
    public List<GameObject> pickUpList = new List<GameObject>();
    [HideInInspector]public List<GameObject> removePickUpList = new List<GameObject>();
    [HideInInspector] public PickUpsData PD;
    [HideInInspector] public int prefabID;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPassengers",0,spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        MovePickUps();
    }

    void MovePickUps()
    {
        for (int i = 0; i < pickUpList.Count; i++)
        {
            if (pickUpList[i] != null)
            {
                pickUpList[i].transform.position += (Vector3.back * pickUpSpeed) * Time.deltaTime;
            }
        }
    }
    void SpawnPassengers()
    {
        passengerChance = Random.Range(0, 100);
        if (passengerChance <= 40)
        {
                passCount++;
                tempHolder = Instantiate(passenger, spawnPoints[3], Quaternion.identity);
                pickUpList.Add(tempHolder);
                PD = tempHolder.GetComponent<PickUpsData>();
                PD.expireTimer = objDur;

        }
        
        
    }

    
}
