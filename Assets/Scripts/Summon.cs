using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] float hoverHeight = 0.7f;

    void Start()
    {
        
    }

    public void Spawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        Vector3 spawnPos = new Vector3(hit.point.x, hoverHeight, hit.point.z);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
