using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    private float XSize = 8.8f;
    private float yHeight = 0.5f;
    private float ZSize = 8.8f;

    [SerializeField] private GameObject foodPrefab;
    private Vector3 currentPosition;
    private GameObject currentFood;

    void Update()
    {
        if (!currentFood)
        {
            AddNewFood();
        }
    }

    void AddNewFood()
    {
        currentPosition = new Vector3(Random.Range(XSize * -1, XSize), yHeight, Random.Range(ZSize * -1, ZSize));
        currentFood = GameObject.Instantiate(foodPrefab, currentPosition, Quaternion.identity);
    }
}
