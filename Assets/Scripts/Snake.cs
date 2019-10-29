using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 250f;
    [SerializeField] private GameObject TailPrefab;
    [SerializeField] private float speed = 3f;
    private float z_offset = 0.5f;

    private List<GameObject> tailObjects = new List<GameObject>();

    [SerializeField] private Text scoreText;
    private int score;

    void Start()
    {
        tailObjects.Add(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        scoreText.text = score.ToString();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -1 * RotationSpeed * Time.deltaTime);
        }
    }

    public void AddTail()
    {
        score++;

        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;
        tailObjects.Add(Instantiate(TailPrefab, newTailPos, Quaternion.identity));
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetCountOfTail()
    {
        return tailObjects.Count;
    }

    public GameObject TargetForNewTail()
    {
        return tailObjects[GetCountOfTail() - 2];
    }
}
