using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public void Open()
    {
        transform.rotation = new Quaternion(0, 170, 0, 0);
    }
}
