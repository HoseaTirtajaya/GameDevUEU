using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraCtr : MonoBehaviour
{
    public List<Transform> players;        //Public variable to store a reference to the player game object
    public Vector3 offset; //Private variable to store the offset distance between the player and camera
    private Vector3 velocity;

    public float smoothTime = 0.5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Camera cam;

    public float deadMetre;

    public void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    private void Update()
    {
        GetGreatestDista();
        deadMetre = GetGreatestDista();
    }
    private void LateUpdate()
    {
        if (players.Count == 0)
        {
            return;
        }

        MoveCam();
        ZoomCam();

    }

    void ZoomCam()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDist() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void MoveCam()
    {
        Vector3 Centerpoint = GetCenterPoint();

        Vector3 newPosition = Centerpoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDist()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);

        for (int i = 0; i < players.Count; i++)
        {
            bounds.Encapsulate(players[i].position);
        }

        return bounds.size.z;
    }



    private Vector3 GetCenterPoint()
    {
        if (players.Count == 1)
        {
            return players[0].position;
        }

        var bounds = new Bounds(players[0].position, Vector3.zero);

        for (int i = 0; i < players.Count; i++)
        {
            bounds.Encapsulate(players[i].position);
        }

        return bounds.center;
    }

    float GetGreatestDista()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);

        for (int i = 0; i < players.Count; i++)
        {
            bounds.Encapsulate(players[i].position);
        }

        return bounds.size.z;

    }
}
