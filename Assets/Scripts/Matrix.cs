using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    //matrix (rows and columns) through list 
    public int numOfRows;
    public int numOfColumns;
    List<List<int>> matrix;
    

    //initialize list matrix
    void InitializeMatrix()
    {
        matrix = new List<List<int>>();
    }

    public Matrix()
    {
        InitializeMatrix();
    }
    
    //no. of rows and columns of matrix
    public Matrix(int NumOfRows, int NumOfCols)
    {
        numOfRows = NumOfRows;
        numOfColumns = NumOfCols;
        InitializeMatrix();
        for (int i = 0; i < numOfRows; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < numOfColumns; j++)
            {
                matrix[i].Add(0);
            }
        }
    }

    //array of matrix
    public Matrix(int[,] array)
    {
        SetMatrix(array);
    }

    public void SetMatrix(int[,] array)
    {
        InitializeMatrix();
        numOfRows = array.GetLength(0);
        numOfColumns = array.GetLength(1);
        for (int i = 0; i < numOfRows; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < numOfColumns; j++)
            {
                matrix[i].Add(array[i, j]);
            }
        }
    }
    
    //printing the matrix 
    public void PrintMatrix()
    {
        string displayMatrix = "";
        for (int i = 0; i < numOfRows; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < numOfColumns; j++)
            {
                displayMatrix += matrix[i][j] + "   ";

            }
            displayMatrix += '\n';

        }
        Debug.Log(displayMatrix);
        Debug.Log("HelloJe");
    }
    
    // set the element of the array matrix
    public void SetElement(int r, int c, int v)
    {
        if (r < numOfRows && c < numOfColumns)
        {
            matrix[r][c] = v;
        }
        else
        {
            Debug.Log("Matrix is Smaller");
        }
    }

    // element get of array matrix
    public int GetElement(int r, int c)
    {
        if (r < numOfRows && c < numOfColumns)
        {
            return matrix[r][c];
        }
        else
        {
            Debug.Log("Matrix size is smaller");
            return 0;
        }
    }

    public void SetAllElements(int number)
    {
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfColumns; j++)
            {
                matrix[i][j] = number;
            }
        }
    }

    //checking the column condition 
    public bool IsColumnSame(int c)
    {
        bool issame = false;
        if (c < numOfRows)
        {
            int a = matrix[0][c];
            if (a != 0)
            {
                for (int i = 0; i < numOfColumns; i++)
                {
                    if (a == matrix[i][c])
                    {
                        issame = true;
                    }
                    else
                    {
                        issame = false;
                        break;
                    }
                }
            }
        }
        return issame;
    }
    
    //checking the row condition
    public bool IsRowSame(int r)
    {
        bool issame = false;
        if (r < numOfRows)
        {

            int a = matrix[r][0];
            if (a != 0)
            {
                for (int i = 0; i < numOfColumns; i++)
                {
                    if (a == matrix[r][i])
                    {
                        issame = true;
                    }
                    else
                    {
                        issame = false;
                        break;
                    }
                }
            }
        }
        return issame;
    }
}

