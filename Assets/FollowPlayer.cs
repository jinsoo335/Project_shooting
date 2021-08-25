using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    void Update()
    {
        followPlayer();
       
    }

    void followPlayer()
    {
        Vector3 position = player.transform.position;
        position.Set(player.transform.position.x, player.transform.position.y, transform.position.z);
        camera.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
