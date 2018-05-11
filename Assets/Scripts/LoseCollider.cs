using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{

    public LevelManager LevelManager;

    void OnTriggerEnter2D (Collider2D trigger)
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.LoadLevel("Lose Screen");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
