using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var player = Component.FindObjectOfType<Player>();
        transform.position = player.transform.position + new Vector3(0, 1, 0) + player.transform.forward * 0.15f; 
        transform.rotation = player.transform.rotation; 
    }
}
