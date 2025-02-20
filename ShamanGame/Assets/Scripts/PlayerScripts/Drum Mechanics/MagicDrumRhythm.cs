using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MagicDrumRhythm", menuName = "Scriptable Objects/MagicDrumRhythm")]
public class MagicDrumRhythm : ScriptableObject
{
    // Change the names based on the actual drum techniques
    public enum DrumSoundEnum { None, Tap, Beat }

    public DrumSoundEnum[] DrumSequence;
    public DrumSoundEnum DrumSound;
    // NOTE: The Sequence Length Must be as long as the array/list
    public int DrumSequenceMaxLength;
    public string DebugNote;
    public string Name;

    public int currentPosArray = 0;

    public float bpm = 120f;
    public float deviationBpm = 0.4f;
    public float rhythmBeatTimer = 0f;

    public void SpellMechanic()
    {
        Debug.Log(DebugNote);
        // The spell can be a scriptable object itself. Or each a unique class
    }

    // --- Commented out due to Compilor Error ---
    //private void OnEnable()
    //{
    //    EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
    //    EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    //}
    //private void OnPlayModeStateChanged (PlayModeStateChange obj)
    //{
    //    switch (obj)
    //    {
    //        case PlayModeStateChange.EnteredPlayMode:
    //            currentPosArray = 0; 
    //            break;
    //    }
    //}

}
