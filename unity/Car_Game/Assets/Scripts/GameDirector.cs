using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;


public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distance = GameObject.Find("Distance");


    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;

        if (length >= 0)
        {
            
            //Debug.Log(length);

            this.distance.GetComponent<TextMeshProUGUI>().text =
                "Distance : " + length.ToString("F2") + "m";


        }else
        {
            this.distance.GetComponent<TextMeshProUGUI>().text =
                "Game Over";
            
        }

    }
}
