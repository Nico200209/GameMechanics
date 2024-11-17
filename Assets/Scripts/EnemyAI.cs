using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Work with AI (This lets us get NavMesh Agent)
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints; //Array of waypoints PUBLIC
    int waypointIndex;
    Vector3 target;

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Assign NavMeshAgent to agent
        UpdateDestination(); //We call it once on start so it has somewhere to go once the game begins
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {                                                     //If the distance to our tatget is less than 1 we increase
            IterateWaypointIndex();                           //the waypoint index by one, and update our destination, by setting
            UpdateDestination();                              //"target" to current destination and sets NavMeshAgent to target
        }

        Distance();
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position; // Look for the position of current waypoint
        agent.SetDestination(target); // Sets NavMeshAgent destinations to the position of the target

    }

    void IterateWaypointIndex()
    {
        waypointIndex++; //Add one
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0; //Once we reach last waypoint (waypoint.Length), its going to go to the first waypoint again
        }
    }
    void Distance()
    {
            float dist = Vector3.Distance(Player.position, transform.position);
        if(dist < 2.5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
