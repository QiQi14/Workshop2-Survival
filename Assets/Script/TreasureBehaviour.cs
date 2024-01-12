using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class TreasureBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Healingg");
            PlayerBehavior playerBehavior = collision.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.HealingHealth(playerBehavior.maxHP / 300);

        }
    }
}
