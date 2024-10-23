using System;
using System.Collections.Generic;

public class TreasureHuntSystem
{
    public static int MaxTreasureValue(int[] treasures)
    {
        int len = treasures.Length;
        List<int> dp_0 = new List<int>(len);
        List<int> dp_1 = new List<int>(len);

        dp_0[0] = treasures[0]; dp_1[0] = 0;
        dp_0[1] = Math.Max(treasures[1], dp_0[0]);
        dp_1[1] = treasures[0];

        for (int i = 2; i < len; i++)
        {
            dp_0[i] = Math.Max(dp_0[i - 2], dp_1[i - 2] ) + treasures[i];
            dp_1[i] = Math.Max(dp_1[i - 1], dp_0[i - 1]); 
        }

        return Math.Max(dp_0[len - 1], dp_1[len - 1]);
// 在这⾥实现你的代码
    }
}
// 单元测试

public class TreasureHuntSystemTests
{
    public void TestMaxTreasureValue()
    {   
        // dp可以计算负值
        int[] treasures = { 3, 1, 5, 2 , 4};
        Console.WriteLine(TreasureHuntSystem.MaxTreasureValue(treasures)); 
// 在这⾥编写测试⽤例
    }
}