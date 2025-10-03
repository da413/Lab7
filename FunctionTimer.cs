using System.Diagnostics;
using UnityEngine;
using System.IO;
using System.Collections;
using TMPro;
using System;

public class FunctionTimer : MonoBehaviour
{
    public DLLSortScript instance;

 
    public int[] numArray;
    string[] line;
    int num;
    void Start()
    {
        numArray = new int[10000]; //array of integers
        line = new string[10000];
        StartCoroutine(ConvertFiletoArray()); //converts text file into integers in array
        MeasureFunctionExecutionTime();
    }

    void MeasureFunctionExecutionTime()
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start(); // Start timing
        MyFunctionToTest(); // Call the function you want to measure
        stopwatch.Stop();  // Stop timing

        // Get the elapsed time
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log($"MyFunctionToTest took {elapsedMilliseconds} ms to execute.");
    }

    void MyFunctionToTest()
    {
        DLLSortScript.TestSort(numArray, numArray.Length); //Make sure you have the code that imports your native DLL and populates the array somewhere
    }

    IEnumerator ConvertFiletoArray()
    {
        try
        {
            StreamReader sr = new StreamReader("Assets/ArrayTest1.txt");
           

            for (int i = 0; i < 10000; i++)
            {


                line[i] = sr.ReadLine();
                

                //UnityEngine.Debug.Log(line[0]);

                if (int.TryParse(line[i], out int parsedValue))
                {
                    numArray[i] = parsedValue;
                }
            }

            sr.Close();
        }
        catch (FileNotFoundException e)
        {
            UnityEngine.Debug.Log(e.Message);
        }
       
       
        yield return null;
    }
}