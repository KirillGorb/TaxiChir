using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 15;
    public float SpeedRot = 1;

    public float offset = 32;


    Rigidbody rd;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetMouseButton(0)) 
        {
            Vector3 m = Camera.main.ScreenToViewportPoint(Input.mousePosition) * offset;

            m.x = m.x > 24.5f ? 24.5f : m.x;
            m.x = m.x < 8.5f ? 8.5f : m.x;

            float se = 0.5f * offset;
            float x = m.x - se;

            m = new Vector3(x , transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, m, SpeedRot);

            //transform.position = m;
        }
    }
}
