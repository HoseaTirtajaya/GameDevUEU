using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnA : MonoBehaviour
{
    [SerializeField] private Transform obstacle;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        obstacle.transform.position = respawnPoint.transform.position;
    }
}
