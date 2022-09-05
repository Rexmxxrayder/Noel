using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class TwelvePartOne : MonoBehaviour {
    string path = "C:\\Software\\Unity\\Projects\\Noel\\Assets\\Texte\\Paths.txt";
    [SerializeField] Dictionary<string, List<string>> caves = new Dictionary<string, List<string>>();
    [SerializeField] List<string> pathName = new List<string>();
    [SerializeField] List<bool> isBig = new List<bool>();
    [SerializeField] List<string> pathList = new List<string>();

    void Start() {
        FillList(path);
        for (int i = 0; i < pathName.Count; i++) {
            Debug.Log("Path : " + pathName[i]);
            for (int j = 0; j < caves[pathName[i]].Count; j++) {
                Debug.Log(caves[pathName[i]][j]);
            }
        }
        for (int i = 0; i < pathName.Count; i++) {
            isBig.Add(false);
        }
        for (int i = 0; i < pathName.Count; i++) {      
            if (Char.IsUpper(pathName[i], 0)) {
                isBig[i] = true;
            }
        }
        ListAllPath();
    }

    void ListAllPath() {
        bool finish = false;
        string currentPath = "";
        string currentCave = "";
        string caveNumber = "";
        string pathNumber = "";
        int currentCaveNumber = 0;
        while (!finish) {
            currentCave = "start";
            currentPath = "start";
            caveNumber += "0";
            pathNumber += "0";
        }
    }


    void FillList(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);
        List<string> path = new List<string>();
        while (!inp_stm.EndOfStream) {
            path.Clear();
            path.AddRange(inp_stm.ReadLine()
            .Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries));
            if (!pathName.Contains(path[0])) {
                pathName.Add(path[0]);
                List<string> newList = new List<string>();
                newList.Add(path[1]);
                caves.Add(path[0], newList);
            } else {
                caves[path[0]].Add(path[1]);
            }

            if (!pathName.Contains(path[1])) {
                pathName.Add(path[1]);
                List<string> newList = new List<string>();
                newList.Add(path[0]);
                caves.Add(path[1], newList);
            } else {
                caves[path[1]].Add(path[0]);
            }
        }
        inp_stm.Close();
    }
}