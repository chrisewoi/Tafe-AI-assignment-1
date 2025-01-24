using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    public GameObject followObject1;
    public GameObject followObject2;
    public GameObject followObject3;
    public UnityEngine.AI.NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Tells the AI which object to move to
        if (followObject1 != null)
        {
            agent.destination = followObject1.transform.position;
        } else if (followObject2 != null)
        {
            agent.destination = followObject2.transform.position;
        } else if (followObject3 != null)
        {
            agent.destination = followObject3.transform.position;
        }
    } 
}
