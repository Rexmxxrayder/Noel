using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Seven : MonoBehaviour {

    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Crabs.txt";
    string patha = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Crabsa.txt";
    public List<int> crabs = new List<int>();
    public List<int> crabsa = new List<int>();
    public long finalFuel = 0;
    public int good = 0;
    void Start()
    {
        FillList(path, ref crabs);
        FillList(patha, ref crabsa);
        BrutForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BrutForce() {
        for (int i = 0; i < 2000; i++) {
            int subTotal = 0;
            long total = 0;
            int howMany = 0;
            for (int j = 0; j < crabs.Count; j++) {
                subTotal = 0;
                howMany = Mathf.Abs(crabs[j] - i);
                for (int k = 0; k < howMany; k++) {
                    subTotal += k + 1;
                }
                total += subTotal;
            }
            if (total < finalFuel) {
                finalFuel = total;
                good = i;
            }
        }
       
    }
    void FillList(string file_path,ref List<int> list) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            list = inp_stm.ReadLine()
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(j => int.Parse(j))
                .ToList();
        }
    }
}
