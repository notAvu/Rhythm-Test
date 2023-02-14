using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quick skecth of the longNoteScript 
public class LongNote : MonoBehaviour
{
    NoteObject noteData;
    GameObject headNote;
    float StartTime;
    float EndTime;
    GameObject tailNote;
    List<GameObject> nestedNotes;
    LineRenderer lineRenderer;
    GameObject tickNotePrefab;
    private void Awake()
    {
        nestedNotes = new List<GameObject>();
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        headNote = gameObject;//change for better structure
    }
    private void Start()
    {
        InstantiateNestedNotes();
    }
    private void InstantiateNestedNotes()
    {
        var lastNote = noteData.nestedNotes[noteData.nestedNotes.Count - 1];
        noteData.nestedNotes.RemoveAt(noteData.nestedNotes.Count - 1);//Do I need this?
        foreach (var nested in noteData.nestedNotes)
        {
            GameObject note = Instantiate(tickNotePrefab);
            note.GetComponent<SingleHitNote>().noteData = nested;
            //TODO set timeStamps timestamp
            nestedNotes.Add(note);
        }
        SetLinerendererPoints();
    }
    private void SetLinerendererPoints() 
    {
        lineRenderer.SetPosition(0, headNote.transform.position);
        for (int i = 0; i < nestedNotes.Count; i++)
        {
            var position = nestedNotes[i].GetComponent<Transform>().position;
            lineRenderer.SetPosition(i+1, position);
        }
    }
}