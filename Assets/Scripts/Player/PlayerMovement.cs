using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [HideInInspector]
    public float lastHorizontal;

    [HideInInspector]
    public float lastVertical;

    [HideInInspector]
    public Vector2 moveDir;

    //References
    Rigidbody2D rb;
    public CharacterScriptableobject characterData;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(moveX, moveY, 0).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontal = moveDir.x;
        }

        if (moveDir.y != 0)
        {
            lastVertical = moveDir.y;
        }
    }

    void Move()
    {
        rb.velocity = new Vector3(moveDir.x * characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed,0);
    }
}
