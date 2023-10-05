using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Body : MonoBehaviour
{
    [SerializeField] private GameObject enemy2Object;

    [SerializeField] private Enemy2 enemy2Script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.gameObject.CompareTag("PlayerBullet"))
        {
            enemy2Script.enemy2HP -= 1;
        }
    }
}
