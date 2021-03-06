﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    void Awake() {
        if (FindObjectsOfType<AudioPlayer>().Length != 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
