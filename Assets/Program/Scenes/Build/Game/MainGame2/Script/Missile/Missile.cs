using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missile移動用スクリプト
/// </summary>
public class Missile : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float defaultSpeed = 0.5f;
    [SerializeField] private float speedCoefficient=1.1f;
    [SerializeField] private int currentFrame=0;
    [SerializeField] private int speedUpFrame=30;
    [SerializeField] private int speedUpLimit = 3;
    [SerializeField] private float missileSpeed;


    private void OnBecameInvisible()
    {
        Destroy(this.gameObject, 3f);
    }

    private void Awake()
    {
        
        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
        missileSpeed = gameManager.gameSpeed;
        velocity = gameObject.transform.rotation * new Vector3(defaultSpeed * missileSpeed, 0, 0);
    }

    

    private void FixedUpdate()
    {
        velocity = gameObject.transform.rotation * new Vector3(defaultSpeed * missileSpeed, 0, 0);

        this.gameObject.transform.position += velocity * Time.deltaTime;
    }
}
