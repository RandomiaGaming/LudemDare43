using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New TowerStats", menuName = "TowerStats")]
public class TowerStats : ScriptableObject
{
    public Sprite sprite;
    public int priceToUpgrade;
    public float ReloadTime;
    public float Health;
    public int Damage;
    public int Range;
}
