using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerEight : MonoBehaviour
{
    public GameObject square;
    public float spawnInterval;
    int maxSpawn;
    List<GameObject> squares;

    int score;
    public Text scoreText;

    public Transform ball; 

    float timer;

    private void Awake() {
        timer = 0;
        score = 0;
        maxSpawn = Random.Range(10, 16);
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


    private void Update() {
        timer += Time.deltaTime;
        if (timer > spawnInterval) {
            timer = 0;
            SpawnFromPool();
        }
    }

    void SpawnFromPool() {
        for (int i = 0; i < squares.Count; i++) {
            if (!squares[i].activeInHierarchy) {
                Vector3 spawnLocation;
                do {
                    spawnLocation = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
                } while (Mathf.Pow(Mathf.Pow(spawnLocation.x - ball.position.x, 2) + Mathf.Pow(spawnLocation.y - ball.position.y, 2), 1f / 2f) < 0.8);
                squares[i].transform.position = spawnLocation;
                squares[i].SetActive(true);
                break;
            }
        }
    }
}
