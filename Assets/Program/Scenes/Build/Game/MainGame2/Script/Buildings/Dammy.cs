using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammy : MonoBehaviour
{
    
    [SerializeField]private GameManager GameManager;

    private Transform _cachedTransForm;
    private Rigidbody2D _cachedRigidBody2D;
    private float objectSpeed;

    private BuildingStatus BuildingStatus = new BuildingStatus(500, 5, 1);

    private void Awake()
    {
        _cachedTransForm = this.gameObject.transform;
        _cachedRigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        GameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
        objectSpeed = GameManager.gameSpeed;
        BuildingStatus.speed = objectSpeed;
    }

    private void Update()
    {
        objectSpeed = GameManager.gameSpeed;
        BuildingStatus.speed = objectSpeed;
    }

    private void FixedUpdate()
    {
        _cachedTransForm.position += new Vector3(BuildingStatus.speed * (-1), 0, 0) * Time.fixedDeltaTime;
    }


}
