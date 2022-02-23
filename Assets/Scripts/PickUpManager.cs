using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public GameObject[] pickUpPrefabs;
    public Vector3[] spawnPoints;
    public float pickUpMS;
    public float spawnRate;
    public float objDur;
    public List<GameObject> pickUpList = new List<GameObject>();
    [HideInInspector]public List<GameObject> removePickUpList = new List<GameObject>();
    [HideInInspector] public int prefabID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
