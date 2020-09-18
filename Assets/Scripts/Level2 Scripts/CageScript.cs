using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour
{
    public ParticleSystem OpenCage;

    private bool hasKey = false;

    void Start()
    {
        OpenCage.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Got Key");
            hasKey = true;
        }
    }

    public void UnlockCage()
    {
        gameObject.SetActive(false);
        OpenCage.Play();
        Debug.Log("Open cage");
    }
}
