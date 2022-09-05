using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class EightPartTwo : MonoBehaviour {

    string path = "D:\\Vortex\\Orque\\Mames\\Devoir\\V4\\Noel\\Assets\\Texte\\Digits.txt";
    public List<string> digits = new List<string>();
    public List<int> digitsOutput = new List<int>();
    public List<int> allDigits = new List<int>();
    public List<char> wiredii = new List<char>();
    char[] wires = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
    char[] intoWires = { '0', '0', '0', '0', '0', '0', '0' };
    public int total = 0;
    public string[] unknownDigits = new string[14];
    public string[] unknownDigitsOrdered = new string[14];
    public char[] digitsOrdered = new char[14];
    int subTotal = 0;
    int charInWires = 0;
    void Start() {
        FillList(path, ref digits);
        FindTotal();
    }

    void FindTotal() {

        for (int i = 0; i < digits.Count /14; i++) {
            #region Clear
            for (int j = 0; j < unknownDigitsOrdered.Length; j++) {
                unknownDigitsOrdered[j] = "h";
                unknownDigits[j] = "h";
            }
            for (int j = 0; j < digitsOrdered.Length; j++) {
                digitsOrdered[j] = 'h';
            }
            for (int j = 0; j < intoWires.Length; j++) {
                intoWires[j] = '0';
            }
            #endregion
            #region StoreUnknownDigits
            for (int k = 0; k < 14; k++) {
                string currentdigit = digits[i * 14 + k];
                unknownDigits[k] = currentdigit;
                if (k < 10) {
                    switch (currentdigit.Length) {
                        case 2:
                            unknownDigitsOrdered[0] = currentdigit;
                            break;
                        case 3:
                            unknownDigitsOrdered[1] = currentdigit;
                            break;
                        case 4:
                            unknownDigitsOrdered[2] = currentdigit;
                            break;
                        case 5:
                            if (unknownDigitsOrdered[3] == "h") {
                                unknownDigitsOrdered[3] = currentdigit;
                            } else if (unknownDigitsOrdered[4] == "h") {
                                unknownDigitsOrdered[4] = currentdigit;
                            } else {
                                unknownDigitsOrdered[5] = currentdigit;
                            }
                            break;
                        case 6:
                            if (unknownDigitsOrdered[6] == "h") {
                                unknownDigitsOrdered[6] = currentdigit;
                            } else if (unknownDigitsOrdered[7] == "h") {
                                unknownDigitsOrdered[7] = currentdigit;
                            } else {
                                unknownDigitsOrdered[8] = currentdigit;
                            }
                            break;
                        case 7:
                            unknownDigitsOrdered[9] = currentdigit;
                            break;
                    }
                } else {
                    unknownDigitsOrdered[k] = currentdigit;
                }
            }
            #endregion
            #region Find("1","4","7","8")Digits
            for (int j = 0; j < 10; j++) {
                switch (unknownDigitsOrdered[j].Length) {
                    case 2:
                        digitsOrdered[j] = '1';
                        break;
                    case 3:
                        digitsOrdered[j] = '7';
                        break;
                    case 4:
                        digitsOrdered[j] = '4';
                        break;
                    case 7:
                        digitsOrdered[j] = '8';
                        break;
                }
            }
            #endregion
            #region FindWire1
            for (int j = 0; j < N('7').Length; j++) {
                char currentChar = N('7')[j];
                if (N('1').IndexOf(currentChar) == -1) {
                    charInWires = Array.FindIndex(wires, v => v.Equals('a'));
                    intoWires[charInWires] = currentChar;
                }
            }
            #endregion
            #region FindWire2/Wire4/Digit"0"
            char[] Wire2And4 = {'0', '0'};
            for (int j = 0; j < N('4').Length; j++) {
                char currentChar = N('4')[j];
                if (N('1').IndexOf(currentChar) == -1) {
                    if (Wire2And4[0] == '0') {
                        Wire2And4[0] = currentChar;
                    } else {
                        Wire2And4[1] = currentChar;
                    }
                }
            }
            for (int j = 0; j < 3; j++) {
                if (unknownDigitsOrdered[6 + j].IndexOf(Wire2And4[0]) == -1) {
                    charInWires = Array.FindIndex(wires, v => v.Equals('d'));
                    intoWires[charInWires] = Wire2And4[0];
                    int charInWiresTwo = Array.FindIndex(wires, v => v.Equals('b'));
                    intoWires[charInWiresTwo] = Wire2And4[1];
                    digitsOrdered[6 + j] = '0';
                } else if (unknownDigitsOrdered[6 + j].IndexOf(Wire2And4[1]) == -1) {
                    charInWires = Array.FindIndex(wires, v => v.Equals('d'));
                    intoWires[charInWires] = Wire2And4[1];
                    int charInWiresTwo = Array.FindIndex(wires, v => v.Equals('b'));
                    intoWires[charInWiresTwo] = Wire2And4[0];
                    digitsOrdered[6 + j] = '0';
                }
            }

            #endregion
            #region FindWire3/Wire6/Digit"6"/Digit"9"
            for (int j = 0; j < 3; j++) {
                if (unknownDigitsOrdered[6 + j] == N('0')) {
                    continue;
                }
                if (unknownDigitsOrdered[6 + j].IndexOf(N('1')[1]) != -1 && unknownDigitsOrdered[6 + j].IndexOf(N('1')[0]) != -1) {
                    digitsOrdered[6 + j] = '9';
                } else {
                    digitsOrdered[6 + j] = '6';
                    if (unknownDigitsOrdered[6 + j].IndexOf(N('1')[1]) == -1) {
                        charInWires = Array.FindIndex(wires, v => v.Equals('c'));
                        intoWires[charInWires] = N('1')[1];
                        int charInWiresTwo = Array.FindIndex(wires, v => v.Equals('f'));
                        intoWires[charInWiresTwo] = N('1')[0];
                    } else {
                        charInWires = Array.FindIndex(wires, v => v.Equals('c'));
                        intoWires[charInWires] = N('1')[0];
                        int charInWiresTwo = Array.FindIndex(wires, v => v.Equals('f'));
                        intoWires[charInWiresTwo] = N('1')[1];
                    }
                }
            }
            #endregion
            #region FindWire7/Wire5
            for (int j = 0; j < 6; j++) {
                if (N('4').IndexOf(N('9')[j]) == -1 && N('9')[j] != intoWires[Array.FindIndex(wires, v => v.Equals('a'))]) {
                    charInWires = Array.FindIndex(wires, v => v.Equals('g'));
                    intoWires[charInWires] = N('9')[j];
                }
            }
            for (int j = 0; j < 7; j++) {
                if (N('9').IndexOf(N('8')[j]) == -1) {
                    charInWires = Array.FindIndex(wires, v => v.Equals('e'));
                    intoWires[charInWires] = N('8')[j];
                }
            }
            #endregion
            #region Visualise
            for (int j = 0; j < 4; j++) {
                subTotal += WhichDigit(unknownDigitsOrdered[10 + j]) * Pow(10, 3 - j);
            }
            for (int j = 0; j < intoWires.Length; j++) {
                wiredii.Add(intoWires[j]);
            }
            for (int j = 0; j < unknownDigitsOrdered.Length; j++) {
                allDigits.Add(WhichDigit(unknownDigits[j]));
            }
            #endregion
            #region Total
            digitsOutput.Add(subTotal);
            total += subTotal;
            subTotal = 0;
            #endregion
        }
    }
    void FillList(string file_path, ref List<string> list) {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream) {
            list.AddRange(inp_stm.ReadLine()
                .Split(new string[] { "|", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList());
        }
        inp_stm.Close();
    }

    string N(char digit) { 
        return unknownDigitsOrdered[Array.FindIndex(digitsOrdered, v => v.Equals(digit))];
    }

    int WhichDigit(string digit) {
        int whichdigit = 0;
        for (int i = 0; i < digit.Length; i++) {
            whichdigit += Pow(10, Array.FindIndex(intoWires, v => v.Equals(digit[i])));
        }
        switch (whichdigit) {
            case 1110111:
                return 0;
            case 100100:
                return 1;
            case 1011101:
                return 2;
            case 1101101:
                return 3;
            case 101110:
                return 4;
            case 1101011:
                return 5;
            case 1111011:
                return 6;
            case 0100101:
                return 7;
            case 1111111:
                return 8;
            case 1101111:
                return 9;
            default:
                return 27;
        }
    }

    int Pow(int value, int pow) {
        int result = 1;
        for (int i = 0; i < pow; i++) {
            result *= value;
        }
        return result;
    }
}
