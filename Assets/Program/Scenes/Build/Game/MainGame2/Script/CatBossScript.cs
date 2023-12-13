using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBossScript : MonoBehaviour
{

    //猫用スプライト配列
    [SerializeField]
    private Sprite[] catSprites = new Sprite[2];

    //スプライト表示用オブジェクト
    [SerializeField]
    private GameObject catSpriteObject;

    //子コンポーネント-----------------------
    private SpriteRenderer catSpriteRenderer;

    //---------------------------------------

    
    /// <summary>
    /// コンポーネント取得
    /// </summary>
    private void GetComponents()
    {
        catSpriteRenderer = catSpriteObject.gameObject.GetComponent<SpriteRenderer>();
    }
}
