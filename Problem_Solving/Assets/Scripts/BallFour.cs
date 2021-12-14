using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFour : MonoBehaviour {
    Vector2 velocity;

    void Update() {
        velocity = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.DownArrow)) {
            velocity += new Vector2(0f, -3f);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            velocity += new Vector2(0f, 3f);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            velocity += new Vector2(-3f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            velocity += new Vector2(3f, 0f);
        }
        velocity = velocity.normalized * 3f;
        transform.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
