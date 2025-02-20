using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
//using TMPro.EditorUtilities;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;


public class DrumTimer : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private DrumSounds playerDrumSound;

    [SerializeField] private float bpm;
    [SerializeField] private float maxTime;
    // There is another word for this, but I can't remember
    [SerializeField] private float maxTimeDif = 0.1f;

    private float timer;
    private float beatTimer;


    private int inputDrum = 0;

    private bool checkDrumOne;
    private bool checkDrumTwo;

    public bool timerOn = false;
    private bool beatTimerBool = false;
    private bool inBeat = false;

    private bool firstValueZero = true;


    public MagicDrumRhythm[] magicDrumRhythms;
    MagicDrumRhythm magicDrumRhythm;
    
    MagicDrumRhythm.DrumSoundEnum drumSoundEnum;
    MagicDrumRhythm.DrumSoundEnum[] drumSoundEnums = new MagicDrumRhythm.DrumSoundEnum[3];
    //MagicDrumRhythm.DrumSoundEnum[] drumSoundEnums;
    //MagicDrumRhythm.DrumSoundEnum[] magicDrumEnum;

    MagicDrumRhythm.DrumSoundEnum currentDrumEnum;


    public enum TestEnum { None , One, Two};
    TestEnum currentEnum;
    TestEnum currentArrayEnum;
    TestEnum currentListEnum;
    


    TestEnum[] rhythmArrayTest = { TestEnum.One, TestEnum.One, TestEnum.Two };
    TestEnum[] inputArray = new TestEnum[2];

    MagicDrumRhythm.DrumSoundEnum[] magicDrumArrays;


    // This solution is not very good. 
    List<TestEnum> rhythmListTest = new List<TestEnum>() { TestEnum.One, TestEnum.One, TestEnum.Two};
    //ListInspector


    List<TestEnum> inputList = new List<TestEnum>();

    //int _currentPosArray;
    int[] countArray;
    int countArrayLenght;
    int countArrayPos;
    int mdrPos;

    int currentMRArray;

    int countRhythmsInList;
    int playRhythmInArrayInt;


    // This value will be dependent on the song
    public int maxRhythmLength = 2;

    float songInitInputCounter = 0;
    float timeDelay;
    float deviationTime;

    bool songIsFound = false;
    bool songTransition = false;

    void Start()
    {
        currentEnum = TestEnum.None;

        currentArrayEnum = rhythmArrayTest[0];
        currentListEnum = rhythmListTest[0];
        
        magicDrumArrays = magicDrumRhythms[0].DrumSequence;
        currentDrumEnum = magicDrumArrays[0];

        drumSoundEnum = drumSoundEnums[0];

        countArray = new int[countArrayLenght];

        countArrayPos = 0;        
    }

    void FixedUpdate()
    {    

        if (controller.isPlayingDrums)
        {       
            CheckDrumInput();
            CheckDrumRhythm();
        }
        BeatTimer();
        MRBeatTimer();
        SongTransition();

        InputTimer();

    }

    void InputTimer()
    {
        
        if(timerOn)
        {
            timer += Time.deltaTime;
            //Debug.Log("Timer is: " + timer);
            if(timer > maxTime)
            {
                timerOn = false;
                Debug.Log("Time's over");
                timer = 0;
            }
        }
    }

    void SongTransition()
    {
        if (songTransition)
        {
            for (int j = 0; j < magicDrumRhythms.Length; j++)
            {
                magicDrumRhythms[j].currentPosArray = 0;
                currentDrumEnum = magicDrumRhythms[j].DrumSequence[magicDrumRhythms[j].currentPosArray];
            }
            songTransition = false;
        }
    }

    void BeatTimer()
    {
        if (beatTimerBool)
        {
            beatTimer += Time.deltaTime;
            //Debug.Log("Beat: " + beatTimer);
        }
        else if (!beatTimerBool)
        {
            beatTimer = 0;         
        }
    }

    void MRBeatTimer()
    {
        for (int i = 0; i < magicDrumRhythms.Length; i++)
        {
                magicDrumRhythms[i].rhythmBeatTimer = beatTimer;       
        }
        
    }


    void CheckDrumInput()
    {
        checkDrumOne = controller.PlayDrumsOne();       
        checkDrumTwo = controller.PlayDrumsTwo();

        if (controller.isRightDrum) 
        {
            currentEnum = TestEnum.One;
            playerDrumSound.PlayTap();
            drumSoundEnum = MagicDrumRhythm.DrumSoundEnum.Tap;

            PlayMagicRhythm();

            if (!beatTimerBool)
            {
                beatTimerBool = true;
            }
        }

        if (controller.isLeftDrum)
        {
            currentEnum = TestEnum.Two;
            playerDrumSound.PlayBeat();
            drumSoundEnum = MagicDrumRhythm.DrumSoundEnum.Beat;

            PlayMagicRhythm();

            if (!beatTimerBool)
            {
                beatTimerBool = true;
            }
        }
    }

    void PlayMagicRhythm()
    {
        if(!songIsFound)
        {
            for (int j = 0; j < magicDrumRhythms.Length; j++)
            {
                InitializeRhythm(j);
            }
        }
        else if (songIsFound)
        {
            KeepRhythm();
        }
        
    }


    void KeepRhythm()
    {
        Debug.Log("Song '" + magicDrumRhythms[playRhythmInArrayInt].Name + "' is now played");

        //Debug.Log("Following Enum is: " + drumSoundEnum);
        currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[playRhythmInArrayInt].currentPosArray];
        //Debug.Log("Current input is: " + currentDrumEnum);

        timeDelay = 60 / magicDrumRhythms[playRhythmInArrayInt].bpm;
        deviationTime = magicDrumRhythms[playRhythmInArrayInt].deviationBpm;

        //beatTimerBool = true;

        if (drumSoundEnum == currentDrumEnum)
        {  

            if (magicDrumRhythms[playRhythmInArrayInt].currentPosArray == magicDrumRhythms[playRhythmInArrayInt].DrumSequenceMaxLength)
            {
                countArrayPos = 0;


                //countArrayPos = magicDrumRhythms[playRhythmInArrayInt].currentPosArray;

                magicDrumRhythms[playRhythmInArrayInt].currentPosArray = 0;
                currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[playRhythmInArrayInt].currentPosArray];

                //currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[countArrayPos];
                //Debug.Log("CurrentDrumEnum is: " + currentDrumEnum);
                Debug.Log("Song reboots");

                if (beatTimerBool)
                {
                    if (beatTimer >= timeDelay - deviationTime && beatTimer <= timeDelay + deviationTime)
                    {            
                        Debug.Log("In Beat");
                        Debug.Log("Current beat is: " + beatTimer);
                        beatTimer = 0;
                    }
                    else
                    {
                        
                        beatTimerBool = false;
                        Debug.Log("Out of Beat");
                        Debug.Log("Current Beat time: " + beatTimer);
                        Debug.Log("Beat Time Min: " + (timeDelay - deviationTime) + " | Beat Time Max: " + (timeDelay + deviationTime));
                        Debug.Log("BPM is: " + timeDelay);
                        beatTimer = 0;

                        playerDrumSound.PlayError();
                        magicDrumRhythms[playRhythmInArrayInt].currentPosArray = 0;
                        currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[playRhythmInArrayInt].currentPosArray];
                        //playRhythmInArrayInt = 0;
                        Debug.Log("ArrayInt is: " + playRhythmInArrayInt);
                        songIsFound = false;
                        firstValueZero = true;
                        beatTimerBool = false;
                    }
                }
            }
            else
            {
                magicDrumRhythms[playRhythmInArrayInt].currentPosArray++;
                //countArrayPos = playRhythmInArrayInt;
                countArrayPos++;
                //currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[countArrayPos].currentPosArray];
                currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[playRhythmInArrayInt].currentPosArray];
                Debug.Log("Song continous");

                if (beatTimerBool)
                {
                    if (beatTimer >= timeDelay - deviationTime && beatTimer <= timeDelay + deviationTime)
                    {
                        beatTimer = 0;
                        Debug.Log("In Beat");
                        //Debug.Log("BPM is: " + timeDelay);
                    }
                    else
                    {
                        
                        beatTimerBool = false;
                        Debug.Log("Out of Beat");
                        Debug.Log("Current Beat time: " + beatTimer);
                        Debug.Log("Beat Time Min: " + (timeDelay - deviationTime) + " | Beat Time Max: " + (timeDelay + deviationTime));
                        //Debug.Log("BPM is: " + timeDelay);
                        //beatTimer = 0;

                        playerDrumSound.PlayError();
                        magicDrumRhythms[playRhythmInArrayInt].currentPosArray = 0;
                        currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[playRhythmInArrayInt].currentPosArray];
                        //playRhythmInArrayInt = 0;
                        songIsFound = false;
                        firstValueZero = true;
                        beatTimerBool = false;
                        Debug.Log("ArrayInt is: " + playRhythmInArrayInt);
                    }
                }
            }
            
        }
        else
        {
            //countArrayPos = 0;
            Debug.Log("Cancelled input is: " + currentDrumEnum + " | Need to play: " + drumSoundEnum);
            magicDrumRhythms[playRhythmInArrayInt].currentPosArray = 0;
            //countArrayPos = magicDrumRhythms[playRhythmInArrayInt].currentPosArray;
            //currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[countArrayPos].currentPosArray];
            currentDrumEnum = magicDrumRhythms[playRhythmInArrayInt].DrumSequence[magicDrumRhythms[playRhythmInArrayInt].currentPosArray];
            Debug.Log("Song is cancelled");            
            playerDrumSound.PlayError();
            //playRhythmInArrayInt = 0;
            songIsFound = false;
            firstValueZero = true;
            beatTimerBool = false;
        }
    }

    // A step counter that is seperate from another. Do it tomorrow!
    void InitializeRhythm(int i)
    {;
        //int i = 1;
        //Debug.Log("Player drum input is: " + drumSoundEnum);

        // Let's hope this works
        currentDrumEnum = magicDrumRhythms[i].DrumSequence[magicDrumRhythms[i].currentPosArray];
        //Debug.Log("Starting Drum Enum is: " + currentDrumEnum);
        
        timeDelay = 60/magicDrumRhythms[i].bpm;
        deviationTime = magicDrumRhythms[i].deviationBpm;

        //if(timerOn)
        //{
        //    beatTimer += Time.deltaTime;          
        //}
        //if(!timerOn)
        //{
        //    timerOn = true;
        //    beatTimer = 0;
        //}

        //Debug.Log("CurrentDrumEnum is " + currentDrumEnum);
        if (drumSoundEnum == currentDrumEnum)
        {

            if (magicDrumRhythms[i].currentPosArray == magicDrumRhythms[i].DrumSequenceMaxLength)
            {

                //Debug.Log("Song is: " + magicDrumRhythms[i].Name);
                playRhythmInArrayInt = i;
                Debug.Log("Song int is: " + playRhythmInArrayInt);
                songIsFound = true;
                //countArrayPos = 0;
                //magicDrumRhythms[i].currentPosArray = 0;
                //currentDrumEnum = magicDrumRhythms[i].DrumSequence[magicDrumRhythms[i].currentPosArray];

                //if (beatTimerBool)
                //{
                //    Debug.Log("In Beat");
                //    Debug.Log("Current beat is: " + beatTimer);
                //    beatTimer = 0;

                //    if (beatTimer >= timeDelay - deviationTime && beatTimer <= timeDelay + deviationTime)
                //    {
                //        //beatTimer = 0;
                //        magicDrumRhythms[i].rhythmBeatTimer = beatTimer;
                //        Debug.Log("In Beat");
                //        //Debug.Log("BPM is: " + timeDelay);
                //    }
                //    else
                //    {
                //        beatTimerBool = false;
                //        playerDrumSound.PlayError();
                //        Debug.Log("Out of Beat");
                //        Debug.Log("Current Beat time: " + beatTimer);
                //        Debug.Log("Beat Time Min: " + (timeDelay - deviationTime) + " | Beat Time Max: " + (timeDelay + deviationTime));
                //        Debug.Log("BPM is: " + timeDelay);
                //        //beatTimer = 0;
                //        magicDrumRhythms[i].rhythmBeatTimer = 0;
                //        //beatTimer = 0;
                //        //beatTimerBool = false;
                //    }
                //}
                

                if (songIsFound)
                {
                    magicDrumRhythms[i].currentPosArray = 0;
                    songInitInputCounter = 0;
                    //magicDrumRhythms[i].currentPosArray++;
                    currentDrumEnum = magicDrumRhythms[i].DrumSequence[magicDrumRhythms[i].currentPosArray];
                    //Debug.Log(magicDrumRhythms[i].Name + " has been set zero");
                    playerDrumSound.PlayCorrect();
                    songTransition = true;
                    // Turn 'songIsFound' false in its function         
                }

            }
       
            else
            {
                //countArrayPos++;
                magicDrumRhythms[i].currentPosArray++;               
                currentDrumEnum = magicDrumRhythms[i].DrumSequence[magicDrumRhythms[i].currentPosArray];
                Debug.Log("Song increases to: " + currentDrumEnum);
                //songInitInputCounter++;

                //if (beatTimerBool)
                //{
                //    //beatTimerBool = false;
                //    Debug.Log("Out of Beat");
                //    Debug.Log("Current beat is: " + beatTimer);
                //    beatTimer = 0;

                //    if (beatTimer >= timeDelay - deviationTime && beatTimer <= timeDelay + deviationTime)
                //    {
                //        //beatTimer = 0;
                //        magicDrumRhythms[i].rhythmBeatTimer = beatTimer;
                //        Debug.Log("In Beat");
                //        //Debug.Log("BPM is: " + timeDelay);
                //    }
                //    else
                //    {
                //        beatTimerBool = false;
                //        playerDrumSound.PlayError();
                //        Debug.Log("Out of Beat");
                //        Debug.Log("Current Beat time: " + beatTimer);
                //        Debug.Log("Beat Time Min: " + (timeDelay - deviationTime) + " | Beat Time Max: " + (timeDelay + deviationTime));
                //        Debug.Log("BPM is: " + timeDelay);
                //        //beatTimer = 0;
                //        magicDrumRhythms[i].rhythmBeatTimer = 0;
                //        //beatTimer = 0;
                //        //beatTimerBool = false;
                //    }
                //}

            }

            beatTimer = 0;
        }
        else if (drumSoundEnum != currentDrumEnum)
        {
            //countArrayPos = 0;
            //magicDrumRhythms[i].currentPosArray = 0;
            //currentDrumEnum = magicDrumRhythms[i].DrumSequence[magicDrumRhythms[i].currentPosArray];
            //currentDrumEnum = magicDrumRhythms[i].DrumSequence[i];

            //currentDrumEnum = magicDrumRhythms[i].DrumSequence[j];
            //Debug.Log(magicDrumRhythms[i].currentPosArray);
            //Debug.Log(currentDrumEnum);

            //Debug.Log("Wrong input");          
            //Debug.Log("Current number is: " + countArrayPos);
            firstValueZero = true;

            // This doesn't work right now.
            //if (beatTimerBool)
            //{
                
            //    Debug.Log("Out of Beat");
            //    Debug.Log("Current beat is: " + magicDrumRhythms[i].rhythmBeatTimer);
            //    magicDrumRhythms[i].rhythmBeatTimer = 0;

            //    magicDrumRhythms[i].currentPosArray = 0;
            //    currentDrumEnum = magicDrumRhythms[i].DrumSequence[magicDrumRhythms[i].currentPosArray];
            //}

                //beatTimerBool = false;
                //Debug.Log("Missed the Input");
                //beatTimer = 0;
        }

        //if (!beatTimerBool)
        //{
        //    beatTimerBool = true;
        //    Debug.Log("Beat Timer is on");
        //}

        //for (int i = 0; i < magicDrumRhythms.Length; i++)
        //{

        //}

        //for (int j = 0; j < drumSoundEnums.Length; j++)
        //{
        //    Debug.Log("TEST" + mdr.DrumSequence[j]);
        //}
    }



    void CompareInputToValue()
    {
        if (currentArrayEnum == currentEnum)
        {
            Debug.Log("Former number is: " + countRhythmsInList);
            Debug.Log("Former Array Enum is: " + currentArrayEnum);

            // This works alright. But floating numbers are bad
            if (countRhythmsInList == maxRhythmLength)
            {
                Debug.Log("Song is done");
                countRhythmsInList = 0;
                currentArrayEnum = rhythmArrayTest[countRhythmsInList];
            }
            else
            {
                countRhythmsInList++;
                currentArrayEnum = rhythmArrayTest[countRhythmsInList];
            }

            //currentListEnum = rhythmListTest[countRhythmsInList];
            //currentArrayEnum = rhythmArrayTest[countRhythmsInList];

            Debug.Log("Current number is: " + countRhythmsInList);
            Debug.Log("Current Enum  is: " + currentArrayEnum);
            //Debug.Log("Current Enum  is: " + currentListEnum);
            //currentArrayEnum++;

        }
        else
        {
            //currentArrayEnum = rhythmArrayTest[0];
            countRhythmsInList = 0;
            //currentListEnum = rhythmListTest[countRhythmsInList];
            currentArrayEnum = rhythmArrayTest[countRhythmsInList];
            Debug.Log("Wrong input");
            Debug.Log("Current number is: " + countRhythmsInList);
            firstValueZero = true;
        }
    }

    void CheckDrumRhythm()
    {
        if(inputDrum == 3)
        {
            Debug.Log("Rhythm is: (Here Songname)");
            RhythmComparer();
            inputDrum = 0;
        }
    }


    void BeatChecker()
    {
        if(timer == 0)
        {
            Debug.Log("No bpm");
        }
        else if (timer <= 0.25f && timer >= 0.15f)
        {
            Debug.Log("BPM is 240");
        }
        else if (timer <= 0.6f && timer >= 0.4f)
        {
            Debug.Log("BPM is 120");
        }
        else
        {
            Debug.Log("idk");
        }

    }

    //Change the name, it's terrible
    void RhythmComparer()
    {
        // This checks for all at once. It needs to be activated one after the other.

        if (rhythmArrayTest[1] == currentEnum)
        {

        }




        if(inputArray.Length == rhythmArrayTest.Length)
        {
            for (int i = 0; i < rhythmArrayTest.Length; i++)
            {
                if (inputArray[i] == rhythmArrayTest[i])
                {
                    Debug.Log("Enums are equal");
                }
                else
                    Debug.Log("Enums are not equal");
            }
        }
        
    }

}
