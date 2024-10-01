using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePath2 : MonoBehaviour
{
    public List<Transform> wayPoint;

    public int currentWaypointIndex = 0;

    public int speed;


    public GameObject Trigger;
    public TriggerScript TriggerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Walking();
    }

    void Walking()
    {
        //insert if Q shit here, n then we r so good!
        //maybe we transfer the Q pressing thing here?
        if (wayPoint.Count == 0)
        {
            return;
        }

        float distanceToWayPoint = Vector3.Distance(wayPoint[currentWaypointIndex].position, transform.position);

        if (distanceToWayPoint <= 0.001f)
        {
            if (TriggerScript.Q % 2 != 0)
            {
                currentWaypointIndex = (currentWaypointIndex + 1);
                if (currentWaypointIndex > 2)
                {
                    currentWaypointIndex = 2;
                }
            }
            else if (TriggerScript.Q % 2 == 0)
            {
                currentWaypointIndex = (currentWaypointIndex - 1);
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 0;
                }
            }

        }

        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, wayPoint[currentWaypointIndex].position, step);
    }

}
