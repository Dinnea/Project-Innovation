using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInfiniteFactory
{
    public void Spawn();
    string path { get; }
}
