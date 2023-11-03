using System.Collections.Generic;
using UnityEngine;

public class BeeResourceDistributor
{
    public IReadOnlyList<GameObject> BeesQueue => _beesQueue;
    private List<GameObject> _beesQueue = new List<GameObject>();

    public void AddBeeInQueue(GameObject bee)
    {
        _beesQueue.Add(bee);
    }

    public void RemoveBeeFromQueue()
    {
        _beesQueue.RemoveAt(0);
    }
}
