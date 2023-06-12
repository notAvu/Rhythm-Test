using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnColumn : MonoBehaviour
{
    #region constants
    public const float COLUMN_WIDTH = 0;
    #endregion
    #region components
    [SerializeField]
    private AudioSource hitAudioSource;
    [SerializeField]
    private AudioSource missAudioSource;
    #endregion
    #region gameObject attributes
    public int ColumnIndex;
    [SerializeField]
    public Vector2 spawnPosition;
    [SerializeField]
    public Vector2 despawnPosition;
    #endregion
    #region notes
    [SerializeField]
    [Header("Single hit note prefab")]
    private GameObject singleNotePrefab;
    [SerializeField]
    [Header("Long note prefab")]
    private GameObject longNotePrefab;
    private List<GameObject> notes = new List<GameObject>();
    public int InputIndex { get; set; } //the index of thenext note to be hit in this lane 
    #endregion
    [HideInInspector]
    public Transform HitBar;
    #region input 
    private RhythmInput inputActions;
    #endregion
    #region unity events
    private void Awake()
    {
        inputActions = new RhythmInput();
        HitBar = GameObject.Find("HitBar").transform;
    }
    private void Start()
    {
        //var x = GameObject.Find("InputManager").GetComponent<PlayerInput>();
        //playerInput = x;
        //playerInput.actions[$"Lane{ColumnIndex + 1}Input"].performed += ctx => OnButtonPress();
        //playerInput.actions[$"Lane{ColumnIndex + 1}Input"].canceled += ctx => OnButtonRelease();
    }
    InputAction inputAction;
    private void OnEnable()
    {
        inputAction = ColumnIndex switch
        {
            0 => inputActions.SongInput.Lane1Input,
            1 => inputActions.SongInput.Lane2Input,
            2 => inputActions.SongInput.Lane3Input,
            3 => inputActions.SongInput.Lane4Input,
            _ => null
        };
        inputAction.performed += OnButtonPress;
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }
    private void FixedUpdate()
    {
        //Debug.Log($"Input Index: {InputIndex} \n Lane {ColumnIndex}  notes:{notes.Count}");
        //var note = notes[InputIndex];
        //note.GetComponent<SpriteRenderer>().color = Color.black;
    }
    #endregion
    #region Input management

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        //hitAudioSource.Play();
        //var lastInputTs = RhythmConductor.Instance.GetAudioSourceTime();
        var currentNoteTs = notes[InputIndex].GetComponent<HitNote>().NoteTimestamp;
        var note = notes[InputIndex];
        //note.GetComponent<SpriteRenderer>().color = Color.black;
        var songTime = RhythmConductor.Instance.songPositionSeconds;
        var hitWindowDiff = 0.15f;
        //Debug.Log($"Lane{ColumnIndex}: CurrentNote {currentNoteTs}, Songtime {songTime} ,diff{currentNoteTs-songTime}");
        var hitDiff = Math.Abs(songTime - currentNoteTs);
        if (hitDiff < hitWindowDiff)
        {
            if (note.GetComponent<IHitObject>().GetType().Equals(typeof(SingleHitNote)))
            {
                note.GetComponent<IHitObject>().Hit();
                hitAudioSource.Play();
            }
            else if (note.GetComponent<IHitObject>().GetType().Equals(typeof(LongNote)))
            {

            }
        }
        else if (hitDiff > hitWindowDiff && hitDiff < 0.2f)
        {
            if (note.GetComponent<IHitObject>().GetType().Equals(typeof(SingleHitNote)))
            {
                note.GetComponent<IHitObject>().Miss();
                //missAudioSource.Play();
            }
            else if (note.GetComponent<IHitObject>().GetType().Equals(typeof(LongNote)))
            {

            }
        }
    }
    private void LongNoteHit()
    {

    }
    private void OnButtonRelease(InputAction.CallbackContext context)
    {

    }
    #endregion
    #region note instantiation
    // This may be better done as a coroutine that loads the level in a loading screen before playing the actual song
    /// <summary>
    /// Generates the notes that are going to be played in this column
    /// </summary>
    /// <param name="noteList"></param>
    public void InstantiateNotes(List<NoteObject> noteList)
    {
        foreach (var note in noteList)
        {
            if (note.Type == NoteTypes.SingleHit)
            {
                AddSingleNote(note);
            }
            else if (note.Type == NoteTypes.LongNote)
            {
                AddLongNote(note);
            }
        }
    }
    /// <summary>
    /// Instantiates and adds a long note to the list of notes that will appear in this column
    /// </summary>
    /// <param name="note">A<seealso cref="NoteObject"/> object containing the data extracted from the json file abt this note</param>
    private void AddLongNote(NoteObject note)
    {
        var longNoteHead = Instantiate(longNotePrefab);
        longNoteHead.transform.position = spawnPosition;
        LongNote longNoteScript = longNoteHead.GetComponent<LongNote>();
        longNoteScript.NoteData = note;
        longNoteScript.Column = this;
        longNoteScript.InstantiateNestedNotes();
        longNoteScript.StartTime = longNoteScript.NoteData.NoteIndex * RhythmConductor.Instance.secondsPerNote + RhythmConductor.Instance.offset;
        longNoteScript.InstantiationTimestamp = longNoteScript.StartTime - (RhythmConductor.Instance.secondsPerNote * 8);
        longNoteScript.NestedNotes.ForEach(nested =>
        {
            nested.GetComponent<TickNoteScript>().NoteTimestamp = nested.GetComponent<TickNoteScript>().noteData.NoteIndex * RhythmConductor.Instance.secondsPerNote + RhythmConductor.Instance.offset;
            nested.GetComponent<TickNoteScript>().InstantiationTimestamp = nested.GetComponent<TickNoteScript>().NoteTimestamp - (RhythmConductor.Instance.secondsPerNote * 8);
            nested.GetComponent<TickNoteScript>().Column = this;
            notes.Add(nested);
        });
        longNoteScript.EndTime = longNoteScript.TailNote.GetComponent<TickNoteScript>().NoteTimestamp;
        notes.Add(longNoteHead);
    }
    /// <summary>
    /// Instantiates and adds a single hit note to the list of notes that will appear in this column
    /// </summary>
    /// <param name="note">A<seealso cref="NoteObject"/> object containing the data extracted from the json file abt this note</param>
    private void AddSingleNote(NoteObject note)
    {
        var newNote = Instantiate(singleNotePrefab);
        newNote.transform.position = spawnPosition;
        SingleHitNote noteScript = newNote.GetComponent<SingleHitNote>();
        noteScript.noteData = note;
        //noteScript.RhythmConductor.Instance = RhythmConductor.Instance;
        noteScript.column = this;
        noteScript.NoteTimestamp = noteScript.noteData.NoteIndex * RhythmConductor.Instance.secondsPerNote + RhythmConductor.Instance.offset;
        noteScript.InstantiationTimestamp = noteScript.NoteTimestamp - (RhythmConductor.Instance.secondsPerNote * 8); //TODO: ajustar, probablemente este sea el problema que hace que el timing vaya regu
        notes.Add(newNote);
    }
    #endregion
}
