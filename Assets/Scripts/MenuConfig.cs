using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConfig : MonoBehaviour
{

    public MenuConfigScriptableObject config;


    void Start()
    {
        SpawnMenuItems();
    }

    void SpawnMenuItems()
    {
        for (int i = 0; i < config.menuItems.Length; i++)
        {
            for (int j = 0; j < config.menuItemsCount[i]; j++)
            {
                var item = Instantiate(config.menuItems[i], new Vector3(0, 0, 0), Quaternion.identity);
                item.transform.SetParent(transform);
            }
        }
    }
}
