using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //デバッグ用bool変数
    [SerializeField]
    private bool debugIsShootEgg = true;//イクラ射出可否
    [SerializeField]
    private bool debugIsMove = true;//XY移動可否



    //オブジェクト用変数


    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject childrenObject;
    [SerializeField]
    private GameObject childrenObjectLookTarget;


    

    //値型変数

    
    private float shootEggAngle;//卵射出角度範囲

    [SerializeField]
    private float pushForce = 1f;//推進力

    [SerializeField]
    private float pushAngle;//鮭を飛ばす方向

    //右クリック用チャージ変数

    [SerializeField]
    private bool isAssaultMode = false;//チャージ攻撃をしているかどうか

    [SerializeField]
    private bool isAssaultCharged = false;//チャージ攻撃中かどうか

    [SerializeField]
    private Vector3 salmonSaveposition=new Vector3();//Salmonチャージ攻撃用座標保存変数

    [SerializeField]
    private float assaultForce = 0f;//チャージ量

    

    [SerializeField]
    private float assaultVelocity = 0f;//フレームあたりの加速度

    [SerializeField]
    private float assaultForceMax = 10f;//チャージ量上限

    [SerializeField]
    private float assaultChargeFrameMax = 180f;//最大チャージ所要フレーム数

    [SerializeField]
    private float assaultForceChargeFramePer = 0f;//位置フレームあたりのチャージ加算量

    //vector型変数
    private Vector3 chilldrenObjectPos;//子オブジェクト位置

    //仮置き 確認用
    //PushForce()で使用するvector2 forceDirection
    [SerializeField]
    Vector2 forceDirection;


    //コンポーネント用変数

    private Rigidbody2D rig;

    //


    [SerializeField]
    public float angle;//オブジェクトの向き

    //デバッグ用

    //----------

    private void DebugMoveStop()
    {
        if (debugIsMove == false)
        {
            rig.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }




    //

    private float GetAngle(Vector3 from, Vector3 to)
    {
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);

        return rad * Mathf.Rad2Deg;
    }


    /// <summary>
    /// マウスの方向に向かせる
    /// </summary>
    private void lookAtMouse()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - screenPos;
        var angle = GetAngle(Vector3.zero, direction);
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }


    private void rotateChildrenObject()//イクラ発射口回転
    {
        Vector3 toDirection = (childrenObjectLookTarget.transform.position - childrenObject.transform.position);
        childrenObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
    }

    private void GeneratePrefab()//イクラ射出
    {
        shootEggAngle = this.gameObject.transform.rotation.z * (-1);
        angle = Random.Range(((shootEggAngle * -1) / 2), (shootEggAngle / 2));
        Quaternion quaternion = Quaternion.Euler(0, 0, angle);
        GameObject gameObject = Instantiate(prefab, chilldrenObjectPos, quaternion) as GameObject;
        gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.forward, ForceMode2D.Impulse);

        //書き換えのため一旦上をコメントアウト

        //float childrenObjectAngle = childrenObject.gameObject.transform.rotation.z;

        //float angleRange = Random.Range(childrenObjectAngle - shootEggAngle, childrenObjectAngle + shootEggAngle);
        //--------------------------------------


    }



    private void PushForce()
    {

        //pushForce 押す力(初期値:1)
        //forceDirection 押す方向

        //Vector2 forceDirection;

        pushAngle = this.gameObject.transform.eulerAngles.z;//x=+1,y=+1にしたいのでここに[-135(右上を向いている)]が入っていると考える
        Debug.Log(pushAngle);

        float pushRad = pushAngle * Mathf.Deg2Rad;

        Vector2 forceDirection = new Vector2((Mathf.Cos(pushRad)) * -1, (Mathf.Sin(pushRad)) * -1);
        Debug.Log(forceDirection);

        forceDirection = new Vector2(forceDirection.x * pushForce, forceDirection.y * pushForce);

        rig.AddForce(forceDirection, ForceMode2D.Impulse);




    }

    //右クリック突撃用座標保存
    private void SalmonSavePosition()
    {
        salmonSaveposition = this.gameObject.transform.position;
    }

    //右クリック突撃チャージ
    private void SalmonAssaultCharge()
    {
        rig.gravityScale = 0f;
        rig.velocity = Vector2.zero;

        

        if (assaultForceChargeFramePer <= 0f)
        {
            assaultForceChargeFramePer = assaultForceMax / assaultChargeFrameMax;
        }

        isAssaultMode = true;
        

        if (assaultForce <= assaultForceMax)
        {
            assaultForce += assaultForceChargeFramePer;

            if (assaultForce >= assaultForceMax)
            {
                assaultForce = assaultForceMax;
            }
        }
        
    }

    //右クリック突撃
    private void SalmonAssault()
    {
        rig.gravityScale = 1f;
        rig.velocity = new Vector2(rig.velocity.x + (assaultForceChargeFramePer * Mathf.Sign(this.transform.rotation.z)),
                                   rig.velocity.y + (assaultForceChargeFramePer * Mathf.Sign(this.transform.rotation.z)));

        assaultForce -= assaultForceChargeFramePer;

        if (assaultForce <= 0f)
        {
            rig.gravityScale = 1f;
            assaultForce = 0f;
            assaultForceChargeFramePer = 0f;
            isAssaultMode = false;
            isAssaultCharged = false;

            return;
        }
        
    }

    //
    private void Awake()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        chilldrenObjectPos = childrenObject.transform.localPosition;

        //デバッグ用 rigのXYを固定
        DebugMoveStop();


    }




    private void FixedUpdate()
    {
        chilldrenObjectPos = childrenObject.transform.position;

        if (isAssaultMode == false && isAssaultCharged == false)
        {
            lookAtMouse();
            rotateChildrenObject();
        }
        

        if (Input.GetMouseButton(0) && isAssaultMode==false)
        {
            PushForce();

            if (debugIsShootEgg == true)
            {
                GeneratePrefab();//イクラ生成
            }

        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    SalmonAssaultCharge();
        //}

        //if (Input.GetMouseButtonUp(1))
        //{
        //    SalmonAssault();
        //}

    }
}
