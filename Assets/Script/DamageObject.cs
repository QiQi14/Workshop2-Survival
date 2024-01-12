using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            PlayerBehavior playerBehavior = collision.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceiveDamage(20);
        }
    }

}
