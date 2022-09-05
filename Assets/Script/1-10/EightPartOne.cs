using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class EightPartOne : MonoBehaviour {

    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\DigitsOutput.txt";
    public List<string> digits = new List<string>();
    public int total = 0;
    void Start()
    {
        Total(path, ref digits);
        for (int i = 0; i < digits.Count; i++) {
            if (digits[i].Length == 3 || digits[i].Length == 2 || digits[i].Length == 4 || digits[i].Length == 7 ) {
                total++;
            }
        }
    }
    void Total(string file_path,ref List<string> list) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            list.AddRange(inp_stm.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.None)
                .ToList());
        }
        inp_stm.Close();
    }
}
