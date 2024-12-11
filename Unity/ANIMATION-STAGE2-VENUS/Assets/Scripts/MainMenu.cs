using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to the Animation Clip
    [SerializeField] private Button playButton; // Reference to the Start button
    [SerializeField] private string nextSceneName = "SampleScene"; // Name of the scene to load
    [SerializeField] private float timeAfterWave = 2;//time to wait to switch to next scene after pressing the start button

    private void Start()
    {

        if (animator == null)
        {
            Debug.LogError("Animation clip is not assigned. Please assign it in the Inspector.");
        }

        playButton.onClick.AddListener(PlayStartAnimation);
    }


    private void PlayStartAnimation()
    {
        animator.SetTrigger("HandAnim");
        Invoke(nameof(goToNextScene), timeAfterWave);

    }
    private void goToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}