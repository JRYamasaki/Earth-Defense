using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAlienPosition : MonoBehaviour 
{
    private float alienSize = 3.0f;
    private float horizontalDistanceBetweenAliens, verticalDistanceBetweenRows;

    public int numOfAliensInARow, numOfRows;
    public GameObject alien1, alien2, alien3, alienArea, alienAreaSpawn;
    private GameObject parentArea;

    void Start() 
    {
        GameObject initialArea = GameObject.FindWithTag("AlienArea");
        parentArea = initialArea;

        InstantiateGridOfAliens();
	}

    void InstantiateGridOfAliens()
    {
        GameObject[] alienTypes = {alien3, alien2, alien2, alien1, alien1};
        Vector3 nextVerticalAlienPosition;

        horizontalDistanceBetweenAliens = (parentArea.transform.localScale.x - (numOfAliensInARow * alienSize)) / numOfAliensInARow;
        verticalDistanceBetweenRows = (parentArea.transform.localScale.y - (numOfRows * alienSize)) / numOfRows;
        Vector3 initialPositionInSpawnArea = new Vector3(parentArea.transform.localScale.x / -2, 0, parentArea.transform.localScale.y / 2);
        Vector3 sizeAlien = new Vector3(alienSize / 2, 0, alienSize / -2);
        Vector3 initialPosition = initialPositionInSpawnArea + sizeAlien + parentArea.transform.position;

        for (int row = 0; row < numOfRows; row++)
        {
            nextVerticalAlienPosition = new Vector3(initialPosition.x, 0, initialPosition.z + (row * (alienSize + verticalDistanceBetweenRows) * -1));
            InstantiateRow(nextVerticalAlienPosition, alienTypes[row]);
        }     
    }

    //get rid of parent Area, 
    void InstantiateRow(Vector3 initialRowPosition, GameObject alienType)
    {
        Vector3 nextAlienPosition;
        for (int i = 0; i < numOfAliensInARow; i++)
        {
            nextAlienPosition = new Vector3(i * (alienSize + horizontalDistanceBetweenAliens) + horizontalDistanceBetweenAliens / 2, 0, 0);
            GameObject alien = Instantiate(alienType, initialRowPosition + nextAlienPosition, Quaternion.identity);
            alien.transform.parent = parentArea.transform;
        }
    }

    public void CreateNewWaveOfAliens()
    {
        parentArea.transform.position = alienAreaSpawn.transform.position;
        InstantiateGridOfAliens();
    }
}
