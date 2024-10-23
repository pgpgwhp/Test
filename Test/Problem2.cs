using System;
using System.Collections.Generic;

public class EnergyFieldSystem
{
    public static float MaxEnergyField(int[] heights)
    {
        float maxArea = 0;
        int n = heights.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int height = Math.Abs(j - i);
                float area = ((heights[i] + heights[j]) * height) / 2;
                maxArea = Math.Max(maxArea, area);
            }
        }
        return maxArea;
    }
    
    // 如果增加某一个塔的高度，遍历一边所有和该塔相关的高度即可
    public static float UpdateMaxEnergyField(int[] heights, float maxArea, int index)
    {
        for (int i = 0; i < heights.Length; i++)
        {
            int height = Math.Abs(index - i);
            if (((heights[i] + heights[index]) * height) / 2 > maxArea)
                maxArea = ((heights[i] + heights[index]) * height) / 2;
        }

        return maxArea;
    }
}
// 单元测试
public class EnergyFieldSystemTests
{
    public void TestMaxEnergyField()
    {
        
        int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        float maxArea = EnergyFieldSystem.MaxEnergyField(heights);
        Console.WriteLine("最大梯形面积: " + maxArea);

        heights[3] = 100;
        maxArea = EnergyFieldSystem.UpdateMaxEnergyField(heights, maxArea, 3);
        Console.WriteLine("最大梯形面积: " + maxArea);
        
        //高度为0，加入一个限制即可

// 在这⾥编写测试⽤例
    }
}