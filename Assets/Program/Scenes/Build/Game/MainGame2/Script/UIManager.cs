using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int timeScore;

    [SerializeField] private GameObject gameUIGroup;
    [SerializeField] private GameObject gameOverUIGroup;

    [SerializeField] private GameObject gameOverUiGroupTime;
    [SerializeField] private GameObject gameOverUiGroupBonus;
    [SerializeField] private GameObject gameOverUiGroupTotalScore;

    [SerializeField] private TextMeshProUGUI gameOverTimeText;
    [SerializeField] private TextMeshProUGUI gameOverBonusText;
    [SerializeField] private TextMeshProUGUI gameOverTotalText;
    [SerializeField] private TextMeshProUGUI gameOverRetryText;

    [SerializeField] private GameManager gameManager;

    private bool checkActiveUI;

    private IEnumerator ActiveGameOverUI()
    {
        gameUIGroup.SetActive(false);
        gameOverUIGroup.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameOverUiGroupTime.SetActive(true);
        gameOverTimeText.text = ((int)gameManager.timeScore).ToString("d14");
        yield return new WaitForSeconds(2f);
        gameOverUiGroupBonus.SetActive(true);
        gameOverBonusText.text = gameManager.bonusScore.ToString("d14");
        yield return new WaitForSeconds(2f);
        gameOverUiGroupTotalScore.SetActive(true);
        gameOverTotalText.text = (((int)gameManager.timeScore) + (int)gameManager.bonusScore).ToString("d14");
        yield return new WaitForSeconds(2f);
        gameOverRetryText.gameObject.SetActive(true);

    }

    

    private void Awake()
    {
        checkActiveUI = false;
    }

    

    private void Update()
    {
        //14Œ…
        if (gameManager.isGameOver == false)
        {
            timeScore = (int)gameManager.timeScore;
            scoreText.text = (timeScore+gameManager.bonusScore).ToString("d14");
        }

        if (gameManager.isGameOver == true)
        {
            if (checkActiveUI == false)
            {
                StartCoroutine(ActiveGameOverUI());
                checkActiveUI = true;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("mainGameTitle");
            }
        }

    }

}
