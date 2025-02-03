using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballManager : MonoBehaviour
{

    public string correctBasketTag;
    private bool hasScored = false; // Prevent multiple scoring

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //other.GetComponent<AudioSource>().Play();

        if (!hasScored && other.CompareTag(correctBasketTag))
        {
            hasScored = true;
            GameManager.Instance.AddScore(1);
        }
    }
}
