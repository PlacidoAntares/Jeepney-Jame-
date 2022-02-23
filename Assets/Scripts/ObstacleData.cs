using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour
{
    [HideInInspector]public ObstacleManager OM;
    [HideInInspector] public float DestroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        OM = GameObject.FindGameObjectWithTag("ObstacleManager").GetComponent<ObstacleManager>();
        Invoke("DestroyThisObj", DestroyTimer);
    }


    void DestroyThisObj()
    {
        OM.removeObstacles.Add(this.gameObject);
        foreach (GameObject setPiece in OM.removeObstacles)
        {
            OM.spawnedObstacles.Remove(setPiece);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OM.removeObstacles.Add(this.gameObject);
        foreach (GameObject setPiece in OM.removeObstacles)
        {
            OM.spawnedObstacles.Remove(setPiece);
    
            Destroy(this.gameObject,1.5f);
        }
    }
}
