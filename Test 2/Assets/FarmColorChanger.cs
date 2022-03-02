using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FarmColorChanger : MonoBehaviour
{
    Color StandartColor = Color.white;
    public ArrayList s;
    public float targets;
    public float r;
    public float g;
    public float b;
    public float rgb;
    public Color WeedColor;
    public bool ChangedColor = false;

    // Start is called before the first frame update
    void Start()
    {

        if (ChangedColor == true)
        {
            return;
        }else
        {
            InvokeRepeating("ChangeColor", 5f, 5f);
        }
       
    }

    void ChangeColor()
    {
        rgb = Mathf.Round(Random.Range(1f, 3f));

        Transform[] Farms = (Transform[])gameObject.GetComponentsInChildren<Transform>();

        GameObject randomBed = (GameObject)((Transform)Farms[Random.Range(1, Farms.Length)]).gameObject;


        GameObject[] tag_r = GameObject.FindGameObjectsWithTag("Red");

        GameObject[] tag_g = GameObject.FindGameObjectsWithTag("Green");

        GameObject[] tag_b = GameObject.FindGameObjectsWithTag("Blue");

        GameObject[] RGB = tag_r.Concat(tag_g).Concat(tag_b).ToArray();

        if (ChangedColor == true)
        {
            return;
        }
        else
          switch (rgb)
            {
                case 3:
                    r = 0;
                    g = 0;
                    b = 1;
                    randomBed.transform.tag = "Colored";
                    ChangedColor = true;
                    break;
                case 2:
                    r = 0;
                    b = 0;
                    g = 1;
                    randomBed.transform.tag = "Colored";
                    ChangedColor = true;
                    break;
                case 1:
                    g = 0;
                    b = 0;
                    r = 1;
                    randomBed.transform.tag = "Colored";
                    ChangedColor = true;
                    break;
            }

        WeedColor = new Color(r, g, b, 1);
        randomBed.GetComponent<Renderer>().material.color = WeedColor;
            
    }
}
