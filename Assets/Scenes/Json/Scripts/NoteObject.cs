using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject
{
    public NoteJson NoteInfo;
    public int LinesPerBeat;
    public int NoteIndex;
    public int Column;
    public NoteTypes Type;
    public double NoteTimestamp { get; set; }
    public void ConvertNoteInfo()
    {
        LinesPerBeat = NoteInfo.LPB;
        NoteIndex = NoteInfo.num;
        Column = NoteInfo.block;
        Type = NoteInfo.type switch
        {
            1 => NoteTypes.SingleHit,
            2 => NoteTypes.LongNote,
            _ => throw new System.NotImplementedException()
        };
    }
}
public enum HitWindow
{
    PERFECT,
    OK,
    ALMOST,
    MISS
}
