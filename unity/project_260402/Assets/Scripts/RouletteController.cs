using Unity.VisualScripting;
using UnityEngine;

public class RouletteController : MonoBehaviour
{

    float rotSpeed = 0;
    int stack = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;   // 60hz fps로 셋팅        


    }

    // Update is called once per frame
    void Update()
    {

        if (stack == 1)
        {

            if (Input.GetMouseButtonDown(0))    // 마우스 누르면 실행
            {

                this.rotSpeed = 10;     // 10의 속도로 회전
                stack = 0;              // 0 으로 바뀌며 else if 실행
            }
            rotSpeed *= 0.96f;      //디폴트로 계속 실행중

            
        }
        else if (Input.GetMouseButtonDown(0)) // 다시 누르면 스택만 1 변경 후 멈춤
        {

            //this.rotSpeed = 10;
            stack = 1;

        }

        transform.Rotate(0, 0, this.rotSpeed);

    }
}
