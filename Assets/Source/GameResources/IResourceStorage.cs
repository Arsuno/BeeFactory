using System;
using System.Collections;
using UnityEngine;

public interface IResourceStorage
{
    public void AddResources(float amount);
    public void WithdrawResources(float amount);
}
