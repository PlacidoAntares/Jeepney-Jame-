using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour
{
    [HideInInspector]public ObstacleManager OM;
    [HideInInspector] public float DestroyTimer;
    [HideInInspector] public ScoreHolder SH;
    public string VehicleName;
    // Start is called before the first frame update
    void Start()
    {
        OM = GameObject.FindGameObjectWithTag("ObstacleManager").GetComponent<ObstacleManager>();
        SH = GameObject.Find("ScoreManager").GetComponent<ScoreHolder>();
        Invoke("DestroyThisObj", DestroyTimer);
    }


    void DestroyThisObj()
    {
        OM.removeObstacles.Add(this.gameObject);
        foreach (GameObject obstacle in OM.removeObstacles)
        {
            OM.spawnedObstacles.Remove(obstacle);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            if (SH.Score > 0)
            {
                if (VehicleName == "Car")
                {
                    SH.Score /= 2;
                    SH.passCount /= 2;
                }
                else if(VehicleName == "Bus")
                {
                    SH.Score = 0;
                    SH.passCount = 0;
                }               
            }

        }
        OM.removeObstacles.Add(this.gameObject);
        foreach (GameObject obstacle in OM.removeObstacles)
        {
            OM.spawnedObstacles.Remove(obstacle);   
            Destroy(this.gameObject,1.5f);
        }
        
    }
}
