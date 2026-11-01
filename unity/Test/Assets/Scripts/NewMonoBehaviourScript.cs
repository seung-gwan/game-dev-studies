using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class NewMonoBehaviourScript : MonoBehaviour
{






    //public int public_test = 1;
    //private int private_test = 1;

    //public class Game_RPS : MonoBehaviour
    //{

    //    public int computerChoice = Random.Range(0, 3);




    //    public void Game(int a)
    //    {

    //        if (computerChoice == 0)
    //        {
    //            if (a == 0)
    //            {
    //                Debug.Log("비겼습니다.");
    //            }
    //            else if (a == 1)
    //            {
    //                Debug.Log("유저가 이겼습니다.");
    //            }
    //            else
    //            {
    //                Debug.Log("유저가 졌습니다.");
    //            }
    //        }

    //        else if (computerChoice == 1)
    //        {
    //            if (a == 0)
    //            {
    //                Debug.Log("유저가 졌습니다.");
    //            }
    //            else if (a == 1)
    //            {
    //                Debug.Log("비겼습니다.");
    //            }
    //            else
    //            {
    //                Debug.Log("유저가 이겼습니다.");
    //            }
    //        }

    //        else
    //        {
    //            if (a == 0)
    //            {
    //                Debug.Log("유저가 이겼습니다.");
    //            }
    //            else if (a == 1)
    //            {
    //                Debug.Log("유저가 졌습니다.");
    //            }
    //            else
    //            {
    //                Debug.Log("비겼습니다.");
    //            }


    //        }
    //    }

    //public Vector2 Cube = new Vector2(0.0f, 0.0f);
    public Vector2 speed = new Vector2(2.0f, 0.0f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello! Start");
        //int age;
        //age = 03;
        //Debug.Log(age);

        //float height1 = 160.5f;
        //float height2;
        //height2 = height1;
        //Debug.Log(height2);

        //string name;
        //name = "Seunggwan";
        //Debug.Log(name);

        //int answer;
        //answer = 1 + 2;
        //Debug.Log(answer);

        //string str1 = "Yu ";
        //string str2 = "Seunggwan";
        //string mes;

        //mes = str1 + str2;
        //Debug.Log(mes);

        //string str = "Seunggwan";
        //int num = 123;

        //string msg = str + num;
        //Debug.Log(msg);

        //int hp = 200;
        //if (hp >= 100)
        //{
        //    Debug.Log("이얍!");

        //}else{

        //    Debug.Log("막아!");
        //}

        //int hp = 180;
        //if (hp <= 50)
        //{
        //    Debug.Log("호다닥");
        //} else if (hp >= 200)
        //{
        //    Debug.Log("이얍!");
        //} else
        //{
        //    Debug.Log("막아!");
        //}

        //for (int i = 0; i < 5; i++)
        //{
        //    Debug.Log(i);
        //}

        //for (int i = 0; i <= 10; i += 2)
        //{
        //    if (i == 0)                                 
        //    { i += 2; }           if (i != 0){ Debug.Log(i)}
        //    Debug.Log(i);
        //}

        //for (int i = 3; i >= 0; i--)
        //{
        //    Debug.Log(i);
        //}

        //int[] array = new int[5];

        //array[0] = 2;
        //array[1] = 10;
        //array[2] = 5;
        //array[3] = 15;
        //array[4] = 3;

        //for (int i = 0; i < 5; i++)
        //{
        //    Debug.Log(array[i]);



        //}

        //int[] points = { 83, 99, 52, 93, 15 };

        //for (int i = 0; i < 5; i++)
        //{
        //    if (points[i] >= 90)
        //    {
        //        Debug.Log(points[i]);
        //    }
        //}

        //int[] points = { 83, 99, 52, 93, 15 };

        //int sum1 = 0;
        //int num1 = 0;

        //for (int i = 0; i < 5; i++)
        //{
        //    sum1 += points[i];
        //}
        //num1 = sum1 / 5;

        //Debug.Log(num1);

        //for (int i = 1; i <= 10; i++)
        //{

        //    Debug.Log(i + "번째 총알 발사!");

        //    if (i == 10)
        //    {
        //        Debug.Log("재장전 필요!");
        //    }


        //}

        //int monster = 100;
        //int atk = 15;

        //for (; monster > 0; monster -= atk)
        //{
        //    Debug.Log("몬스터 체력 : " + monster);

        //    if (monster <= atk) //
        //    {
        //        monster = 0;
        //        Debug.Log("몬스터 처치!");
        //    }

        //}


        //int exp = 25;
        //int exptotar = 0;

        //for (int i = 0; i <= 10; i++)
        //{
        //    exptotar += exp;

        //    Debug.Log("몬스터 처치! 경험치 +" + exp);
        //    Debug.Log("현재 경험치 : " + exptotar);

        //    if (exptotar >= 100)
        //    {
        //        Debug.Log("레벨업!");
        //        exptotar = 0;
        //        Debug.Log("현재 경험치 : " + exptotar);

        //    }

        //}


        //Game_RPS game1 = new Game_RPS();

        //Game(0);
        //game1.Game(1);
        //game1.Game(2);


        //Vector2 playerPos = new Vector2(3.0f, 4.0f);
        //playerPos.x += 8.0f;
        //playerPos.y += 5.0f;

        //Debug.Log(playerPos);


        //Vector2 startPos = new Vector2(2.0f, 1.0f);
        //Vector2 endPos = new Vector2(8.0f, 5.0f);

        //Vector2 Dir = endPos - startPos;

        //Debug.Log(Dir);

        //float len = Dir.magnitude; // magnitude 이동한 대각선 거리
        //Debug.Log(len);




    }


        // Update is called once per frame
        void Update()
        {

        

        Vector2 playerPos = transform.position;
        playerPos += speed * Time.deltaTime;

        if (playerPos.x > 8.0f)
        {
            playerPos.x = -8.0f;
            
        }

        Debug.Log("현재위치 : " + playerPos);
        transform.position = playerPos;




        //Debug.Log("Hello! Start" + public_test);
        //public_test ++;
    }
    }
