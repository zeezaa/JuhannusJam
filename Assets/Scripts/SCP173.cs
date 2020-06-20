using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP173 : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    private Camera cam;

    public GameObject clonePrefab;
    private GameObject clone;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        cam = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, Mathf.Infinity))
        {          
            if (hit.transform.CompareTag("Wall"))
            {
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);

                gameObject.GetComponent<MeshRenderer>().enabled = false;
                Instantiate(clonePrefab, transform.position, transform.rotation);

                Debug.DrawRay(transform.position, player.transform.position * hit.distance, Color.blue);
            }

            if (hit.transform.CompareTag("Player"))
            {
                agent.isStopped = true;
                Debug.Log("Player");



                Debug.DrawRay(transform.position, player.transform.position * hit.distance, Color.red);
            }
        }

        if (cam.enabled == false)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
    }
}
