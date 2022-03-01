using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICloudFactory
{
    public void Spawn();
    string path { get; }
}
