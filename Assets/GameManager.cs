using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Canvas canvas;
    public Animator transition;
    CinemachineVirtualCamera cinemachine;

    void Awake() {
        gameManager = this;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
        cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void Load(string sceneName) {
        // Animate
        StartCoroutine(AnimateAndLoad(sceneName));
    }

    IEnumerator AnimateAndLoad(string sceneName) {
        transition.SetTrigger("Load");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

    public void ZoomCamera(float value) {
        if (SceneManager.GetActiveScene().name == "Space") {
            cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(cinemachine.m_Lens.OrthographicSize, value, 2f * Time.deltaTime);
        }
    }
}
