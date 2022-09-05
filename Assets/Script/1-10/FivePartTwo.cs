using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;


public class FivePartTwo : MonoBehaviour {
    public struct Line {
        public Vector2Int pointOne;
        public Vector2Int pointTwo;
    };
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Vents.txt";
    public int[,] map = new int[1000, 1000];
    public List<Line> lines = new List<Line>();
    public int total = 0;
    public GameObject Square;
    void Start() {
        FillList(path);
        for (int i = 0; i < lines.Count; i++) {
            Debug.Log(i + "/" + lines[i].pointOne + "/" + lines[i].pointTwo);
        }

        FillVents();

    }

    void FillVents() {
        for (int i = 0; i < lines.Count; i++) {
            int startX = lines[i].pointOne.x;
            int endX = lines[i].pointTwo.x;
            int startY = lines[i].pointOne.y;
            int endY = lines[i].pointTwo.y;
            int firstXHigher = lines[i].pointOne.x - lines[i].pointTwo.x ;
            int firstYHigher = lines[i].pointOne.y - lines[i].pointTwo.y ;
            float end = 0;
            int xLength = Mathf.Abs(lines[i].pointOne.x - lines[i].pointTwo.x);
            int yLength = Mathf.Abs(lines[i].pointOne.y - lines[i].pointTwo.y);
            if (xLength == 0 || yLength == 0 || xLength == yLength) {
                if (xLength == 0) {
                    end = yLength;
                } else {
                    end = xLength;
                }
                for (int j = 0; j < end + 1; j++) {
                    int x = firstXHigher < 0 ? startX + j : firstXHigher == 0 ? startX : startX - j;
                    int y = firstYHigher < 0 ? startY + j : firstYHigher == 0 ? startY : startY - j;
                    Debug.Log("//////" + x + " / " + y + " / " + startX + " / " + endX + " / " + startY + " / " + endY + " / " + j + " / " + end);
                    map[x, y]++;
                    GameObject gameObject = Instantiate(Square);
                    gameObject.transform.position = new Vector3(x, map[x, y], y);
                    if (map[x, y] == 2) {
                        total++;
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
