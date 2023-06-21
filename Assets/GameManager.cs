using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Canvas canvas;
    public Animator transition;
    public float sceneSwitchDelay;
    CinemachineVirtualCamera cinemachine;
    bool sceneLoaded = false;

	void Awake()
	{
		if(gameManager == null)
		{	
			gameManager = this; // In first scene, make us the singleton.
			DontDestroyOnLoad(this);
		}
		else if(gameManager != this)
			Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.

        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    void FixedUpdate() {
        if (cinemachine == null) {
            cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>(); 
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

    public void ZoomCamera(float value) {
        cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(cinemachine.m_Lens.OrthographicSize, value, 2f * Time.deltaTime);
    }
}
