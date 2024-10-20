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
}
// 单元测试
public class EnergyFieldSystemTests
{
    public void TestMaxEnergyField()
    {
        
        int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        double maxArea = EnergyFieldSystem.MaxEnergyField(heights);
        Console.WriteLine("最大梯形面积: " + maxArea);
// 在这⾥编写测试⽤例
    }
}