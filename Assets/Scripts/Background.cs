using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public Vector2 XPosRange;
    public Vector2 YPosRange;

    public int amountOfBuildings;

    private void Start()
    {
        for (int i = 0; i < amountOfBuildings; i++)
        {
            InstantiateBuilding(new Vector3(Random.Range(XPosRange.x, XPosRange.y), Random.Range(YPosRange.x, YPosRange.y), 0));
        }
    }

    void InstantiateBuilding(Vector3 offsetFromCenter)
    {
        GameObject building = Instantiate(BuildingPrefab, transform.position + offsetFromCenter, Quaternion.identity);
        building.transform.parent = this.transform;
    }
}
