using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missile移動用スクリプト
/// </summary>
public class Missile : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float defaultSpeed = 0.5f;
    [SerializeField] private float speedCoefficient = 1.1f;
    [SerializeField] private int currentFrame = 0;
    [SerializeField] private int speedUpFrame = 30;
    [SerializeField] private int speedUpLimit = 3;
    [SerializeField] private float missileSpeed;

    [SerializeField] private bool isDestroy;

    [SerializeField] private GameObject spriteObject;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float m_red, m_green, m_blue, m_alpha;//spriteRendererに投げるRGBA値
    private float m_decRed, m_decGreen, m_decBlue, m_decAlpha;//1ダメージごとに減らすRGBA値

    [SerializeField] private float missileHP = 40;

    /// <summary>
    /// MissileスプライトColorデフォルトRGBA値取得用
    /// </summary>
    private void MissileColorGet()
    {
        m_red = spriteRenderer.color.r;
        m_blue = spriteRenderer.color.b;
        m_green = spriteRenderer.color.g;
        m_alpha = spriteRenderer.color.a;
    }

    /// <summary>
    /// missileスプライトオブジェクトのspriteRendererにRGBA値を渡す
    /// </summary>
    private void MissileColorSet()
    {
        spriteRenderer.color = new Color(m_red, m_green, m_blue, m_alpha);
        Debug.Log(spriteRenderer.color);
    }

    /// <summary>
    /// 減分RGBA値算出
    /// </summary>
    /// <param name="denominator"></param>
    private void MissileColorCalculateDecrement(float denominator)
    {
        m_decRed = m_red / denominator;
        m_decGreen = m_green / denominator;
        m_decBlue = m_blue / denominator;
        m_decAlpha = m_alpha / denominator;
        Debug.Log(m_decRed);
    }

    /// <summary>
    /// RGBA値計算処理
    /// </summary>
    /// <param name="isAlpha"></param>
    private void MissileColorDecrement(bool isAlpha)
    {
        m_red -= m_decRed;
        m_green -= m_decGreen;
        m_blue -= m_decBlue;
        if (isAlpha == true)
        {
            m_alpha -= m_decAlpha;
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(this.gameObject, 3f);
    }

    private void Awake()
    {      
        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
        missileSpeed = gameManager.gameSpeed;
        velocity = gameObject.transform.rotation * new Vector3(defaultSpeed * missileSpeed, 0, 0);
        isDestroy = false;

        MissileColorGet();
        MissileColorCalculateDecrement(missileHP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SalmonEgg"))
        {
            missileHP--;
            MissileColorDecrement(false);
            MissileColorSet();

            Destroy(collision.gameObject);
            if (missileHP<=0)
            {
                gameManager.bonusScore += gameManager.missileDestroyBonus;
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDestroy == false)
        {
            velocity = gameObject.transform.rotation * new Vector3(defaultSpeed * missileSpeed, 0, 0);
            this.gameObject.transform.position += velocity * Time.deltaTime;
        }
    }
}
