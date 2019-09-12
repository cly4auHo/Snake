using UnityEngine;

public class Tail : MonoBehaviour
{
    private float speed;
    private Vector3 tailTarget;
    private float tailSpeed = 2.5f;
    private int indx;
    private GameObject tailTargetObj;
    private Snake snake;

    void Start()
    {
        snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<Snake>();
        speed = snake.Speed + tailSpeed;
        tailTargetObj = snake.tailObjects[snake.tailObjects.Count - 2];
        indx = snake.tailObjects.IndexOf(gameObject);
    }

    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            if (indx > 2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
