using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammy : MonoBehaviour
{
    
    [SerializeField]private GameManager gameManager;

    private Transform _cachedTransForm;
    private Rigidbody2D _cachedRigidBody2D;
    private float objectSpeed;

    private BuildingStatus BuildingStatus = new BuildingStatus(500, 10, 1);

    private void Awake()
    {
        _cachedTransForm = this.gameObject.transform;
        _cachedRigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
        objectSpeed = gameManager.gameSpeed;
        BuildingStatus.speed = objectSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("SalmonEgg"))
        {
            BuildingStatus.hp--;
            Destroy(collisionGameObject);
        }
    }

    private void Update()
    {
        objectSpeed = gameManager.gameSpeed;
        BuildingStatus.speed = objectSpeed;

        if (BuildingStatus.hp <= 0)
        {
            gameManager.bonusScore += BuildingStatus.score;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        _cachedTransForm.position += new Vector3(BuildingStatus.speed * (-1), 0, 0) * Time.fixedDeltaTime;
    }


}
