using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWay : MonoBehaviour
{
    public GameObject[] ways;
    public int index;
    public float velocity = 10;
    Vector3 oldpos;
    Quaternion oldrot;
    // Start is called before the first frame update
    void Start()
    {
        oldpos = transform.position;
        oldrot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards
            (transform.position,ways[index].transform.position,Time.deltaTime* velocity);

        //lerp invertido
        Vector3 direction = ways[index].transform.position - transform.position;
        Vector3 total = ways[index].transform.position -  oldpos;
        float normDistTogo = Vector3.Dot(total, direction) / Vector3.Dot(total, total);
        
        Quaternion rototogo= Quaternion.Lerp
            (oldrot, Quaternion.LookRotation(direction),1- normDistTogo);

        transform.rotation = Quaternion.Lerp(transform.rotation, rototogo, Time.deltaTime);

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
