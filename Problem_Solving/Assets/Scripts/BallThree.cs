using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThree : MonoBehaviour {
    Vector2 initial_velocity;
    void Start() {
        initial_velocity = new Vector2(3f, 3f);
        transform.GetComponent<Rigidbody2D>().velocity = initial_velocity;
    }
}
