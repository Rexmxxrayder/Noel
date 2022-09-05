using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TenPartTwo : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Chunks.txt";
    [SerializeField] List<string> lines = new List<string>();
    [SerializeField] string[] synthax = new string[9] { "a", "(", "[", "{", "<", ">", "}", "]", ")", };
    [SerializeField] Stack<int> synthaxStacks = new Stack<int>();
    [SerializeField] List<int> synthaxList = new List<int>();
    [SerializeField] List<long> totals = new List<long>();
    [SerializeField] long middleTotal = 0;
    [SerializeField] long total = 0;
    [SerializeField] bool corrupt = false;

    private void Start() {
        FillList(path, ref lines);
        CorruptLineResearch();
    }

    void CorruptLineResearch() {
        for (int i = 0; i < lines.Count; i++) {
            total = 0;
            corrupt = false;
            synthaxList.Clear();
            synthaxStacks.Clear();
            for (int j = 0; j < lines[i].Length; j++) {
                int currentSynthax = Array.IndexOf(synthax, Char.ToString(lines[i][j]));
                if (currentSynthax < 5) {
                    synthaxStacks.Push(currentSynthax);
                    synthaxList.Add(currentSynthax);
                } else {
                    if (synthaxStacks.Peek() + currentSynthax == 9) {
                        synthaxStacks.Pop();
                        synthaxList.RemoveAt(synthaxList.Count - 1);
                    } else {
                        corrupt = true;
                        break;
                    }
                }
            }
            if (corrupt) {
                continue;
            }
            while (synthaxStacks.Count != 0) {
                total *= 5;
                total += synthaxStacks.Pop();
                synthaxList.RemoveAt(synthaxList.Count - 1);
            }
            totals.Add(total);
        }
        totals.Sort((long a, long b) => a < b ? -1 : 1);
        middleTotal = totals[totals.Count / 2];
    }
    void FillList(string file_path, ref List<string> list) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            list.Add(inp_stm.ReadLine());
        }
        inp_stm.Close();
    }
}
