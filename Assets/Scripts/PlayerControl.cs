using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector3[] playerPositions;
    public Vector3[] playerLookVectors;
    public int playerLocId;
    public GameObject player;
    public Transform playerLook;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        SwapLanes();
    }

    void PlayerControls()
    {

    }
    void SwapLanes()
    {
        player.transform.LookAt(playerLook);
        //
        switch (playerLocId)
        {
            case 0:
                if (Vector3.Distance(player.transform.position, playerPositions[playerLocId]) < 8)
                {
                    playerLook.transform.transform.position = Vector3.MoveTowards(playerLook.position,playerLookVectors[playerLocId],(moveSpeed + 1) * Time.deltaTime);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,playerPositions[playerLocId],moveSpeed * Time.deltaTime);
                }
                break;
            case 1:
                if (Vector3.Distance(player.transform.position, playerPositions[playerLocId]) < 8.7f)
                {
                    playerLook.transform.transform.position = Vector3.MoveTowards(playerLook.position, playerLookVectors[playerLocId], (moveSpeed + 1) * Time.deltaTime);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, playerPositions[playerLocId], moveSpeed * Time.deltaTime);
                }
                break;
            case 2:
                if (Vector3.Distance(player.transform.position, playerPositions[playerLocId]) < 10)
                {
                    playerLook.transform.transform.position = Vector3.MoveTowards(playerLook.position, playerLookVectors[playerLocId], (moveSpeed + 1) * Time.deltaTime);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, playerPositions[playerLocId], moveSpeed * Time.deltaTime);
                }
                break;
        }
    }

    void rotateJeep()
    {

    }
}
