using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="car")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore(1);
        }
    }
}