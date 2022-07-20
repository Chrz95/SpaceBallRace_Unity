using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{

    public float speed;
    public static float MoveObstacleUpDown;

    void Start()
    {
        MoveObstacleUpDown = 10;
    }

    void FixedUpdate()
    {
        if (transform.localPosition.y >= 1.9)
        {
            speed = -MoveObstacleUpDown;
        }
        else if (transform.localPosition.y <= 0.1)
        {
            speed = MoveObstacleUpDown;
        }
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

}
