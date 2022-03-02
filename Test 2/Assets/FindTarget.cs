using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindTarget : MonoBehaviour
{
    public Vector3 StartPos;
    public FarmColorChanger ColorChanger;
    public float range = 1f;
    public float MoveSpeed = 1f;
    public Transform worker;
    public float startrange = 1f;
    private Color StandartColor = Color.white;
    public bool foundGarden = false;
    Color gardencolor;
    Color skillcolor;
    private GameObject FirstSkill = null;
    private GameObject SecondSkill = null;
    private GameObject Child = null;
    public GameObject Gardens;
    public List<GameObject> allChildren;



    void Start()
    {
        StartPos = gameObject.transform.Find("StartPos").transform.position;

        worker = this.transform;
        FirstSkill = gameObject.transform.Find("FirstSkill").gameObject;
        SecondSkill = gameObject.transform.Find("SecondSkill").gameObject;
        InvokeRepeating("FindGarden", 6f, 2f);
    }



    void FindGarden()
    {
        foreach (Transform transform in Gardens.transform)
        {
            if (transform.CompareTag("Colored"))
            {
                Child = transform.gameObject;
                break;
            }
        }

        if (Child.GetComponent<Renderer>().material.color == FirstSkill.GetComponent<Renderer>().material.color || Child.GetComponent<Renderer>().material.color == SecondSkill.GetComponent<Renderer>().material.color)
        {
            foundGarden = true;
        }
        else
        {
            foundGarden = false;
        }
    }
    void Update()
    {
        if (foundGarden == false && Vector3.Distance(worker.position, StartPos) <= startrange)
        {
        return;
        }
        else if (Vector3.Distance(worker.position, StartPos) > startrange && foundGarden == false) 
        {
            transform.LookAt(StartPos, StartPos);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else if (Vector3.Distance(worker.position, Child.transform.position) > range && foundGarden == true)
        {
            transform.LookAt(Child.transform);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else if (Vector3.Distance(worker.position, Child.transform.position) <= range)
        {
            Child.transform.tag = "Untagged";
            ColorChanger = Child.GetComponentInParent<FarmColorChanger>();
            ColorChanger.ChangedColor = false;
            Child.GetComponent<Renderer>().material.color = StandartColor;
            return;
        }
        else
        {
            return;
        }
    }
}
