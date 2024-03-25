using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Summon : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] float hoverHeight = 0.7f;

    void Start()
    {
        
    }

    public void Spawn()
    {
        GameObject scrollView = GameObject.Find("Panel");
        scrollView.transform.DOMoveX(-200, 1.0f).SetEase(Ease.InOutBack);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        Vector3 spawnPos = new Vector3(hit.point.x, hoverHeight, hit.point.z);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
