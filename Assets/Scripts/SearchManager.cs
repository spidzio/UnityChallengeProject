using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchManager : MonoBehaviour
{
    private GameObject[] menuItems;

    public void Search(string search)
    {
         menuItems = GameObject.FindGameObjectsWithTag("MenuItem");

        foreach (GameObject item in menuItems)
        {
            // bet button text
            TextMeshPro textMesh = item.GetComponentInChildren<TextMeshPro>();
            Debug.Log(textMesh);

            // if (textMesh.text.ToLower().Contains(search.ToLower()))
            // {
            //     item.SetActive(true);
            // }
            // else
            // {
            //     item.SetActive(false);
            // }
        }
    }
}
