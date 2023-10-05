using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メインゲームシーン制御用スクリプト
/// </summary>
public class MainGameManager : MonoBehaviour
{
    //キャッシュ対象コンポーネント


    /// <summary>
    /// コンポーネントキャッシュ: GetComponentの結果をキャッシュしておくためのクラス
    /// </summary>
    public sealed class ComponentCache<T>
    {
        private T m_cache;
        private bool m_isCached;

        public T Get(GameObject gameObject)
        {
            // UnityEngine.Object の null チェックは少し負荷がかかるため
            // bool 値で判定するようにしています
            if (m_isCached) return m_cache;
            if (m_cache != null) return m_cache;

            m_cache = gameObject.GetComponent<T>();
            m_isCached = m_cache != null;

            return m_cache;
        }
    }

    //

    //player

    [SerializeField] private GameObject[] playerCounterBullets = new GameObject[5];

    [SerializeField] private GameObject defaultPlayerCounterBullet;

    [SerializeField] public GameObject currentPlayerCounterBullet;


    //enemy
    [SerializeField] public GameObject MGMcurrentEnemy;

    [SerializeField] public GameObject MGMnextEnemy;

    [SerializeField] private GameObject[] EnemyList = new GameObject[5];

    
    private void Awake()
    {
        currentPlayerCounterBullet = defaultPlayerCounterBullet;
        MGMcurrentEnemy = EnemyList[0];
        MGMcurrentEnemy = EnemyList[1];
    }

    


}
