using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;


public class SixPartOne : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\LanternFish.txt";
    public long[] lanternFish = new long[9];
    public long total = 0;
    // Start is called before the first frame update
    void Start() {
        FillList(path);
        TotalLanternFish(256);
    }

    void FillList(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            List<long> firstLanternFish;
            firstLanternFish = inp_stm.ReadLine()
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(j => long.Parse(j))
                .ToList();
            for (int i = 0; i < firstLanternFish.Count; i++) {
                lanternFish[firstLanternFish[i]]++;
            }
        }

    }

    void TotalLanternFish(long days) {
        for (long i = 0; i < days; i++) {
            long[] slotArray = new long[9];
            for (long j = 8; j > -1; j--) {
                if (j == 0) {
                    slotArray[6] += lanternFish[j];
                    slotArray[8] += lanternFish[j];
                } else {
                    slotArray[j - 1] += lanternFish[j];
                }
            }
            lanternFish = slotArray;
            long currentday = 0;
            for (long l = 0; l < lanternFish.Length; l++) {
                currentday += lanternFish[l];
            }
            Debug.Log("Jour " + i + " : " + currentday);
        }
        for (long i = 0; i < lanternFish.Length; i++) {
            total += lanternFish[i];
        }
    }
}

