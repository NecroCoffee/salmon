using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    //[SerializeField] private GameObject explosiveEffect;

    [SerializeField] private int score = 500;
    [SerializeField] private int hp = 10;
    [SerializeField] private float speed = 1f;

    private Transform _cachedTransForm;
    private Rigidbody2D _cachedRigidBody2D;
    private float objectSpeed;

    private BuildingStatus thisBuildingStatus;

    /// <summary>
    /// 生成時初期化処理+etc...
    /// </summary>
    private void Awake()
    {
        _cachedTransForm = this.gameObject.transform;
        _cachedRigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        thisBuildingStatus= new BuildingStatus(score, hp, speed);

        //GM探索処理を改善するべし
        //例えば他のGMオブジェクト変数を保持するそのシーン中に絶対に破棄されないオブジェクトから持ってくるとか
        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
        objectSpeed = gameManager.gameSpeed;
        thisBuildingStatus.speed = objectSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("SalmonEgg"))
        {
            thisBuildingStatus.hp--;
            Destroy(collisionGameObject);
        }
    }

    private void Update()
    {
        objectSpeed = gameManager.gameSpeed;
        thisBuildingStatus.speed = objectSpeed;

        if (thisBuildingStatus.hp <= 0)
        {
            gameManager.bonusScore += thisBuildingStatus.score;
            //Instantiate(explosiveEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        _cachedTransForm.position += new Vector3(thisBuildingStatus.speed * (-1), 0, 0) * Time.fixedDeltaTime;
    }

    


}
