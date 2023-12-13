using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBossScript : MonoBehaviour
{

    //�L�p�X�v���C�g�z��
    [SerializeField]
    private Sprite[] catSprites = new Sprite[2];

    //�X�v���C�g�\���p�I�u�W�F�N�g
    [SerializeField]
    private GameObject catSpriteObject;

    //�q�R���|�[�l���g-----------------------
    private SpriteRenderer catSpriteRenderer;

    //---------------------------------------

    
    /// <summary>
    /// �R���|�[�l���g�擾
    /// </summary>
    private void GetComponents()
    {
        catSpriteRenderer = catSpriteObject.gameObject.GetComponent<SpriteRenderer>();
    }
}
