using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    Food food;

    private void Start()
    {
        food = gameObject.AddComponent<Food>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            food.RandomizePosition();
        }
    }
}
