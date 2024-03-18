using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterController : MonoBehaviour
{
    bool predatorMode = false;
    [SerializeField] float movementSpeed = 2.0f;
    [SerializeField] float rotationSpeed = 2.0f;
    public List<GameObject> foodList = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("refreshFoodList", 0.0f, 0.1f);
    }

    void refreshFoodList()
    {
        foodList.Clear();
        GameObject[] foodArray = GameObject.FindGameObjectsWithTag("food");
        foreach (GameObject food in foodArray)
        {
            if (food.GetComponent<DragMovement>().isPlaced())
            {
                foodList.Add(food);
            }
            
        }
        foodList.Sort(CompareFoodByDistance);

        if (IsFoodPresent())
        {
            ActivatePredatorMode();
        }
    }

    private int CompareFoodByDistance(GameObject a, GameObject b)
    {
        float distanceA = Vector3.Distance(transform.position, a.transform.position);
        float distanceB = Vector3.Distance(transform.position, b.transform.position);
        return distanceA.CompareTo(distanceB);
    }

    void Update()
    {
        if (!predatorMode)
        {
            return;
        }

        GameObject closestFood = foodList[0];
        Vector3 direction = closestFood.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, closestFood.transform.position, movementSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<DragMovement>().isDragging)
        {
            return;
        }

        if (other.gameObject.tag == "food")
        {
            Destroy(other.gameObject);
            foodList.Remove(other.gameObject);

            if (!IsFoodPresent())
            {
                predatorMode = false;
            }
        }
    }

    bool IsFoodPresent()
    {
        return foodList.Count > 0;
    }

    public void ActivatePredatorMode()
    {
        predatorMode = true;
    }
}
