using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceData : MonoBehaviour
{
    [HideInInspector] public StageManagement SM;
    [HideInInspector] public float DestroyTimer;
    public float waitingShedChance;
    private float waitingShedRoll;
    public GameObject waitingShed;
    public Transform shedSpawnPoint;
    public GameObject shedHolder;
    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManagement>();
        Invoke("DestroyThisObj",DestroyTimer);
        waitingShedRoll = Random.Range(0, 100);
        //Debug.Log(waitingShedRoll);
        if(waitingShedRoll <= waitingShedChance)
        {
            Debug.Log("Waiting Shed spawned");
            shedHolder = Instantiate(waitingShed,shedSpawnPoint.position,Quaternion.identity);
            shedHolder.transform.SetParent(shedSpawnPoint);
        }
    }

   void DestroyThisObj()
    {
        SM.removeSetPieces.Add(this.gameObject);
        foreach (GameObject setPiece in SM.removeSetPieces)
        {
            SM.spawnedSetPieces.Remove(setPiece);
            Destroy(this.gameObject);
        }
    }
}
