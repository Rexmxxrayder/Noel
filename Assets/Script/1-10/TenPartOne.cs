using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TenPartOne : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Chunks.txt";
    [SerializeField] List<string> lines = new List<string>();
    [SerializeField] string[] synthax = new string[9] { "a", "{", "[", "<", "(", ")", ">", "]", "}" };
    [SerializeField] int[] synthaxScore = new int[5] { 0, 1197, 57, 25137, 3};
    [SerializeField] Stack<int> synthaxStacks = new Stack<int>();
    [SerializeField] int total = 0;

    private void Start() {
        FillList(path, ref lines);
        CorruptLineResearch();
    }

    void CorruptLineResearch() {
        for (int i = 0; i < lines.Count; i++) {
            synthaxStacks.Clear();
            for (int j = 0; j < lines[i].Length; j++) {
                int currentSynthax = Array.IndexOf(synthax, Char.ToString(lines[i][j])); //1
                if (currentSynthax < 5) {
                    synthaxStacks.Push(currentSynthax); 
                } else {
                    if (synthaxStacks.Peek() + currentSynthax == 9) {
                        synthaxStacks.Pop();
                    } else {
                        int index = 9 - Array.IndexOf(synthax, Char.ToString(lines[i][j]));
                        int score = synthaxScore[index];
                        total += score;
                        break;
                    }
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
}
