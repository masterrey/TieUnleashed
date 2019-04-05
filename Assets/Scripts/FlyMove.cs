using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMove : MonoBehaviour
{
    Vector3 movement,rotation;
    public GameObject meshship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);

        rotation = new Vector3(-movement.y, movement.x, -movement.x);
        meshship.transform.localRotation = Quaternion.Euler(rotation * 30);

        transform.Translate(movement * Time.deltaTime * 40);

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime);
    }

    

}
