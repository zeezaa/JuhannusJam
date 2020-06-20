using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rb;

    public float blinkReset;
    public float blink;

    private Camera cam;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        blink = blinkReset;
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if(Input.GetMouseButton(1))
        {
            blink = 0;
        }

        if(blink <= 0)
        {
            cam.enabled = false;
        }

        if(blink <= -0.1)
        {
            blink = blinkReset;
            cam.enabled = true;
        }

        blink -= Time.deltaTime;
    }  
}
