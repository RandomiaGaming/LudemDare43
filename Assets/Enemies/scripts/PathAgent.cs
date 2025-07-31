using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAgent : MonoBehaviour
{
    private TilemapPathfind tp;
    public float wait;

    void Start()
    {
        tp = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<TilemapPathfind>();
        StartCoroutine(Move());
    }
    public IEnumerator Move()
    {
        while (true)
        {
            transform.position = tp.NextStep(transform.position, new Vector3(0, 0, 0));
        }
    }
}
