using System.Collections;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] private Gift _gift;
    [SerializeField] private float _timeBetweenSpawns;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawns);
            yield return _gift.Throw();
        }
    }
}
