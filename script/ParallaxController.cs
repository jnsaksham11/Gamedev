using UnityEngine;
using System.Collections.Generic;

public class ParallaxController : MonoBehaviour
{
    Transform cam; //Main Camera
    Vector3 camStartPos;
    float distance; //Distance between camera start position and current position

    List<GameObject> backgrounds = new List<GameObject>();
    List<Material> mat = new List<Material>();
    List<float> backSpeed = new List<float>();

    float farthestBack;

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed;

    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        // Recursively find all renderable objects
        FindRenderableObjects(transform);

        BackSpeedCalculate();
    }

    void FindRenderableObjects(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // If child has children, recurse into the hierarchy
            if (child.childCount > 0)
            {
                FindRenderableObjects(child);
            }
            else
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    backgrounds.Add(child.gameObject);
                    mat.Add(renderer.material);
                }
            }
        }
    }

    void BackSpeedCalculate()
    {
        foreach (GameObject background in backgrounds)
        {
            float zDifference = background.transform.position.z - cam.position.z;

            // Find the farthest background
            if (zDifference > farthestBack)
            {
                farthestBack = zDifference;
            }
        }

        foreach (GameObject background in backgrounds)
        {
            float zDifference = background.transform.position.z - cam.position.z;
            backSpeed.Add(1 - (zDifference / farthestBack));
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);

        for (int i = 0; i < backgrounds.Count; i++)
        {
            if (mat[i] == null)
            {
                Debug.LogWarning($"Material for background {i} is null. Skipping.");
                continue;
            }

            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
