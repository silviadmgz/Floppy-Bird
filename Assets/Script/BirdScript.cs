using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    [SerializeField] float flapStrengh;
    public LogicScript logic;
    public bool birdIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrengh;
        }

        if (transform.position.y > 12 || transform.position.y < -14)
        {
            logic.GameOver();
            birdIsAlive = false;            
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
