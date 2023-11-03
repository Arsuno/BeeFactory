using UnityEngine;

public class Warehouse : MonoBehaviour, IUpgradable
{
    public Storage Storage => _storage;
    public int CurrentLevel => _currentLevel;

    private Storage _storage;
    private int _currentLevel = 1;

    public void Initialize(Storage storage)
    {
        _storage = storage;
    }

    public void Upgrade()
    {
        _storage.Upgrade();
        _currentLevel++;
    }
}
