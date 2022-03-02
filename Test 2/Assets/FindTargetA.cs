using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetA : MonoBehaviour
{
    public string searchTag = "Untagged";
    [Space]
    public Transform Gardens;
    public List<GameObject> allChildren;
    public List<GameObject> childrenWithTag;

    void Start()
    {
        if (searchTag != null)
        {
            
            FindAllChildren();
            InvokeRepeating("GetChildObjectsWithTag", 3f, 3f);
        }
    }

    public void FindAllChildren()
    {

        int len = Gardens.transform.childCount;

        for (int i = 0; i < len; i++)
        {
            allChildren.Add(transform.GetChild(i).gameObject);

        }
    }

    public void GetChildObjectsWithTag()
    {
        foreach (GameObject child in allChildren)
        {
            if (child.tag == "Untagged")
                Debug.Log(child.tag);
        }
    }
}

