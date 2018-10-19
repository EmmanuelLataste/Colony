using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Transform[] waypoints;

    private NavMeshAgent entityAgent;
    private int destPoint = 0;


    void Start() {
        entityAgent = GetComponent < NavMeshAgent>();

        //Without auto-barking the agent has continuous movment, the agent doesn't slow down when getting close to its destination point
        entityAgent.autoBraking = false;

        ToNextWaypoint();
    }


    void ToNextWaypoint()
    {
        //In case of no attribuated waypoint : return
        if (waypoints.Length == 0) {
            return;
        }

        //Say to the agent to go to this currently selected waypoint
        entityAgent.destination = waypoints[destPoint].position;

        //Define the destination point of the agent
        //Cycling to start if necessary
        destPoint = (destPoint + 1) % waypoints.Length;

    }






    /*
    void OnTriggerEnter(Collider col) {
        Debug.Log("Enter");
        if (entity.GetComponent<Collider>().tag == "Waypoint") {
            Debug.Log("AtWaypoint");
        }
    }


    void ToWaypoint() {

        //Si type 1 coché, alors suit les waypoints 0,1,2,3,0,1,2,... soit réinitialiser à 0
        //Si type 2 coché, alors suit les waypoints 0,1,2,3,2,1,0,1,... soit aller-retour

        Debug.Log("ToWaypoint");
    }

    */
}



//Allow for a list of Waypoints
[System.Serializable]
public class Waypoints {
    //solution de scours: public Transform WaypointPosition;
    public GameObject Waypoint;
}

    
      