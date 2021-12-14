using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSix: MonoBehaviour
{
    public GameObject square;
    public float spawnInterval;
    int maxSpawn;
    List<GameObject> squares;

    private void Awake() {
        maxSpawn = Random.Range(3, 14);
        squares = new List<GameObject>();

        for (int i = 0; i < maxSpawn; i++) {
            squares.Add(Instantiate(square));
            squares[i].transform.position = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
        }
    }
}
