using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Vector2 targetPos;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (targetPos != new Vector2(0, 0))
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        if (transform.position.x == targetPos.x && transform.position.y == targetPos.y)
        {
            targetPos = new Vector2(0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.velocity = new Vector2(0, 0);
        targetPos = new Vector2(0, 0);
    }

    void OnGUI()
    {
        Vector2 mousePos = new Vector2();

        mousePos.x = Event.current.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - Event.current.mousePosition.y;

        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetMouseButtonDown(0))
        {
            targetPos = point;
        }
    }
}
