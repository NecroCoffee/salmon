using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject MGM_Object;
    [SerializeField] private MainGameManager MGM_Script;    

    [SerializeField]
    private float force = 1f;
    private Rigidbody2D rig;

    private void Awake()
    {
        //‚±‚Ì•Ó’¼‚µ‚½‚¢
        MGM_Object = GameObject.FindWithTag("MainGameManager");
        MGM_Script = MGM_Object.GetComponent<MainGameManager>();
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
            MGM_Script = MGM_Object.GetComponent<MainGameManager>();
            
            GameObject counterBullet = Instantiate(MGM_Script.currentPlayerCounterBullet) as GameObject;
            counterBullet.transform.position = this.transform.position;
            

            Destroy(collisionGameObject);
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
    }

    

    


}