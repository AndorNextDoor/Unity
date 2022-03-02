using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillChanger : MonoBehaviour
{
    public float r;
    public float g;
    public float b;
    public float rgby;
    private Transform FirstSkill;
    private Transform SecondSkill;


    // Start is called before the first frame update
    void Start()
    {
        ChangeFirstSkillColor();
        ChangeSecondSkillColor();
    }
     void  ChangeFirstSkillColor()
    {
        rgby = Mathf.Round(Random.Range(1f, 3f));
       FirstSkill = gameObject.transform.Find("FirstSkill"); 

            switch (rgby)
            {
                case 3:
                    r = 0;
                    g = 0;
                    b = 1;
                FirstSkill.transform.tag = "Colored";
                    break;
                case 2:
                    r = 0;
                    b = 0;
                    g = 1;
                FirstSkill.transform.tag = "Colored";
                    break;
                case 1:
                    g = 0;
                    b = 0;
                    r = 1;
                FirstSkill.transform.tag = "Colored";
                    break;
            }

        Color FirstColor = new Color(r, g, b, 1);
        FirstSkill.GetComponent<Renderer>().material.color = FirstColor;


    }

     void ChangeSecondSkillColor()
    {
        rgby = Mathf.Round(Random.Range(1f, 3f));
        SecondSkill = gameObject.transform.Find("SecondSkill");

        switch (rgby)
        {
            case 3:
                r = 0;
                g = 0;
                b = 1;
                SecondSkill.transform.tag = "Colored";
                break;
            case 2:
                r = 0;
                b = 0;
                g = 1;
                SecondSkill.transform.tag = "Colored";
                break;
            case 1:
                g = 0;
                b = 0;
                r = 1;
                SecondSkill.transform.tag = "Colored";
                break;
        }

        Color SecondColor = new Color(r, g, b, 1);
        SecondSkill.GetComponent<Renderer>().material.color = SecondColor;
    }
    
}
