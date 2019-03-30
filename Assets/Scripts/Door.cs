using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public int levelClose = 100;
    public int levelOpen = 3;

    public GameObject leap;

    public event Action onClose;
    public event Action onOpen;
    
    private bool isOpen = false;
    private LeapImageRetriever leapImage;

    // Start is called before the first frame update
    void Start()
    {
        leapImage = leap.GetComponent<LeapImageRetriever>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(leapImage.GetDepth());
    }
}
