using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class ThreePartTwo : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\BinaryDiagnostic.txt";
    public List<string> diagnostic = new List<string>();
    public List<string> airList = new List<string>();
    public List<string> oxygeneList = new List<string>();
    public List<string> carbonList = new List<string>();
    public int lifeSupport = 0;
    public int oxygene = 0;
    public int carbon = 0;
    void Start() {
        FillListText(path);
        Find02();
        FindC02();
        FindLifeSupport();

    }

    void FindLifeSupport() {
        lifeSupport = oxygene * carbon;
    }
    void Find02() {
        oxygeneList.Clear();
        carbonList.Clear();
        airList.Clear();
        airList.AddRange(diagnostic);
        for (int i = 0; i < diagnostic[0].Length; i++) {
            for (int j = 0; j < airList.Count; j++) {
                if (airList[j][i] == '0') {
                    carbonList.Add(airList[j]);
                } else {
                    oxygeneList.Add(airList[j]);
                }
            }
            if (carbonList.Count <= oxygeneList.Count) {
                if (oxygeneList.Count == 1) {
                    oxygene = Convert.ToInt32(oxygeneList[0], 2);
                }
                carbonList.Clear();
                airList.Clear();
                airList.AddRange(oxygeneList);
                oxygeneList.Clear();
            } else {
                if (carbonList.Count == 1) {
                    oxygene = Convert.ToInt32(carbonList[0], 2);
                }
                oxygeneList.Clear();
                airList.Clear();
                airList.AddRange(carbonList);
                carbonList.Clear();
            }
        }
    }



    void FindC02() {
        oxygeneList.Clear();
        carbonList.Clear();
        airList.Clear();
        airList.AddRange(diagnostic);
        for (int i = 0; i < diagnostic[0].Length; i++) {
            for (int j = 0; j < airList.Count; j++) {
                if (airList[j][i] == '0') {
                    carbonList.Add(airList[j]);
                } else {
                    oxygeneList.Add(airList[j]);
                }
            }
            if (carbonList.Count <= oxygeneList.Count) {
                if (carbonList.Count == 1) {
                    carbon = Convert.ToInt32(carbonList[0], 2);
                }
                oxygeneList.Clear();
                airList.Clear();
                airList.AddRange(carbonList);
                carbonList.Clear();
            } else {
                if (oxygeneList.Count == 1) {
                    carbon = Convert.ToInt32(oxygeneList[0], 2);
                }
                carbonList.Clear();
                airList.Clear();
                airList.AddRange(oxygeneList);
                oxygeneList.Clear();
            }
        }
    }


    void FillListText(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);
        while (!inp_stm.EndOfStream) {
            diagnostic.Add(inp_stm.ReadLine());
        }
        inp_stm.Close();
    }

    int Pow(int value, int pow) {
        int result = 1;
        for (int i = 0; i < pow; i++) {
            result *= value;
        }
        return result;
    }

}
