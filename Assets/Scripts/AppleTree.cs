using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Prefab for instantiating apples
    public GameObject applePrefab;
    
    // Speed at which the AppleTree moves
    public float speed = 1f;
    
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    //a

    void Start()
    {
        // Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position; // b
        pos.x += speed * Time.deltaTime; // c
        transform.position = pos; // d

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        { 
            speed = Mathf.Abs(speed); // Move right 
        }
        else if (pos.x > leftAndRightEdge)
        { 
            speed = - Mathf.Abs(speed); // Move left 
        }

    }

    void FixedUpdate()
    {
        // Changing direction randomly is now time based, not frame based thanks to FixedUpdate
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Change direction
        }
    }
}