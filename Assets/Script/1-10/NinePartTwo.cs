using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class NinePartTwo : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\LavaTubes.txt";
    public List<string> lines = new List<string>();
    public List<int> bassins = new List<int>();
    public int[,] lavatubes;
    public int[,] lavatubesBassins;
    public bool[,] lavatubesBassinsCheck;
    public int newBassins = 0;
    public int[] biggerBassins = new int[3];
    public int total = 0;
    void Start() {
        FillList(path, ref lines);
        lavatubes = new int[lines.Count, lines[0].Length];
        lavatubesBassins = new int[lines.Count, lines[0].Length];
        lavatubesBassinsCheck = new bool[lines.Count, lines[0].Length];
        for (int i = 0; i < lavatubesBassins.GetLength(0); i++) {
            for (int j = 0; j < lavatubesBassins.GetLength(1); j++) {
                lavatubesBassins[i, j] = 0;
            }
        }
        for (int i = 0; i < lavatubesBassins.GetLength(0); i++) {
            for (int j = 0; j < lavatubesBassins.GetLength(1); j++) {
                lavatubesBassinsCheck[i, j] = false;
            }
        }
        for (int i = 0; i < lines.Count; i++) {
            for (int j = 0; j < lines[i].Length; j++) {
                lavatubes[i, j] = int.Parse(lines[i][j].ToString());
            }
        }
        LowestPoints();
        for (int i = 0; i < biggerBassins.Length; i++) {
            biggerBassins[i] = 0;
        }
        for (int i = 0; i < bassins.Count; i++) {
            if (bassins[i] >= biggerBassins[0]) {
                biggerBassins[2] = biggerBassins[1];
                biggerBassins[1] = biggerBassins[0];
                biggerBassins[0] = bassins[i];
            }
            else if (bassins[i] >= biggerBassins[1]) {
                biggerBassins[2] = biggerBassins[1];
                biggerBassins[1] = bassins[i];
            }
            else if (bassins[i] >= biggerBassins[2]) {
                biggerBassins[2] = bassins[i];
            }
        }
        total = biggerBassins[0] * biggerBassins[1] * biggerBassins[2];
    }


    void Update() {

    }

    void LowestPoints() {
        bassins.Add(0);
        for (int i = 0; i < lavatubes.GetLength(0); i++) {
            for (int j = 0; j < lavatubes.GetLength(1); j++) {
                ChangeOtherTubes(i, j);
            }
        }
    }

    void ChangeOtherTubes(int i, int j) {
        if (lavatubesBassinsCheck[i, j] == true) {
            return;
        }
        lavatubesBassinsCheck[i, j] = true;
        if (lavatubes[i, j] == 9) {
            return;
        }
        if (lavatubesBassins[i, j] == 0) {
            newBassins++;
            lavatubesBassins[i, j] = newBassins;
        }
        if (inBounds(i + 1, lavatubes)) {
            lavatubesBassins[i + 1, j] = lavatubesBassins[i + 1, j] == 9 ? 0 : lavatubesBassins[i, j] ;
            ChangeOtherTubes(i + 1, j);
        }
        if (inBounds(i - 1, lavatubes)) {
            lavatubesBassins[i - 1, j] = lavatubesBassins[i - 1, j] == 9 ? 0 : lavatubesBassins[i, j];
            ChangeOtherTubes(i - 1, j);
        }
        if (inBounds(j - 1, lavatubes, 1)) {
            lavatubesBassins[i, j - 1] = lavatubesBassins[i, j - 1] == 9 ? 0 : lavatubesBassins[i, j];
            ChangeOtherTubes(i, j - 1);
        }
        if (inBounds(j + 1, lavatubes, 1)) {
            lavatubesBassins[i, j + 1] = lavatubesBassins[i, j + 1] == 9 ? 0 : lavatubesBassins[i, j];
            ChangeOtherTubes(i, j + 1);
        }
        while (bassins.Count <= lavatubesBassins[i, j]) {
            bassins.Add(0);
        }
        bassins[lavatubesBassins[i, j]]++;
    }
    void FillList(string file_path, ref List<string> list) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            list.Add(inp_stm.ReadLine());
        }
        inp_stm.Close();
    }

    bool inBounds(int index, int[,] array, int whichCount = 0) {
        return (index >= 0) && (index < array.GetLength(whichCount));
    }
}
