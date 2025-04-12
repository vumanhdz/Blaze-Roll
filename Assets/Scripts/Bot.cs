using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject FalsePn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            speed = 3;
        }
        if (collision.gameObject.CompareTag("Slow"))
        {
            speed = 2;
        }
        if (collision.gameObject.CompareTag("Van"))
        {
            speed = 5;
        }
        if (collision.gameObject.CompareTag("Nuoc"))
        {
            FalsePn.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
