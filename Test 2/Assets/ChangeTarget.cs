using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    public float range = 2f;
    public float MoveSpeed = 1f;
    public Transform worker;
    public Transform Garden;
    // Start is called before the first frame update
    void Start()
    {
        worker = this.transform;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Vector3.Distance(worker.transform.position, Garden.transform.position) > range)
        {
            transform.LookAt(Garden.transform);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }else if (Vector3.Distance(worker.transform.position, Garden.transform.position) <= range)
        {
            return;
        }
    }
    void moveworker(Vector3 Dir)
    {
        
    }
     void FixedUpdate()
    {

    }
}
