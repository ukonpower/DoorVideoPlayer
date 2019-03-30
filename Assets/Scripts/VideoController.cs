﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
public class VideoController : MonoBehaviour
{
    private VideoPlayer vp;
    private string[] videoList;
    private int lastVideo = -1;

    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        videoList = getVideoFiles();
    }

    string[] getVideoFiles(){
        string basePath = Application.streamingAssetsPath + "/videos/";

        DirectoryInfo dInfo = new DirectoryInfo(basePath);
        FileInfo[] fInfo = dInfo.GetFiles("*.mp4");

        string[] paths = new string[fInfo.Length];
        for(int i = 0; i < fInfo.Length; i++)
        {
            paths[i] = basePath + fInfo[i].Name;
        }
        return paths;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(){
        int nextVideo = Random.Range(0,videoList.Length);

        if(nextVideo == lastVideo){
            nextVideo = (nextVideo + 1) % videoList.Length;
        }

        vp.url = videoList[nextVideo];
        vp.Play();

        Debug.Log("play:" + vp.url);
    }
}
