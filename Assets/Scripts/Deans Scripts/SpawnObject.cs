using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private float MinX, MaxX, MinY, MaxY;
    private Vector2 pos;
    public GameObject[] myGameObjectToRespawn;

    private void Start()
    {
        SetMinAndMax();
        SpawnObj();
    }

    private void SetMinAndMax()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        MinX = -Bounds.x;
        MaxX = Bounds.x;
        MinY = -Bounds.y;
        MaxY = Bounds.y;
    }

    private void SpawnObj()
    {
        int NumberOfObj = Random.Range(0, myGameObjectToRespawn.Length);
        pos = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        GameObject obj = Instantiate(myGameObjectToRespawn[NumberOfObj], pos, Quaternion.identity);
        obj.transform.parent = transform;
    }


}
