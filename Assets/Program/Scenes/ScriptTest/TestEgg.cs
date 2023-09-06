using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dTestEgg : MonoBehaviour
{
    [SerializeField]
    private float force = 1f;
    private Rigidbody2D rig;

    private void EggMove()
    {
        
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        Destroy(this.gameObject, 3f);
        
    }

    private void FixedUpdate()
    {
        
    }


}
