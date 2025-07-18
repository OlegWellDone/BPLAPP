using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject coin;

    bool isRotated = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        coin.transform.Rotate(coin.transform.rotation.x,-1f,coin.transform.rotation.z );
    }
}