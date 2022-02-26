using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Test : MonoBehaviour
{

    private Transform monster;

    [SerializeField]
    private Transform player;

    private NavMeshAgent nvAgent;


    void Start()
    {
        monster = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        nvAgent = GetComponent<NavMeshAgent>();

    }
    void Updete()
    {
        if(Vector3.Distance(nvAgent.destination, player.position) > 1.0f)
        {
            nvAgent.destination = player.position;
        }

    }

}