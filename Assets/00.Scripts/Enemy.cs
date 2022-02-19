using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject stoneParticle;
    
    
    
    //다른 충돌체와 충돌하면
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.GameOver();
        }

        if (other.CompareTag("Plane"))
        {
            var go =  Instantiate(stoneParticle);
            go.transform.position = transform.position;
            GameManager.Instance.EvadeCount++;
            Destroy(this.gameObject);
        }
    }
}
