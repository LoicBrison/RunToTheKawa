using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 mouvement;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float speedLeftRight = 5.0f;

    Rigidbody r;
    bool grounded = true;
    Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        defaultScale = transform.localScale;
        jump = new Vector3(0.0f, 2.0f, 1.0f);
    }

    void Update()
    {
        // Jump
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            r.AddForce(jump * jumpForce, ForceMode.Impulse);
            grounded = false;
            Debug.Log("Jump");
        }

        
        if(transform.position.x > -2f && transform.position.x < 2f)
        {
            mouvement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            r.MovePosition(transform.position+(mouvement * speedLeftRight * Time.deltaTime));
        }
        else{
            if(transform.position.x < -2f)
            {
                mouvement = new Vector3(1.0f, 0.0f, 0.0f);
                r.MovePosition(transform.position+(mouvement * speedLeftRight * Time.deltaTime));
            }
            else if(transform.position.x > 2f)
            {
                mouvement = new Vector3(-1.0f, 0.0f, 0.0f);
                r.MovePosition(transform.position+(mouvement * speedLeftRight * Time.deltaTime));
            }
        }


    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            //print("GameOver!");
            GroundGenerator.instance.gameOver = true;
        }
    }
}
