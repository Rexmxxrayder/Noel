using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ElevenPartOne : MonoBehaviour {
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Octopus.txt";
    [SerializeField] int[,] octopus = new int[10,10];
    [SerializeField] Stack<Vector2Int> toIncretement = new Stack<Vector2Int>();
    [SerializeField] Stack<Vector2Int> toReset = new Stack<Vector2Int>();
    [SerializeField] int totalFlash = 0;
    [SerializeField] int step = 0;
    
    void Start() {
        FillList(path);
        LightStep(step);
    }

    void LightStep(int step) {
        for (int i = 0; i < step; i++) {
            FillStack();
            while (toIncretement.Count > 0) { 
                AddPoint(toIncretement.Pop());
            }
            while (toReset.Count > 0) {
                ResetOctopus(toReset.Pop());
            }
        }
    }
    void Flash(Vector2Int flasher) {
        totalFlash++;
        AddPoint(new Vector2Int(flasher.x + 1, flasher.y));
        AddPoint(new Vector2Int(flasher.x - 1, flasher.y));
        AddPoint(new Vector2Int(flasher.x, flasher.y + 1));
        AddPoint(new Vector2Int(flasher.x, flasher.y - 1));
        AddPoint(new Vector2Int(flasher.x + 1, flasher.y - 1));
        AddPoint(new Vector2Int(flasher.x + 1, flasher.y + 1));
        AddPoint(new Vector2Int(flasher.x - 1, flasher.y - 1));
        AddPoint(new Vector2Int(flasher.x - 1, flasher.y + 1));
    }

    void FillStack() {
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                AddToIncrement(new Vector2Int(i, j));
            }
        }
    }

    void AddToIncrement(Vector2Int addToStack) {
        toIncretement.Push(addToStack);
    }

    void AddToReset(Vector2Int addToStack) {
        toReset.Push(addToStack);
    }

    void AddPoint(Vector2Int winner) {
        if(winner.x >= 0 && winner.x < 10 && winner.y >= 0 && winner.y < 10) {
            octopus[winner.x, winner.y]++;
            if (octopus[winner.x, winner.y] == 10) {
                Flash(winner);
                AddToReset(winner);
            }
        }
    }

    private void ResetOctopus(Vector2Int theReset) {
        octopus[theReset.x, theReset.y] = 0;
    }

    // Update is called once per frame
    void FillList(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);
        int inpNumber = 0;
        while (!inp_stm.EndOfStream) {
            string line = inp_stm.ReadLine();
            for (int i = 0; i < line.Length; i++) {
                octopus[inpNumber,i] = int.Parse(line[i].ToString());
            }
            inpNumber++;
        }
        inp_stm.Close();
    }
}
