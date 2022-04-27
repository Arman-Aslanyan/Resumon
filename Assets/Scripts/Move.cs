using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Resumon/Create new Move")]
public class Move : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea] [SerializeField] string desc;

    [SerializeField] ResumonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int powerPoints;
    [SerializeField] int maxPowPoints;

    #region Getters
    public string GetName() { return name; }
    public string GetDesc() { return desc; }
    public new ResumonType GetType() { return type; }
    public int GetAccuracy() { return accuracy; }
    public int GetCurPowPoints() { return powerPoints; }
    public int GetMacPowPoints() { return maxPowPoints; }
    #endregion
}