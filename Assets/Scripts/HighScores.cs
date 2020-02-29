using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    [System.Serializable]
    private class ExportModel
    {
        internal List<int> Scores { get; set; } = new List<int>();
    }

    [SerializeField] private int highScoreSize = 10;
    [SerializeField] private string fileName = "scores.ikd";
    [SerializeField] private bool useDefaultScore = false;
    [SerializeField] private int linearDefaultScoreIncrement = 10000;
    [SerializeField] private bool forceReset = false;
    private ExportModel storage = new ExportModel();
    private string path;
    private readonly IFormatter formatter = new BinaryFormatter();

    private List<int> Scores { get { return storage.Scores; } }
    public List<int> HighScoreList { get { return new List<int>(storage.Scores); } }

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(path))
        {
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            storage = (ExportModel)formatter.Deserialize(stream);
            stream.Close();
            Scores.Capacity = Scores.Count + 1;
            if (forceReset) Reset();
        }
        else
        {
            Scores.Capacity = highScoreSize + 1;
            Reset();
        }
    }

    private void SaveScores()
    {
        Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, storage);
        stream.Close();
    }

    private void Sort()
    {
        Scores.Sort();
    }

    public void AddScore(int score)
    {
        if (score > Scores[Scores.Count - 1])
        {
            Scores.Add(score);
            Sort();
            Scores.Remove(Scores.Count - 1);
        }

        SaveScores();
    }

    public void Reset()
    {
        for (int i = 0; i < Scores.Count; i++)
        {
            Scores[i] = useDefaultScore ? linearDefaultScoreIncrement * i : 0;
        }

        Sort();
        SaveScores();
    }

    public List<string> ExportScore()
    {
        return Scores.Select(s => Timer.TimeToString(s)).ToList();
    }
}
