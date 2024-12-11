using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to Animator component
    [SerializeField] private Button playButton; // Reference to the Start button
    [SerializeField] private string animationTriggerName = "StartAnimation"; // Name of the animation trigger
    [SerializeField] private string nextSceneName = "SampleScene"; // Name of the scene to load

    private void Start()
    {
        // Ensure the button's onClick event triggers the PlayAnimation method
        playButton.onClick.AddListener(PlayStartAnimation);
    }

    private void PlayStartAnimation()
    {
        // Play the animation using an Animator trigger
        animator.SetTrigger(animationTriggerName);
        
        // Start a coroutine to wait for the animation to finish and load the next scene
        StartCoroutine(WaitForAnimationAndLoadScene());
    }

    private IEnumerator WaitForAnimationAndLoadScene()
    {
        // Wait until the animation has finished playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}