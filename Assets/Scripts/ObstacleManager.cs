using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstaclePrefabs;
    private GameObject tempHolder;
    public Vector3[] obstacleSpawnPoints;
    public float obstacleSpawnRate;
    public float obstacleDur;
    public float obstacleSpeed;
    private int obstacleID;
    private int spawnPointID;
    public List<GameObject> spawnedObstacles = new List<GameObject>();
    [HideInInspector] public List<GameObject> removeObstacles = new List<GameObject>();
    [HideInInspector] public ObstacleData OD;
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 0.0f, obstacleSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacles();
    }

    void MoveObstacles()
    {
        for (int i = 0; i < spawnedObstacles.Count; i++)
        {
            if (spawnedObstacles[i] != null)
            {
                spawnedObstacles[i].transform.position += (Vector3.back * obstacleSpeed) * Time.deltaTime;
            }
        }
    }
    void SpawnObstacles()
    {
        obstacleID = Random.Range(0,obstaclePrefabs.Length);
        spawnPointID = Random.Range(0,obstacleSpawnPoints.Length);
        tempHolder = Instantiate(obstaclePrefabs[obstacleID],obstacleSpawnPoints[spawnPointID], Quaternion.identity);
        spawnedObstacles.Add(tempHolder);
        OD = tempHolder.GetComponent<ObstacleData>();
        OD.DestroyTimer = obstacleDur;
    }
}
