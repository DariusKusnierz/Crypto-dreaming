using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    Camera camera;
    Transform transformOfCamera;
    [SerializeField] Transform followingObject;

    void Start()
    {
        camera = Camera.main;
        transformOfCamera = camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transformOfCamera.position = new Vector3(followingObject.position.x, followingObject.position.y, -10f);
    }
}
