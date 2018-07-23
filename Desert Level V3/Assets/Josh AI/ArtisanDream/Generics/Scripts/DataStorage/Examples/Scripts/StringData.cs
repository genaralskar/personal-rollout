using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Data Storage/String List")]
public class StringData : ScriptableObject
{
    public List<string> NameList;
    public string SingleName;
}