using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public System.Random rnd = new System.Random();
    public GameObject enemy;
    public float wait;
    private int min;
    private int max;
    // Use this for initialization
    void Start()
    {
        min = Mathf.RoundToInt(transform.position.y);
        max = Mathf.RoundToInt(transform.GetChild(0).position.y);
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject go = Instantiate(enemy, new Vector3(transform.position.x, rnd.Next(min, max) + 0.5f, 0), Quaternion.identity);
            go.transform.parent = transform;
            yield return new WaitForSeconds(wait);
        }
    }
}
