using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    [SerializeField] private float currentTime=0f;
    [SerializeField] private float actionTime=0.5f;

    [SerializeField] float defaultActionTime = 0.5f;

    [SerializeField] float actionTimeMin = 1.5f;

    [SerializeField] private GameManager gameManager;

    [SerializeField]private GameObject[] buildings =new GameObject[5];

    private void BuildingGenerate(GameObject building)
    {
        GameObject gameObject = Instantiate(building, this.gameObject.transform.position, Quaternion.identity) as GameObject;
    }

    private void DecrementGenerateTime()
    {
        float time = gameManager.decrementTime;
        time /= 10f;
        actionTime -= time;
        if (actionTime <=actionTimeMin)
        {
            actionTime = actionTimeMin;
        }
    }

    private void Awake()
    {
        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
        actionTime = defaultActionTime;
    }

    

    private void FixedUpdate()
    {
        if (gameManager.isGameOver == false) 
        {

            /*if (currentFrame >= actionFrame)
            {
                currentFrame = 0;
                BuildingGenerate(buildings[0]);
            }
            else
            {
                currentFrame++;
            }
            */

            currentTime +=Time.deltaTime;
            if (currentTime>=actionTime)
            {
                int i = Random.Range(0, buildings.Length + 1);
                BuildingGenerate(buildings[i]);
                currentTime = 0f;
            }
            


        }
    }
}
