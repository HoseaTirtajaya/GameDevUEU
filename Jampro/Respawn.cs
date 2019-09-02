using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold = -10f;
    private void FixedUpdate()
    {
        if (transform.position.y <= threshold)
        {
            transform.position = new Vector3(-3.95f, 3.1f, 6.5f);
        }
    }
}
