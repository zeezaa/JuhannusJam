using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rb;
    public float speed;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }  
}

/*public Vector2 targetPos;

 if (targetPos != new Vector2(0, 0))
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed* Time.deltaTime);
        }

        if (transform.position.x == targetPos.x && transform.position.y == targetPos.y)
        {
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

private void OnCollisionStay2D(Collision2D collision)
{
    rb.velocity = new Vector2(0, 0);
    targetPos = new Vector2(0, 0);
}*/
