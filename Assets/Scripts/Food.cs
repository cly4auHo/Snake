using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            other.GetComponent<Snake>().AddTail();
            Destroy(gameObject);
        }
    }
}
