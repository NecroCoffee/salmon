using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    [SerializeField] int currentFrame=0;
    [SerializeField] int actionFrame=15;

    [SerializeField] GameManager gameManager;

    [SerializeField]private GameObject[] buildings =new GameObject[5];

    private void BuildingGenerate(GameObject building)
    {
        GameObject gameObject = Instantiate(building, this.gameObject.transform.position, Quaternion.identity) as GameObject;
    }

    private void Awake()
    {
        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        if (gameManager.isGameOver == false) 
        {

            if (currentFrame >= actionFrame)
            {
                currentFrame = 0;
                BuildingGenerate(buildings[0]);
            }
            else
            {
                currentFrame++;
            }
        }
    }
}
