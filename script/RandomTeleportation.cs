using UnityEngine;

public class RandomTeleportation : MonoBehaviour
{
    public GameObject targetObject; // The object to toggle visibility
    public float disappearDuration = 5f; // Time for which the object is invisible
    public float appearDuration = 3f;    // Time for which the object is visible

    private float timer = 0f;
    private bool isVisible = true;

    void Update()
    {
        // Ensure the target object is assigned
        if (targetObject == null)
        {
            Debug.LogWarning("No target object assigned for ToggleVisibility script.");
            return;
        }

        timer += Time.deltaTime;

        if (isVisible && timer >= appearDuration)
        {
            // Make the game object invisible
            targetObject.SetActive(false);
            isVisible = false;
            timer = 0f;
        }
        else if (!isVisible && timer >= disappearDuration)
        {
            // Make the game object visible
            targetObject.SetActive(true);
            isVisible = true;
            timer = 0f;
        }
    }
}
