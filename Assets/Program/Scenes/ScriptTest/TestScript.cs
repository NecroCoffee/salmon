using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aPlayerScript : MonoBehaviour
{

    //�f�o�b�O�pbool�ϐ�
    [SerializeField]
    private bool debugIsShootEgg = true;//�C�N���ˏo��
    [SerializeField]
    private bool debugIsMove = true;//XY�ړ���


    //�I�u�W�F�N�g�p�ϐ�

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject childrenObject;
    [SerializeField]
    private GameObject childrenObjectLookTarget;


    //

    //�l�^�ϐ�
    
    private float shootEggAngle;//���ˏo�p�x�͈�

    [SerializeField]
    private float pushForce = 1f;//���i��

    [SerializeField]
    private float pushAngle;//�����΂�����
    

    //vector�^�ϐ�
    private Vector3 chilldrenObjectPos;//�q�I�u�W�F�N�g�ʒu

    //���u�� �m�F�p
    //PushForce()�Ŏg�p����vector2 forceDirection
    [SerializeField]
    Vector2 forceDirection;


    //�R���|�[�l���g�p�ϐ�

    private Rigidbody2D rig;

    //

    
    [SerializeField]
    public float angle;//�I�u�W�F�N�g�̌���

    //�f�o�b�O�p

    //----------

    private void DebugMoveStop()
    {
        if (debugIsMove == false)
        {
            rig.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
    


    
    //
   
   private float GetAngle(Vector3 from,Vector3 to)
    {
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);

        return rad * Mathf.Rad2Deg;
    }


    /// <summary>
    /// �}�E�X�̕����Ɍ�������
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


    private void rotateChildrenObject()//�C�N�����ˌ���]
    {
        Vector3 toDirection = (childrenObjectLookTarget.transform.position - childrenObject.transform.position);
        childrenObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
    }

    private void GeneratePrefab()//�C�N���ˏo
    {
        shootEggAngle = this.gameObject.transform.rotation.z * (-1); 
        angle = Random.Range(((shootEggAngle * -1)/2), (shootEggAngle/2));
        Quaternion quaternion = Quaternion.Euler(0, 0, angle);
        GameObject gameObject = Instantiate(prefab, chilldrenObjectPos, quaternion) as GameObject;
        gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.forward, ForceMode2D.Impulse);

        //���������̂��߈�U����R�����g�A�E�g
        
        //float childrenObjectAngle = childrenObject.gameObject.transform.rotation.z;

        //float angleRange = Random.Range(childrenObjectAngle - shootEggAngle, childrenObjectAngle + shootEggAngle);
        //--------------------------------------


    }

    

    private void PushForce()
    {

        //pushForce ������(�����l:1)
        //forceDirection ��������

        //Vector2 forceDirection;

        pushAngle = this.gameObject.transform.eulerAngles.z;//x=+1,y=+1�ɂ������̂ł�����[-135(�E��������Ă���)]�������Ă���ƍl����
        Debug.Log(pushAngle);

        float pushRad = pushAngle * Mathf.Deg2Rad;

        Vector2 forceDirection = new Vector2((Mathf.Cos(pushRad)) * -1, (Mathf.Sin(pushRad)) * -1);
        Debug.Log(forceDirection);

        forceDirection = new Vector2(forceDirection.x * pushForce, forceDirection.y * pushForce);

        rig.AddForce(forceDirection, ForceMode2D.Impulse);


        
        
    }



    private void Awake()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        chilldrenObjectPos = childrenObject.transform.localPosition;

        //�f�o�b�O�p rig��XY���Œ�
        DebugMoveStop();

        
    }

    
    

    private void FixedUpdate()
    {
        chilldrenObjectPos = childrenObject.transform.position;

        lookAtMouse();
        rotateChildrenObject();

        if (Input.GetMouseButton(0))
        {
            PushForce();

            if (debugIsShootEgg==true)
            {
                GeneratePrefab();//�C�N������
            }
        }

        
    }
}
