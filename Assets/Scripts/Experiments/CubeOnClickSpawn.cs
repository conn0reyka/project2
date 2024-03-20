using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOnClickSpawn : MonoBehaviour
{
    public Camera Camera;
    public GameObject CubePrefab;

    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject cube = Instantiate(CubePrefab);
                cube.transform.position = hit.point;
            }

            if(Input.GetMouseButtonDown(1))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
