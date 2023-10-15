using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject gameManagaerObject;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Transform thisTransform;

    [SerializeField] private float eggLiveTimer = 5f;

    private float gameSpeed;

    [SerializeField]
    private float force = 1f;
    private Rigidbody2D rig;

    

    private void OnEnable()
    {
        thisTransform = this.gameObject.transform;
        gameManagaerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagaerObject.GetComponent<GameManager>();
        gameSpeed = gameManager.gameSpeed;
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        Destroy(this.gameObject, eggLiveTimer);

    }

    
    






}