using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject throwPoint;

    Vector3 thisObjPos;

    private float GetAngle(Vector3 from, Vector3 to)
    {
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);

        return rad * Mathf.Rad2Deg;
    }

    private void lookAtMouse()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - screenPos;
        var angle = GetAngle(Vector3.zero, direction);
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
    }

    private void Awake()
    {
        
    }

    private void GeneratePrefab()
    {
        float angle = this.transform.rotation.z;

        thisObjPos = throwPoint.transform.position;
        Vector3 direction = transform.forward;
        GameObject A = Instantiate(prefab, new Vector3(thisObjPos.x, thisObjPos.y), Quaternion.Euler(direction));
        Rigidbody2D rig = A.gameObject.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2();
        rig.AddForce(force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        lookAtMouse();
        if (Input.GetKeyDown(KeyCode.F))
        {
            GeneratePrefab();
        }
    }
}
