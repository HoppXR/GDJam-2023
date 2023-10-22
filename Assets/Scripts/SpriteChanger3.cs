using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger3 : MonoBehaviour
{
    public Sprite spL, spR, spU, spD;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GetComponent<SpriteRenderer>().sprite = spL;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<SpriteRenderer>().sprite = spR;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<SpriteRenderer>().sprite = spU;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<SpriteRenderer>().sprite = spD;
        }
    }
}