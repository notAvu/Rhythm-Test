using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RhythmConductor : MonoBehaviour
{
    public TextAsset jsonFile;
    private AudioSource songAudio;
    [SerializeField]
    private GameObject beatBar;

    private int songBpm;
    private int notesPerBeat;
    public float secondsPerNote;

    private float offset;
    private int columns;

    public float songPosition;
    public float songPositionSeconds;
    public float lastBeat;
    private float dpsTime;

    private void Awake()
    {
        ReadBeatmapInfo();
    }
    private void Start()
    {
        lastBeat = 0;
        songAudio = GetComponent<AudioSource>();
        dpsTime = (float)AudioSettings.dspTime;
        secondsPerNote = 60f / (songBpm * notesPerBeat);
        //secondsPerBeat = 60f / songBpm ;
        InstantiateWholeMap(notes);
        songAudio.Play();
    }
    private void Update()
    {
        songPositionSeconds = (float)((AudioSettings.dspTime - dpsTime) - offset);
        songPosition = songPositionSeconds / secondsPerNote;
        //Debug.Log($"songPosition: {songPosition}");
        if (lastBeat > 0 && (int)lastBeat != SingleHitNote.lastIndex)
        {
            SingleHitNote.lastIndex = (int)lastBeat;
            SpawnBar();
        }
        if (songPosition > lastBeat + secondsPerNote)
        {
            lastBeat += secondsPerNote;
            //Debug.Log($"LastBeat: {(int)lastBeat}");
        }
    }
    List<NoteObject> notes = new List<NoteObject>();
    private void ReadBeatmapInfo()
    {
        JsonBeatmapParser jsonParser = new JsonBeatmapParser();
        var beatmapInfo = jsonParser.ParseBeatmap(jsonFile);
        songBpm = beatmapInfo.BPM;
        notesPerBeat = beatmapInfo.notes[0].LPB;
        offset = (float)beatmapInfo.offset / 1000f;
        columns = beatmapInfo.maxBlock;
        beatmapInfo.notes.ToList().ForEach(item => { var noteObj = new NoteObject(item); notes.Add(noteObj); });
    }
    #region testing shit
    [SerializeField]
    [Header("Single note (test)")]
    private GameObject singleNotePrefab;
    /// <summary>
    /// This shit should be done instantiated differently, this is just for testing
    /// </summary>
    /// <param name="notes"></param>
    private void InstantiateWholeMap(List<NoteObject> notes)
    {
        List<NoteObject> singles = notes.Where(not => not.Type == NoteTypes.SingleHit).ToList();
        List<SingleHitNote> singleHitNotes = new List<SingleHitNote>();
        foreach (var note in singles)
        {
            var newNote = Instantiate(singleNotePrefab);
            newNote.GetComponent<SingleHitNote>().noteData = note;
            newNote.GetComponent<SingleHitNote>().NoteTimestamp = newNote.GetComponent<SingleHitNote>().noteData.NoteIndex * secondsPerNote + offset;
            newNote.GetComponent<SingleHitNote>().InstantiationTimestamp = newNote.GetComponent<SingleHitNote>().NoteTimestamp - (secondsPerNote * 8);
        }
        Debug.Log(singles.Count);
    }
    private void SpawnBar()
    {
        var uwu = Instantiate(beatBar);
        uwu.GetComponent<SingleHitNote>().index = (int)lastBeat;
        uwu.GetComponent<SingleHitNote>().InstantiationTimestamp = lastBeat * secondsPerNote;
    }
    #endregion
}