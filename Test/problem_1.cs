using System;
using System.Collections.Generic;

public class Heap
{
    private List<int> heap;
    public int Count => heap.Count;
    
    public Heap()
    {
        heap = new List<int>();
    }
    
    public void Insert(int value)
    {
        heap.Add(value);
        BubbleUp(heap.Count - 1);
    }
    
    // 删除并返回最小值
    public int ExtractMin()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        int maxValue = heap[0];
        // 用最后一个元素替换堆顶
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        BubbleDown(0);
        return maxValue;
    }
    
    public int Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        return heap[0];
    }

    // 向上调整堆
    private void BubbleUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index] > heap[parentIndex])
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    // 向下调整堆
    private void BubbleDown(int index)
    {
        int largest = index;

        while (true)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < heap.Count && heap[leftChild] > heap[largest])
            {
                largest = leftChild;
            }

            if (rightChild < heap.Count && heap[rightChild] > heap[largest])
            {
                largest = rightChild;
            }

            if (largest == index)
            {
                break;
            }

            Swap(index, largest);
            index = largest;
        }
    }

    // 交换两个元素
    private void Swap(int index1, int index2)
    {
        int temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}


public class LeaderboardSystem
{
    
    public static List<int> GetTopScores(int[] scores, int m)
    {
        if (scores.Length <= m)
        {
            return new List<int>(scores);
        }

        if (scores.Length == 0)
        {
            return new List<int>(scores);
        }
        
        Heap heap = new Heap();
        foreach (var score in scores)
        {
            heap.Insert(score);
        }
        
        List<int> maxNumbers = new List<int>();
        for (int i = 0; i < m; i++)
        {
            maxNumbers.Add(heap.ExtractMin());
        }
        
        return new List<int>(maxNumbers);

// 在这⾥实现你的代码
    }
}
// 单元测试
public class LeaderboardSystemTests
{

    public void TestGetTopScores()
    {   
        // 正常情况
        int[] numbers = { 2, 20, 3, 208, 883, 771, 972 };
        int target = 3;

        List<int> l = LeaderboardSystem.GetTopScores(numbers, target);
        Console.WriteLine(string.Join(" , ", l));
        
        // 边界测试
       numbers = new []{ 3 };
       target = 5; 
       l = LeaderboardSystem.GetTopScores(numbers, target);
       Console.WriteLine(string.Join(" , ", l));

       numbers = new int[0];
       target = 0; 
       l = LeaderboardSystem.GetTopScores(numbers, target);
       Console.WriteLine(string.Join(" , ", l));
       
       //

       
       // 在这⾥编写测试⽤例
    }
}