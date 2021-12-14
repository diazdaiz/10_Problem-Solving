using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForProblemFive : MonoBehaviour {
    Vector2 velocity;
    Vector3 mousePosition;

    void Update() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseBallDifference = mousePosition - transform.position;
        float magnitude = Mathf.Pow(Mathf.Pow(mouseBallDifference.x, 2f) + Mathf.Pow(mouseBallDifference.y, 2f), 1f / 2f);
        if(magnitude > 0.05f) {
            velocity = new Vector2(mouseBallDifference.x/magnitude, mouseBallDifference.y/magnitude) * 3f;
        }
        else {
            velocity = new Vector2(0f, 0f);
        }
        transform.GetComponent<Rigidbody2D>().velocity = velocity;
        
    }
}
