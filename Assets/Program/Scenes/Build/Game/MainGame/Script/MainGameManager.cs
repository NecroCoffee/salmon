using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���C���Q�[���V�[������p�X�N���v�g
/// </summary>
public class MainGameManager : MonoBehaviour
{
    //�L���b�V���ΏۃR���|�[�l���g


    /// <summary>
    /// �R���|�[�l���g�L���b�V��: GetComponent�̌��ʂ��L���b�V�����Ă������߂̃N���X
    /// </summary>
    public sealed class ComponentCache<T>
    {
        private T m_cache;
        private bool m_isCached;

        public T Get(GameObject gameObject)
        {
            // UnityEngine.Object �� null �`�F�b�N�͏������ׂ������邽��
            // bool �l�Ŕ��肷��悤�ɂ��Ă��܂�
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
