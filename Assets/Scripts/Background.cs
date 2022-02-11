using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject BuildingPrefab;

    private void Start()
    {
        var b1 = Instantiate(BuildingPrefab, new Vector3(transform.position.x - 2, transform.position.y - 7.5f, 0), Quaternion.identity);
        var b2 = Instantiate(BuildingPrefab, new Vector3(transform.position.x + 2, transform.position.y, 0), Quaternion.identity);
        var b3 = Instantiate(BuildingPrefab, new Vector3(transform.position.x, transform.position.y + 7.5f, 0), Quaternion.identity);

        b1.transform.parent = this.transform;
        b2.transform.parent = this.transform;
        b3.transform.parent = this.transform;
    }
}
