using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Under : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerObject;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float salmonEggBackMoveSpeed = 1f;

    private void Start()
    {
        gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rig2D = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rig2D != null)
        {
            if (collision.gameObject.CompareTag("SalmonEgg"))
            {
                //collision.gameObject.transform.Translate(new Vector3((gameManager.gameSpeed * (-1))*salmonEggBackMoveSpeed, 0, 0) * Time.fixedDeltaTime);
                Vector3 add = new Vector3(-1 * (gameManager.gameSpeed), 0, 0) * Time.fixedDeltaTime;
                rig2D.MovePosition(collision.gameObject.transform.position + add);
            }
        }
    }
}
