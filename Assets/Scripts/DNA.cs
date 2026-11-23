using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DNA
{
List<int> genes = new List<int>();

 int dnaLength = 0;
 int maxValues = 0;

public DNA(int l, int v)
    {
        dnaLength = l;
        maxValues = v;
        SetRandom();
    }

public void SetRandom()
    {
        genes.Clear();
        for(int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0,maxValues));
        }
    }

    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    public void Crossover(DNA d1,DNA d2)
    {
        //Crossover 50/50
        for(int i=0;i<dnaLength;i++)
        {
            if (i < dnaLength / 2.0)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

        public void Mutation()
    {
        genes[Random.Range(0,dnaLength)] = Random.Range(0,maxValues);
    }


    public int GetGene(int pos)
    {
        return genes[pos];
    }

        



}
