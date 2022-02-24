using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagement : MonoBehaviour
{
    public GameObject[] setPieces;
    public int setPiecesMaxAmt;
    private int setPiecesAmt;
    private GameObject tempHolder;
    [HideInInspector]public int setPieceID;
    public float moveSpeed;
    public float setPieceTimer;
    public float setPieceSpawnRate;
    public Vector3[] initSetPieceSpawnPoint;
    public Vector3 setPieceSpawnPoint;
    public List<GameObject> spawnedSetPieces = new List<GameObject>();
    [HideInInspector] public List<GameObject> removeSetPieces = new List<GameObject>();
    private SetPieceData SPD;
    // Start is called before the first frame update
    void Start()
    {
        InitialSetPiece();
        
        InvokeRepeating("SpawnSetPiece",0.0f,setPieceSpawnRate);
    }

    private void Update()
    {
        MoveSetPieces();       
    }

    void SpawnSetPiece()
    {
        setPieceID = Random.Range(0,setPieces.Length);
        tempHolder = Instantiate(setPieces[setPieceID],setPieceSpawnPoint,Quaternion.identity);
        spawnedSetPieces.Add(tempHolder);
        SPD = tempHolder.GetComponent<SetPieceData>();
        SPD.DestroyTimer = setPieceTimer;
    }

    void InitialSetPiece()
    {
        while (setPiecesAmt < setPiecesMaxAmt)
        {
            setPieceID = Random.Range(0, setPieces.Length);
            tempHolder = Instantiate(setPieces[setPieceID], initSetPieceSpawnPoint[setPiecesAmt], Quaternion.identity);
            spawnedSetPieces.Add(tempHolder);
            SPD = tempHolder.GetComponent<SetPieceData>();
            SPD.DestroyTimer = setPieceTimer;
            setPiecesAmt++;
        }
        
    }

    void MoveSetPieces()
    {
        for (int i = 0; i < spawnedSetPieces.Count; i++)
        {
            if (spawnedSetPieces[i] != null)
            {
                spawnedSetPieces[i].transform.position += (Vector3.back * moveSpeed) * Time.deltaTime;
            }
        }
    }

    
}
