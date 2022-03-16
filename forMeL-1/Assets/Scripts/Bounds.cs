using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var kart = collision.transform.parent.GetComponentInChildren<KartAgent>();
            kart.SetReward(-1f);
            kart.EndEpisode();
        }
    }
}
