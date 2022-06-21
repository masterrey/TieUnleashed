using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject barrel, support;
    GameObject target;
   
    public ParticleSystem weapon;
    bool work = false;
    public float antecipation = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        if (work)
        {

            barrel.transform.LookAt(target.transform.position+(target.transform.forward*antecipation));


            support.transform.rotation = Quaternion.Euler
                (-90,
                barrel.transform.rotation.eulerAngles.y,
                0);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        work = true;
        weapon.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        work = false;
        weapon.Stop();
    }
}
