using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxX = 9f;
    [SerializeField] private float maxY = 5f;
    float maxSpeed = 5f;
    float rotSpeed = 180f;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        if (Input.GetKey("j"))
        {
            z += rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;
        }
        if (Input.GetKey("l"))
        {
            z -= rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;
        }

        // Thrust
        Vector3 pos = transform.position;
        if (Input.GetKey("k"))
        {
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
            pos += rot * velocity;
        }
        transform.position = pos;

        // Touch edge then go to the other side
        if (transform.position.x < -maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        else if(transform.position.x > maxX)
        {
            transform.position = new Vector2(-maxX, transform.position.y);
        }
        if (transform.position.y < -maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, -maxY);
        }
    }
    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
