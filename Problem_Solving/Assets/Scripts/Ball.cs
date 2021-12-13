using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //Vector2 initial_velocity;
    Vector2 velocity;
    Vector3 mousePosition;
    public GameManager gameManager;
    //void Start() {
    //    initial_velocity = new Vector2(3f, 3f);
    //    transform.GetComponent<Rigidbody2D>().velocity = initial_velocity;
    //}

    void Update() {
        //velocity = new Vector2(0f, 0f);
        //if (Input.GetKey(KeyCode.DownArrow)) {
        //    velocity += new Vector2(0f, -3f);
        //}
        //if (Input.GetKey(KeyCode.UpArrow)) {
        //    velocity += new Vector2(0f, 3f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow)) {
        //    velocity += new Vector2(-3f, 0f);
        //}
        //if (Input.GetKey(KeyCode.RightArrow)) {
        //    velocity += new Vector2(3f, 0f);
        //}
        //velocity = velocity.normalized * 3f;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseBallDifference = mousePosition - transform.position;
        //velocity = mouseBallDifference.normalized * 3f; //somehow ga keubah jadi 3f
        //Debug.Log(Mathf.Pow(Mathf.Pow(velocity.x, 2f) + Mathf.Pow(velocity.y, 2f), 1f / 2f));
        float magnitude = Mathf.Pow(Mathf.Pow(mouseBallDifference.x, 2f) + Mathf.Pow(mouseBallDifference.y, 2f), 1f / 2f);
        if(magnitude > 0.05f) {
            velocity = new Vector2(mouseBallDifference.x/magnitude, mouseBallDifference.y/magnitude) * 3f;
        }
        else {
            velocity = new Vector2(0f, 0f);
        }
        transform.GetComponent<Rigidbody2D>().velocity = velocity;
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "square") {
            collision.gameObject.SetActive(false);
            gameManager.AddScore();
        }
    }
}
