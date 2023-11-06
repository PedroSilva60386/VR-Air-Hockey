using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereResetter : MonoBehaviour
{
    public Transform resetArea;
    
    void Start()
    {
        // Reset the sphere's position when the game starts
        ResetSpherePosition();
    }

    void ResetSpherePosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(resetArea.position.x, resetArea.position.x + resetArea.localScale.x),
            Random.Range(resetArea.position.y, resetArea.position.y + resetArea.localScale.y),
            Random.Range(resetArea.position.z, resetArea.position.z + resetArea.localScale.z)
        );

        transform.position = randomPosition;
    }
}