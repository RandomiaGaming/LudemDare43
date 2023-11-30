using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        GameObject nearest = GameObject.FindGameObjectWithTag("Enemy");
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector3.Distance(transform.position, go.transform.position) < Vector3.Distance(transform.position, nearest.transform.position))
            {
                nearest = go;
            }
        }
        if (nearest != null)
        {
            transform.up = nearest.transform.position - transform.position;
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject nearest = GameObject.FindGameObjectWithTag("Enemy");
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(transform.position, go.transform.position) < Vector3.Distance(transform.position, nearest.transform.position))
                {
                    nearest = go;
                }
            }
            if (nearest != null && Vector3.Distance(transform.position, nearest.transform.position) < 1.5f)
            {
                Destroy(nearest);
                GameObject.FindGameObjectWithTag("TowerManager").GetComponent<TowerPlacer>().currentCash += 2;
                yield return new WaitForSeconds(3);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
