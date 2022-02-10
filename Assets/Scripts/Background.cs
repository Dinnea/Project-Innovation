using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject BuildingPrefab;
    //public 

    private void Start()
    {
        Debug.Log("Instantiating building at: " + transform.position);
    }

    void InstantiateBuilding(Vector3 offsetFromCenter)
    {
        GameObject building = Instantiate(BuildingPrefab, transform.position + offsetFromCenter, Quaternion.identity);
        building.transform.parent = this.transform;
    }
}
