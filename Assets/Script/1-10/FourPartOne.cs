using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;


public class FourPartOne : MonoBehaviour
{
    public struct BingoMatrix {
        public int[] content;
        public List<int> usedNumber;
        public int score;
    };
    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Bingo.txt";
    public List<int> bingoNumbers = new List<int>();
    public List<BingoMatrix> bingoMatrixList = new List<BingoMatrix>();
    // Start is called before the first frame update
    void Start()
    {
        FillList(path);
        Debug.Log(" ====================" + WhoIsTheBestBingo());
        for (int i = 0; i < bingoMatrixList.Count; i++) {
            for (int j = 0; j < bingoMatrixList[i].content.Length; j++) {
                Debug.Log(i + "/" + j + "/" + bingoMatrixList[i].content[j]);
            }
            Debug.Log(i + "/ SCORE: " + bingoMatrixList[i].score);
        }
    }

    void HowMany() {
        bool nextMatrix = false;
        for (int j = 0; j < bingoNumbers.Count; j++) {
            if (nextMatrix) {
                nextMatrix = false;
                break;
            }
            for (int k = 0; k < 25; k++) {
                if (bingoNumbers[j] == bingoMatrixList[0].content[k]) {
                    int column = k % 5 + 25;
                    int line = k / 5 + 30;
                    bingoMatrixList[0].content[column]++;
                    bingoMatrixList[0].content[line]++;
                    if (bingoMatrixList[0].content[column] == 5 || bingoMatrixList[0].content[line] == 5) {
                        bingoMatrixList[0].content[35] = j;
                        nextMatrix = true;
                    }
                    break;
                }
            }

        }
    }
    int WhoIsTheBestBingo() {
        bool nextMatrix = false;
        int bestMatrix = 0;
        int bestMatrixValue = 100;
        for (int i = 0; i < bingoMatrixList.Count; i++) {
            for (int j = 0; j < bingoNumbers.Count; j++) {
                if (nextMatrix) {
                    nextMatrix = false;
                    break;
                }
                for (int k = 0; k < 25; k++) {
                    if (bingoNumbers[j] == bingoMatrixList[i].content[k]) {
                        bingoMatrixList[i].usedNumber.Add(bingoNumbers[j]);
                        int column = k % 5 + 25;
                        int line = k / 5 + 30;
                        bingoMatrixList[i].content[column]++;
                        bingoMatrixList[i].content[line]++;
                        if (bingoMatrixList[i].content[column] == 5 || bingoMatrixList[i].content[line] == 5) {
                            bingoMatrixList[i].content[35] = j + 1;
                            nextMatrix = true;
                        }
                        break;
                    }
                }

            }
            int totalNumberKeep = 0;
            for (int l = 0; l < bingoMatrixList[i].usedNumber.Count; l++) {
                totalNumberKeep -= bingoMatrixList[i].usedNumber[l];
            }
            for (int m = 0; m < 25; m++) {
                totalNumberKeep += bingoMatrixList[i].content[m];
            }
            BingoMatrix cucurrentMatrix = bingoMatrixList[i];
            cucurrentMatrix.score = totalNumberKeep * bingoNumbers[cucurrentMatrix.content[35] - 1] ;
            bingoMatrixList[i] = cucurrentMatrix;
        }
        for (int i = 0; i < bingoMatrixList.Count; i++) {
            if (bingoMatrixList[i].content[35] < bestMatrixValue) {
                bestMatrixValue = bingoMatrixList[i].content[35];
                bestMatrix = i;
            }
        }
        return bestMatrix + bestMatrixValue * 1000;
    }
    void FillList(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);

        bingoNumbers = inp_stm.ReadLine().Split(',').Select(i => int.Parse(i)).ToList();
        while (!inp_stm.EndOfStream) {
            inp_stm.ReadLine();
            BingoMatrix currentBingoMatrix;
            currentBingoMatrix.usedNumber = new List<int>();
            currentBingoMatrix.score = 0;
            List<int> currentList = new List<int>();
            int k = 0;
            currentBingoMatrix.content = new int[36];
            for (int i = 0; i < 5; i++) {
                currentList.AddRange(inp_stm.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(j => int.Parse(j))
                    .ToList());
            }
            for (int i = 0; i < currentList.Count; i++) {
                currentBingoMatrix.content[k] = currentList[k];
                k++;
            }
            bingoMatrixList.Add(currentBingoMatrix);
        }
        inp_stm.Close();
    }
}
