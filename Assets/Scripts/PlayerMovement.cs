using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float leftRightSpeed = 6f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        
        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.position.x > LevelBoundary.leftSide)
        {
            
            transform.Translate(Vector3.left * speed * Time.deltaTime * leftRightSpeed);
            
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.position.x < LevelBoundary.rightSide)
        {
            
            transform.Translate(Vector3.right * speed * Time.deltaTime * leftRightSpeed);
            
        }
    }
}
