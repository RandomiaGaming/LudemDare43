using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class TowerPlacer : MonoBehaviour
{
    public GameObject tower;
    public Text cash;
    public int currentCash = 10;
    public Tilemap tm;
    public TileBase CanPlace;
    public TileBase Rock;

    void Update()
    {

        cash.text = currentCash.ToString() + "g";
        if (Input.GetMouseButtonDown(0) && tm.GetTile(tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))) == CanPlace)
        {
            if (TowerAtPos(tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))) == null)
            {
                if (currentCash >= 5)
                {
                    GameObject g = Instantiate(tower, tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                    g.transform.parent = transform;
                    tm.SetTile(tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)), Rock);
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawner>().Refresh();
                    currentCash -= 5;
                }
            }
            
        }
    }
    public Tower TowerAtPos(Vector3Int pos)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Tower"))
        {
            if (tm.WorldToCell(go.transform.position) == pos)
            {
                return go.GetComponent<Tower>();
            }
        }
        return null;
    }
}
