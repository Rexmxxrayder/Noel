using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;


public class FivePartOne : MonoBehaviour {
    public struct Line {
        public Vector2Int pointOne;
        public Vector2Int pointTwo;
    };
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Vents.txt";
    public int[,] map = new int[1000, 1000];
    public List<Line> lines = new List<Line>();
    public int total = 0;
    void Start() {
        FillList(path);
        for (int i = 0; i < lines.Count; i++) {
            Debug.Log(i + "/" + lines[i].pointOne + "/" + lines[i].pointTwo);
        }
        FillVents();
    }

    void FillVents() {
        for (int i = 0; i < lines.Count; i++) {
            int start = 0;
            int end = 0;
            bool isX = true;
            if (lines[i].pointOne.x == lines[i].pointTwo.x ^ lines[i].pointOne.y == lines[i].pointTwo.y) {
                if (lines[i].pointOne.x == lines[i].pointTwo.x) {
                    isX = false;
                    if (lines[i].pointOne.y < lines[i].pointTwo.y) {
                        start = lines[i].pointOne.y;
                        end = lines[i].pointTwo.y;
                    } else {
                        start = lines[i].pointTwo.y;
                        end = lines[i].pointOne.y;
                    }
                } else {
                    isX = true;
                    if (lines[i].pointOne.x < lines[i].pointTwo.x) {
                        start = lines[i].pointOne.x;
                        end = lines[i].pointTwo.x;
                    } else {
                        start = lines[i].pointTwo.x;
                        end = lines[i].pointOne.x;
                    }
                }

                for (int j = start; j < end + 1; j++) {
                    if (isX) {
                        map[j, lines[i].pointOne.y]++;
                        if (map[j, lines[i].pointOne.y] == 2) {
                            total++;
                        }
                    } else {
                        map[lines[i].pointOne.x, j]++;
                        if (map[lines[i].pointOne.x, j] == 2) {
                            total++;
                        }
                    }
                }

            }

        }
    }
    void FillList(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            int[] coords = new int[4];
            Line currentLine;
            coords = inp_stm.ReadLine()
                    .Split(new string[] { "->", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(j => int.Parse(j))
                    .ToArray();
            currentLine.pointOne = new Vector2Int(coords[0], coords[1]);
            currentLine.pointTwo = new Vector2Int(coords[2], coords[3]);
            lines.Add(currentLine);
        }
        inp_stm.Close();
    }
}
