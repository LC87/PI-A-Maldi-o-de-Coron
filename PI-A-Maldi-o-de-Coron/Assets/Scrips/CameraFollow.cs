using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Follow;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float FollowXPosition = Follow.transform.position.x;
        float FollowYPosition = Follow.transform.position.y;
        transform.position = new Vector3(FollowXPosition, FollowYPosition, -10);
    }
}
