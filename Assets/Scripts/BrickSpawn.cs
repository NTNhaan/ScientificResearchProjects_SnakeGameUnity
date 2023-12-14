using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawn : MonoBehaviour
{
    // public Collider2D gridArea;
    // private Sprite wallPrefab;
    public void SpawnWall(GameObject wallPrefab ,Collider2D gridArea){
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector3 WallSpawn = new Vector3(x, y, 0f);

        GameObject newOject = Instantiate(wallPrefab, WallSpawn, Quaternion.identity);
    }
    // gán prefab cho một đối tượng nào đó rồi gán vị trí poistion cho đối tượng đó.
}
