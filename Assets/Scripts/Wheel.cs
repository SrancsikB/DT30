using UnityEngine;

public class Wheel : MonoBehaviour
{

    [SerializeField] float rotSpeed;
    [SerializeField] int rotDiecrtion = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotDiecrtion, rotSpeed * Time.deltaTime);

    }
}
