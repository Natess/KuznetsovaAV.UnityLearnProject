using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var player = Component.FindObjectOfType<Player>();
        transform.position = player.transform.position + new Vector3(0, 1, 0);//new Vector3(-1f, 2, 0);
        transform.rotation = player.transform.rotation;//new Quaternion(player.transform.rotation.x, 90, 0, 0);
    }
}
