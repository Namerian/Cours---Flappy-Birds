using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BirdController : MonoBehaviour
{
    public float horizontalSpeed = 1;
    public float verticalForce = 1;
    public float gravityScale = 1;

    private GameController gameController;

    private float maxY_Pos;
    private Rigidbody2D rigidbody;

    public bool isAlive { get; private set; }
    public int score { get; set; }

    private bool isOnTheGround;

    // Use this for initialization
    void Start()
    {
        gameController = Camera.main.GetComponent<GameController>();

        maxY_Pos = Camera.main.orthographicSize - this.GetComponent<CircleCollider2D>().radius;
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isRunning && isAlive)
        {
            // horizontal movement
            Vector3 _cameraMovement = new Vector3();
            _cameraMovement.x = horizontalSpeed * Time.deltaTime;
            Camera.main.transform.Translate(_cameraMovement);

            // vertical movement
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody.velocity = new Vector2(0f, 0f);

                rigidbody.AddForce(new Vector2(0f, verticalForce));
            }
        }
        else if(gameController.isRunning && !isAlive && isOnTheGround)
        {
            //Debug.Log("dead player hit the ground");

            gameController.OnBirdDied();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            isAlive = false;

            //Debug.Log("Player died!");
        }
        else if (collision.collider.tag == "ScreenBottom")
        {
            isOnTheGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ScreenBottom")
        {
            isOnTheGround = false;
        }
    }

    //==============================================================================

    public void OnStartGame()
    {
        isAlive = true;
        score = 0;
        rigidbody.gravityScale = this.gravityScale;

        Vector3 _position = this.transform.localPosition;
        _position.y = 0f;
        this.transform.localPosition = _position;

        Camera.main.transform.position = new Vector3(0f,0f,-10f);
    }
}
