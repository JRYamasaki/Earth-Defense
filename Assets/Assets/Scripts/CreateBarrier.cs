using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBarrier : MonoBehaviour 
{
    public GameObject barrierBlock;
    public int numberOfBarriers, buffer;
    public float initialYPosition, initialZPosition;
    private Vector3 spawnPosition;
    private float cubeSize, spaceBetweenBarriers;

    int barrierHeight = 10;
    int barrierWidth = 20;

    //Easier way to draw barriers?
    int[,] blockArrangement = new int[10, 20]{ {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                                   { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                                   { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                   { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
                                   { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1} };

    void Start()
    {
        cubeSize = barrierBlock.transform.localScale.x;
        float boundaryWidth = GameObject.FindWithTag("Boundary").GetComponent<Transform>().localScale.x;
        float barrierWidthInCubes = barrierWidth * cubeSize;
        float startingXPositionOfBarriers = -0.5f * (boundaryWidth - buffer) + 0.5f * (boundaryWidth / numberOfBarriers) - 0.5f * barrierWidthInCubes;
        spaceBetweenBarriers = (boundaryWidth - buffer) / numberOfBarriers;
        
        spawnPosition = new Vector3(0, initialYPosition, initialZPosition);
        SetSpawnPositionOfBarrier(startingXPositionOfBarriers);
        SpawnAllBarriers();
	}

    void SpawnAllBarriers()
    {
        for (int i = 0; i < numberOfBarriers; i++)
        {
            SpawnABarrier();
            SetSpawnPositionOfBarrier(spaceBetweenBarriers);
        }
    }

    void SpawnABarrier()
    {
        for (int i = 0; i < barrierHeight; i++)
        {
            for (int k = 0; k < barrierWidth; k++)
            {
                if (blockArrangement[i, k] == 1)
                {
                    Instantiate(barrierBlock, spawnPosition, this.transform.rotation);
                }
                ChangeSpawnBetweenBlocksPosition(cubeSize, 0.0f);
            }
            ChangeSpawnBetweenBlocksPosition(-(barrierWidth * cubeSize), -cubeSize);
        }
    }

    void ChangeSpawnBetweenBlocksPosition(float horizontalMovement, float verticalMovement)
    {
        Vector3 movementVector = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        spawnPosition += movementVector;
    }

    void SetSpawnPositionOfBarrier(float horizontalMovementRight)
    {
        spawnPosition.x += horizontalMovementRight;
        spawnPosition.y = initialYPosition;
        spawnPosition.z = initialZPosition;
    }
}
