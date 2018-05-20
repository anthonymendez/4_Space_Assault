using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour {
    [Range(0f,10f)][SerializeField] float loadTime = 2.5f;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        Invoke("LoadMainGame", loadTime);
	}
	
	private void LoadMainGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
