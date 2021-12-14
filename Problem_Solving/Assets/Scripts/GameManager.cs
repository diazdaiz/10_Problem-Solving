using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject yellowSquare;
    public GameObject blueSquare;
    public float spawnInterval;
    int maxSpawn;
    List<GameObject> yellowSquares;
    List<GameObject> blueSquares;
    bool spawnBlue;
    bool spawnYellow;

    int score;
    public Text scoreText;

    public Transform ball;

    float timer;

    private void Awake() {
        timer = 0;
        score = 0;
        maxSpawn = 6;
        yellowSquares = new List<GameObject>();
        blueSquares = new List<GameObject>();

        for (int i = 0; i < maxSpawn; i++) {
            yellowSquares.Add(Instantiate(yellowSquare));
            yellowSquares[i].transform.position = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
            blueSquares.Add(Instantiate(blueSquare));
            blueSquares[i].transform.position = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
        }

        spawnBlue = false;
        spawnYellow = true;
    }

    public void AddScore() {
        score += 2;
        scoreText.text = score.ToString();
    }

    public void SubtractScore() {
        score -= 1;
        if (score < 0) {
            score = 0;
        }
        scoreText.text = score.ToString();
    }

    public void ResetScore() {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer > spawnInterval && spawnBlue == true) {
            timer = 0;
            SpawnBlueFromPool();
            spawnBlue = false;
            spawnYellow = true;
        }
        if (timer > spawnInterval && spawnYellow == true) {
            timer = 0;
            SpawnYellowFromPool();
            spawnYellow = false;
            spawnBlue = true;
        }
    }

    void SpawnBlueFromPool() {
        for (int i = 0; i < blueSquares.Count; i++) {
            if (!blueSquares[i].activeInHierarchy) {
                Vector3 spawnLocation;
                do {
                    spawnLocation = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
                } while (Mathf.Pow(Mathf.Pow(spawnLocation.x - ball.position.x, 2) + Mathf.Pow(spawnLocation.y - ball.position.y, 2), 1f / 2f) < 0.8);
                blueSquares[i].transform.position = spawnLocation;
                blueSquares[i].SetActive(true);
                break;
            }
        }
    }

    void SpawnYellowFromPool() {
        for (int i = 0; i < yellowSquares.Count; i++) {
            if (!yellowSquares[i].activeInHierarchy) {
                Vector3 spawnLocation;
                do {
                    spawnLocation = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
                } while (Mathf.Pow(Mathf.Pow(spawnLocation.x - ball.position.x, 2) + Mathf.Pow(spawnLocation.y - ball.position.y, 2), 1f / 2f) < 0.8);
                yellowSquares[i].transform.position = spawnLocation;
                yellowSquares[i].SetActive(true);
                break;
            }
        }
    }
}
