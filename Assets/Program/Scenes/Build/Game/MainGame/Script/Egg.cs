using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField]
    private float force = 1f;
    private Rigidbody2D rig;

    private void EggMove()
    {

    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        Destroy(this.gameObject, 3f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collisionGameObject);
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
    }

    

    private void FixedUpdate()
    {

    }


}