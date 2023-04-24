using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/// <summary>
/// TODO: set this as a singleton
/// </summary>
public class SongSelectMenu : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float transitionDuration;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject scrollViewContent;
    private JsonBeatmapParser parser;
    [HideInInspector]
    public SongTemplate selectedSong;
    public AudioSource audioPlayer;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        parser = new JsonBeatmapParser();
        LoadSongs();
    }
    private void Start()
    {
        audioPlayer = FindObjectOfType<AudioSource>();
    }
    private void LoadSongs()
    {
        var songFolderPath = Application.dataPath + "/Resources/Songs";
        DirectoryInfo i = new DirectoryInfo(songFolderPath);
        foreach (var dir in i.GetDirectories())
        {
            CreateSongItem(dir.Name);
        }
    }
    private void CreateSongItem(string songDirName)
    {
        var songImage = Resources.Load<Sprite>($"Songs/{songDirName}/{songDirName}");
        var json = Resources.Load($"Songs/{songDirName}/{songDirName}", typeof(TextAsset)) as TextAsset;
        var beatmapInfo = parser.ParseSong(json);
        var songItem = Instantiate(prefab);
        var itemScript = songItem.GetComponent<SongTemplate>();
        itemScript.songCoverImage = songImage;
        itemScript.songName = beatmapInfo.name;
        itemScript.bpm = beatmapInfo.BPM;
        itemScript.lanes = beatmapInfo.maxBlock;
        songItem.gameObject.transform.SetParent(scrollViewContent.transform);
        itemScript.selectedSongAction += SetSelectedSong;
    }
    private void SetSelectedSong(SongTemplate song)
    {
        StartCoroutine(TriggerFade(transitionDuration, song));
    }
    public void GoToPlayScene()
    {
        SceneManager.LoadScene("NoteParserTest");
        audioPlayer.Stop();
        audioPlayer = null;
    }
    private IEnumerator TriggerFade(float seconds, SongTemplate song)
    {

        audioPlayer.outputAudioMixerGroup.audioMixer.FindSnapshot("Off").TransitionTo(seconds);
        yield return new WaitForSeconds(seconds);
        if (selectedSong != null)
        {
            audioPlayer.Stop();
            Debug.Log("Now playing " + song);
        }
        selectedSong = song;
        audioPlayer.clip = Resources.Load<AudioClip>($"Songs/{song.name}/{song.name}");
        audioPlayer.Play();

        audioPlayer.time = (audioPlayer.clip.length / 3);
        audioPlayer.outputAudioMixerGroup.audioMixer.FindSnapshot("On").TransitionTo(seconds+(seconds / 2));
    }
}
