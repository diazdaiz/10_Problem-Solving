using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public float spawnInterval;
    public int maxSpawn;
    List<GameObject> squares;

    float timer;

    private void Awake() {
        timer = 0;
        maxSpawn = Random.Range(3, 14);
        squares = new List<GameObject>();

        for (int i = 0; i < maxSpawn; i++) {
            squares.Add(Instantiate(square));
            squares[i].transform.position = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
        }
    }
}
