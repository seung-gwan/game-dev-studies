using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 300.0f;
    float WalkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKeyDown(KeyCode.LeftShift)) { key = -1; }
        if (Input.GetKeyDown(KeyCode.RightShift)) { key = 1; }

        float speedx = Mathf.Abs(this.rigid2D.linearVelocityX);


        if (speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce(transform.right * key * this.WalkForce);
        }
        
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearDirector");
    }



}
