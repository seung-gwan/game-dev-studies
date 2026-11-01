using UnityEngine;

public class CarController : MonoBehaviour
{
    //float Speed = 0;
    Vector2 StartPos;
    Vector2 EndPos;
    float MovePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            this.StartPos = Input.mousePosition;
            //this.Speed = 0.2f;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.EndPos = Input.mousePosition;
            this.MovePos = this.EndPos.x - this.StartPos.x;
        }

        transform.Translate(this.MovePos/2000, 0, 0);
        MovePos *= 0.98f;

        //Debug.Log(MovePos);
        //Debug.Log(Speed);
        
        
    }
}
