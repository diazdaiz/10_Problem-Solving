using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSeven : MonoBehaviour
{
    public GameObject square;
    public float spawnInterval;
    int maxSpawn;
    List<GameObject> squares;

    int score;
    public Text scoreText;

    private void Awake() {
        score = 0;
        maxSpawn = Random.Range(3, 14);
        squares = new List<GameObject>();

        for (int i = 0; i < maxSpawn; i++) {
            squares.Add(Instantiate(square));
            squares[i].transform.position = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
        }
    }

    public void AddScore() {
        score += 1;
        scoreText.text = score.ToString();
    }
}
