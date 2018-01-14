using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBarrier : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
