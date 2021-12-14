using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour {
    Vector2 velocity;
    Vector3 mousePosition;
    public GameManager gameManager;

    private void Update() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseBallDifference = mousePosition - transform.position;
        float magnitude = Mathf.Pow(Mathf.Pow(mouseBallDifference.x, 2f) + Mathf.Pow(mouseBallDifference.y, 2f), 1f / 2f);
        if (Input.GetKey(KeyCode.Mouse0)) {
            velocity = new Vector2(mouseBallDifference.x / magnitude, mouseBallDifference.y / magnitude) * -2f;
            transform.GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else {
            if (magnitude > 0.05f) {
                velocity = new Vector2(mouseBallDifference.x / magnitude, mouseBallDifference.y / magnitude) * 2f;
            }
            else {
                velocity = new Vector2(0f, 0f);
            }
            transform.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "blue square") {
            collision.gameObject.SetActive(false);
            gameManager.AddScore();
        }
        if (collision.gameObject.tag == "yellow square") {
            collision.gameObject.SetActive(false);
            gameManager.SubtractScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "yellow ball") {
            gameManager.ResetScore();
        }
    }
}
