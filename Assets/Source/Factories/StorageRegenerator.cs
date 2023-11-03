using UnityEngine;

public class StorageRegenerator : MonoBehaviour
{
    [SerializeField] private float _amountPerTick;
    [SerializeField] private float _amountPerClick;
    [SerializeField] private float _refreshRate;
    
    private Storage _storage;
    private float _time = 0;

    public void Initialize(Storage flowerbedStorage)
    {
        _storage = flowerbedStorage;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _refreshRate) //Улучшить (исправить)
        {
            TryRegenerate(_amountPerTick);
            _time -= _refreshRate;
        }
    }
    private void OnMouseUp()
    {
        TryRegenerate(_amountPerClick);
    }

    private void TryRegenerate(float amount)
    {
        if (_storage.CanAddResources(amount) == true)
            _storage.AddResources(amount);
    }
}
