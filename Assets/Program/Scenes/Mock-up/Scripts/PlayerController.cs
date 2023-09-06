using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの挙動用スクリプト
/// </summary>
public class PlayerController : MonoBehaviour
{
    //ゲームオブジェクト用変数
    [SerializeField]
    private GameObject eggPrefab;
    [SerializeField]
    private GameObject eggHole;

    //コンポーネント用変数
    [SerializeField]
    private ConstantForce2D constantForce2D;
    [SerializeField]
    private ConstantForce2D subConstantForce2D;

    //egg管理用変数
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 force;

    private void generateEgg()
    {
        eggPrefab = Instantiate(eggPrefab) as GameObject;
        force = this.gameObject.transform.up * -1 * speed;
        eggPrefab.GetComponent<Rigidbody2D>().AddForce(force);
        eggPrefab.transform.position = eggHole.transform.position;
    }

    private void activeConstantForce()
    {
        constantForce2D.enabled = true;
        subConstantForce2D.enabled = true;
    }

    private void disableConstantForce()
    {
        constantForce2D.enabled = false;
        subConstantForce2D.enabled = false;
    }

    private void Awake()
    {
        constantForce2D.enabled = false;
        subConstantForce2D.enabled = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            activeConstantForce();
            generateEgg();
        }

        if (Input.GetMouseButtonUp(0))
        {
            disableConstantForce();
        }
    }
}
