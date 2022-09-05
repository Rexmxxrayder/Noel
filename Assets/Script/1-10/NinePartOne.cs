using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class NinePartOne : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\LavaTubes.txt";
    public List<string> lines = new List<string>();
    public int[,] lavatubes;
    public int total = 0;
    public int totalLowestPoint = 0;
    void Start()
    {
        FillList(path, ref lines);
        lavatubes = new int[lines.Count, lines[0].Length];
        for (int i = 0; i < lines.Count; i++) {
            for (int j = 0; j < lines[i].Length; j++) {
                lavatubes[i, j] = int.Parse(lines[i][j].ToString());
            }
        }
        LowestPoints();
    }

    
    void Update()
    {
        
    }

    void LowestPoints() {
        for (int i = 0; i < lavatubes.GetLength(0); i++) {
            for (int j = 0; j < lavatubes.GetLength(1); j++) {
                int currentTubes = lavatubes[i, j];
                bool isLittle = true;
                if (inBounds(i + 1, lavatubes) && lavatubes[i + 1, j] <= currentTubes) {
                    isLittle = false;
                }
                if (inBounds(i - 1, lavatubes) && lavatubes[i - 1, j] <= currentTubes) {
                    isLittle = false;
                }
                if (inBounds(j - 1, lavatubes, 1) && lavatubes[i, j - 1] <= currentTubes) {
                    isLittle = false;
                }
                if (inBounds(j + 1, lavatubes, 1) && lavatubes[i, j + 1] <= currentTubes) {
                    isLittle = false;
                }
                if (isLittle) {
                    Debug.Log("I = " + i + " J = " + j + " LW = " + currentTubes);
                    total += 1 + currentTubes;
                    totalLowestPoint += 1;
                }
            }
        }
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
