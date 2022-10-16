using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    public GameObject Target;
    public float cameraY = 25.3f;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.transform.position.x, cameraY, -31.5f);
    }
}
