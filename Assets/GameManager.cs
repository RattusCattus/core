using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static string currentPlanet = "Virginia";
    public static GameManager gameManager;
    [SerializeField] Animator transition;
    [SerializeField] float sceneSwitchDelay;
    public static Dictionary<string, Vector3> planets;
    bool sceneLoaded = false;
    bool ran = false;

	void Awake() {
		if (!gameManager) {	
			gameManager = this; // In first scene, make us the singleton.
			DontDestroyOnLoad(this);
		} else if (gameManager != this) {
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (!ran) {
            planets = new Dictionary<string, Vector3>();

            // fill dict with planets
            foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet")) {
                planets.Add(planet.name, planet.transform.position);
            }
            ran = true;
        }
    }

    public void Load(string sceneName) {
        // Animate
        StartCoroutine(AnimateAndLoad(sceneName));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) => sceneLoaded = true;

    IEnumerator AnimateAndLoad(string sceneName) {
        transition.SetBool("Load", true);
        yield return new WaitForSeconds(sceneSwitchDelay);
        SceneManager.LoadScene(sceneName);
        if (sceneLoaded) {
            transition.SetBool("Load", false);
        }
    }
}
