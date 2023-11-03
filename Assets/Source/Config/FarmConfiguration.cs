using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FarmConfiguration", menuName = "FarmConfiguration", order = 51)]
public class FarmConfiguration : ScriptableObject
{
    public IReadOnlyList<FieldData> Fields => _fieldsConfigs;
    [SerializeField] private List<FieldData> _fieldsConfigs = new List<FieldData>();
}