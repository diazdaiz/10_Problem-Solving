using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProblemTwo: MonoBehaviour {
    public Vector2 velocity;
    void Start() {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 2f);
    }
}
