using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class CountDepthPlusAim : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Depth.txt";
    public List<string> DepthList = new List<string>();
    public int aim = 0;
    public int dist = 0;
    public int total = 0;
    public int depth = 0;
    void Start() {
        FillListText(path);
        for (int i = 0; i < DepthList.Count; i++) {
            string typeAction = Regex.Replace(DepthList[i].Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            int number = int.Parse(Regex.Replace(DepthList[i].Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
            switch (typeAction) {
                case "forward":
                    dist += number;
                    depth += aim * number;
                    break;
                case "up":
                    aim -= number;
                    break;
                case "down":
                    aim += number;
                    break;
                default:
                    break;
            }
        }
        total = dist * depth;
    }

    void FillListText(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);
        while (!inp_stm.EndOfStream) {
            DepthList.Add(inp_stm.ReadLine());
        }
        inp_stm.Close();
    }
}
