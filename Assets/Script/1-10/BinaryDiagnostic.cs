using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class BinaryDiagnostic : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\BinaryDiagnostic.txt";
    public List<string> diagnostic = new List<string>();
    public int[] result;
    public int total = 0;
    public int gamma = 0;
    public int epsilon = 0;
    void Start() {
        FillListText(path);
        result = new int[diagnostic[0].Length];
        for (int i = 0; i < diagnostic.Count; i++) {
            for (int j = 0; j < diagnostic[i].Length; j++) {
                if (diagnostic[i][j].Equals('1')) {
                    result[j]++;
                } else {
                    result[j]--;
                }
            }
        }

        for (int i = 0; i < result.Length; i++) {
            if (result[i] <= 0) {
                epsilon += Pow(2, result.Length - 1 - i);
            } else {
                gamma += Pow(2, result.Length - 1 - i);
            }
        }
        total = epsilon * gamma;

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
