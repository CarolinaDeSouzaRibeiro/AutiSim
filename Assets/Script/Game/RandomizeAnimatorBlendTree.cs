using System;
using UnityEditor;
using UnityEngine;

public class RandomizeAnimatorBlendTree : MonoBehaviour {
    private Animator animator; // Reference to the Animator component

    [SerializeField]
    private string[] animationStates = {
        "askingquestion",
        "beckoning",
        "cheeringwhilesitting",
        "sitting1",
        "sitting0",
        "sittingandpointing",
        "sittingdisbelief",
        "sittinglaughing",
        "sittingtalking",
        "sittingthumbsup",
        "sittingyell"
    }; // List of animation states to randomize

    private int currentStateHash; // Tracks the current animation state hash
    [SerializeField] private float transitionDuration = 0.25f; // Duration of the fade between animations

    private void Awake() {
        animator = GetComponent<Animator>();
        if (animator == null) {
            // Debug.LogError($"No Animator found on GameObject '{gameObject.name}'. Ensure the Animator is present.");
        }
    }

    private void Start() {
        if (animator == null || animationStates.Length == 0) {
            // Debug.LogWarning($"The script RandomizeAnimatorBlendTree on GameObject '{gameObject.name}' is not configured correctly.");
            return;
        }
        PlayRandomAnimationState();
    }

    private void Update() {
        if (animator == null) return;

        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (currentStateInfo.normalizedTime >= 1.0f && currentStateInfo.shortNameHash == currentStateHash) {
            PlayRandomAnimationState();
        }
    }

    public void PlayRandomAnimationState() {
        if (animator == null || animationStates.Length == 0) {
            // Debug.LogWarning($"Unable to play animation on GameObject '{gameObject.name}'. Check the configuration.");
            return;
        }

        int randomIndex = UnityEngine.Random.Range(0, animationStates.Length);
        string randomState = animationStates[randomIndex];

        animator.CrossFade(randomState, transitionDuration, 0);
        currentStateHash = Animator.StringToHash(randomState);

        // Debug.Log($"Crossfading to animation state '{randomState}' on GameObject '{gameObject.name}'.");
    }
}
