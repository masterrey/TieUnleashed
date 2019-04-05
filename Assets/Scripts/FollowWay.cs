using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWay : MonoBehaviour
{
    public GameObject wayfather;
    Transform[] ways;
    public int index=1;
    public float velocity = 10;
    Vector3 oldpos;
    Quaternion oldrot;
    // Start is called before the first frame update
    void Start()
    {
        ways=wayfather.GetComponentsInChildren<Transform>();
        oldpos = transform.position;
        oldrot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards
            (transform.position,ways[index].transform.position,Time.deltaTime* velocity);

     
        Vector3 direction = ways[index].transform.position - transform.position;


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime);

        if (Vector3.Distance(transform.position, ways[index].transform.position) < 1)
        {
            index++;
            oldpos = transform.position;
            oldrot = transform.rotation;
        }

        //transform.Translate(Vector3.forward *
        //    Time.deltaTime*30);
    }
}
