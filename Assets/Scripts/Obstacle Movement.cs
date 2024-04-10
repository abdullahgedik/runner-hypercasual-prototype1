using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    void FixedUpdate()
    {
        rb.velocity = new Vector3 (0, 0, -moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //Time.timeScale = 0;
        }
    }
}
