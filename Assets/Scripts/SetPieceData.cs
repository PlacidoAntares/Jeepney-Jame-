using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceData : MonoBehaviour
{
    [HideInInspector] public StageManagement SM;
    [HideInInspector] public float DestroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManagement>();
        Invoke("DestroyThisObj",DestroyTimer);
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
