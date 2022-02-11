using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject BuildingPrefab;
    //public Vector2 XPosRange;
    //public Vector2 YPosRange;

    public int MinXPos;
    public int MaxXPos;
    public int MinYPos;
    public int MaxYPos;

    public int amountOfBuildings;

    private void Start()
    {
        for (int i = 0; i < amountOfBuildings; i++)
        {
            InstantiateBuilding(new Vector3(Random.Range(MinXPos, MaxXPos+1), Random.Range(MinYPos, MaxYPos+1), 0));
        }
    }

    void InstantiateBuilding(Vector3 offsetFromCenter)
    {
        GameObject building = Instantiate(BuildingPrefab, transform.position + offsetFromCenter, Quaternion.identity);
        building.transform.parent = this.transform;

        /*
        Collider2D[] colliders = new Collider2D[amountOfBuildings];
        ContactFilter2D contactFilter = new ContactFilter2D();

        Collider2D col = building.GetComponent<Collider2D>();
        col.OverlapCollider(contactFilter, colliders);

        if (colliders.Length > 1)
        {
            Debug.Log("Overlapping with other buildings, getting a new one.");
            Destroy(building);
            InstantiateBuilding(new Vector3(Random.Range(MinXPos, MaxXPos + 1), Random.Range(MinYPos, MaxYPos + 1)));
        }
        */
    }
}
