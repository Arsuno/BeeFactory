using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] private FieldFactory _fieldFactory;

    private void Start()
    {
        SpawnFields();
    }

    private void SpawnFields()
    {
        for (int i = 0; i < _fieldFactory.Configuration.Fields.Count; i++)
            _fieldFactory.Create(i);
    }
}
