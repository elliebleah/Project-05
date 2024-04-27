using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{
    public Transform parentTransform; // Parent transform containing objects to activate
    public string tagToActivate = "Active"; // Tag to identify objects to activate
    public int numToActivate = 1; // Number of objects to activate each time
    public float delayBeforeActivation = 2f; // Delay before activating objects
    public float durationAmount = 5f; // Duration for which objects are active

    IEnumerator ActivateObjects()
    {
        // Deactivate all objects under the parent transform
        foreach (Transform child in parentTransform)
        {
            if (child.CompareTag(tagToActivate))
            {
                child.gameObject.SetActive(false);
            }
        }

        yield return new WaitForSeconds(delayBeforeActivation);

        // Get all child objects with the specified tag
        List<GameObject> objectsWithTag = new List<GameObject>();
        foreach (Transform child in parentTransform)
        {
            if (child.CompareTag(tagToActivate))
            {
                objectsWithTag.Add(child.gameObject);
            }
        }

        // Shuffle the list to randomize which objects get activated
        Shuffle(objectsWithTag);

        // Activate the specified number of objects
        for (int i = 0; i < Mathf.Min(numToActivate, objectsWithTag.Count); i++)
        {
            objectsWithTag[i].SetActive(true);
        }

        // Wait for the duration
        yield return new WaitForSeconds(durationAmount);

        // Repeat the process
        StartCoroutine(ActivateObjects());
    }

    void Start()
    {
        StartCoroutine(ActivateObjects());
    }

    // Fisher-Yates shuffle algorithm to shuffle the list
    void Shuffle(List<GameObject> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
