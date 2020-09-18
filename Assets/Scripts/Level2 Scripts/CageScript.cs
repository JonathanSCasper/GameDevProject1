using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour
{
    public ParticleSystem OpenCage;

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
        }
    }

    public void UnlockCage()
    {
        gameObject.SetActive(false);
        OpenCage.Play();
        Debug.Log("Open cage");
    }
}
