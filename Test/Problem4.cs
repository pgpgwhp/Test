using System;
public class TalentAssessmentSystem
{
    public static int find(int[] l1, int[] l2, int k)
    {
        int l = 0, r = 0;
        while (true)
        {
            if (l == l1.Length)
            {
                return l2[r + k - 1];
            } else if (l == l2.Length)
            {
                return l1[l + k - 1];
            } else if (k == 1)
            {
                return Math.Min(l1[l], l2[r]);
            }
            else
            {
                int index1 = l + k / 2 - 1;
                int index2 = l + k / 2 - 1;
                if (index1 > l1.Length - 1)
                {
                    index1 = l1.Length - 1;
                }

                if (index2 > l2.Length - 1)
                {
                    index2 = l2.Length - 1;
                }

                if (l1[index1] >= l2[index2])
                {
                    k = k - index2 + r - 1;
                    r = index2 + 1;
                }
                else
                {
                    k = k - index1 + l - 1;
                    l = index1 + 1;
                }
            }
        }
    }
    
    public static double FindMedianTalentIndex(int[] fireAbility, int[]
        iceAbility)
    {
        int l = fireAbility.Length;
        int r = iceAbility.Length;
        int k = l + r;
        if (k % 2 == 0)
        {
            return find(fireAbility, iceAbility, k / 2 + 1);
        }
        else
        {
            return (find(fireAbility, iceAbility, k / 2 + 1)  + find(fireAbility, iceAbility, k / 2)) / 2 ;
        }
// 在这⾥实现你的代码
    }
}
// 单元测试
public class TalentAssessmentSystemTests
{
    public void TestFindMedianTalentIndex()
    {

        int[] fireAbility = { 1,3,7,9, 11};
        int[] iceAbility = { 2, 4, 8, 10, 12, 14 };
        
        Console.WriteLine(TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility));

        // 在这⾥编写测试⽤例
    }
}