using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {
    public void loadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
