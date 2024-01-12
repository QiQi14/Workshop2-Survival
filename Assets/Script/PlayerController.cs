using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;
    
    Rigidbody2D rb;

    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    private PlayerBehavior behaviour;

    [SerializeField] private AudioSource swordFlash;
    [SerializeField] private AudioSource playerRunning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        behaviour = GetComponent<PlayerBehavior>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (behaviour.currentHP > 0)
        {
            if (canMove)
            {
                if (movementInput != Vector2.zero)
                {
                    bool success = TryMove(movementInput);

                    if (!success)
                    {
                        success = TryMove(new Vector2(movementInput.x, 0));

                    }
                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }

                    animator.SetBool("isMoving", success);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }

                //Set direction of sprite to movement direction

                if (movementInput.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (movementInput.x > 0)
                {
                    spriteRenderer.flipX = false;
                }

            }

            if (movementInput.x != 0 || movementInput.y != 0)
            {
                behaviour.StaminaChange(-behaviour.maxSP / 300);
            }
            else
            {
                behaviour.StaminaChange(behaviour.maxSP / 100);

            }
        }

    }

    private bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            int count = rb.Cast(
        direction,
        movementFilter,
        castCollisions,
        moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                playerRunning.Play();
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack"); 
    }
    
    public void SwordAttack()
    {
        if (behaviour.currentHP > 0)
        {
            swordFlash.Play();
            LockMovement();
            if (spriteRenderer.flipX == true)
            {
                swordAttack.AttackLeft();
            }
            else
            {
                swordAttack.AttackRight();

            }
        }

    }

    public void EndSwordAttack()
    {
        UnLockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnLockMovement()
    {
        canMove = true;
    }
}
