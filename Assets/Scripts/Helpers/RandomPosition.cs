using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition
{
    private readonly float DISTANCE_DIFFERENCE = 1f;

   public Vector3 GenerateRandomPositionInTile(Vector3 position)
    {
        Vector3 randomPosition = new Vector3();
        randomPosition.x = Random.Range(position.x, position.x + 20);
        randomPosition.y = Random.Range(position.y, position.y + 20);
        randomPosition.z = 0;
        return randomPosition;
    }

    public Vector2 GenerateRandomPositionOutsideFOVFromOrigin(Vector3 FOVSize, Vector3 origin)
    {
        Vector3 randomPosition = new Vector3();
        bool isVertical = Random.value > 0.5f;

        if (isVertical)
        {
            randomPosition.x = Random.Range(-FOVSize.x, FOVSize.x);
            randomPosition.y = RandomVertical(FOVSize);
        }
        else
        {
            randomPosition.y = Random.Range(-FOVSize.y, FOVSize.y);
            randomPosition.x = RandomHorizontal(FOVSize);
        }
        randomPosition.z = 0;

        randomPosition += origin;

        return randomPosition;
    }

    private float GetRandomDistanceDifference()
    {
        return Random.value > 0.5f ? -DISTANCE_DIFFERENCE : DISTANCE_DIFFERENCE;
    }

    private float RandomVertical(Vector3 origin)
    {
        return origin.y * GetRandomDistanceDifference();
    }

    private float RandomHorizontal(Vector3 origin)
    {
        return origin.x * GetRandomDistanceDifference();
    }
}
