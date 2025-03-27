using UnityEngine;

public class PRD
{
    public static float PFromC(float c)
    {
        float dCurrP;//第n次攻击发生暴击的概率等于 前n-1次攻击不暴击与P(n)的乘积
        float dPreSuccessP = 0f; //前n-1次攻击中发生暴击的概率
        float dPE = 0; //触发暴击所需的平均攻击次数
        int nMaxFail = (int)Mathf.Ceil(1f / c); //nMax
        for (int i = 1; i <= nMaxFail; i++)
        {
            dCurrP = Mathf.Min(1f, i * c) * (1 - dPreSuccessP);
            dPreSuccessP += dCurrP;
            dPE += i * dCurrP;
        }
        return 1f / dPE; //返回平均暴击概率Ptested
    }

    public static float CFromP(float p)
    {
        float dUp = p; //C在0-p范围内，C<p降低连续暴击的可能性
        float dLow = 0f;
        float dMid;
        float dPLast = 1f; //保证逻辑至少执行依次
        while (true)
        {
            dMid = (dUp + dLow) / 2f;//取当前最大暴击概率范围内的中值为增量C
            float dPtested = PFromC(dMid);//测试当前
            if (Mathf.Abs(dPtested - dPLast) <= 0.00005f) break;// 如果平均值变化不大，说明二分的区域已经很小了，此时可以退出循环。
            if (dPtested > p) dUp = dMid; //当前平均值大于期望值，向右查找
            else dLow = dMid;
            dPLast = dPtested; //保存每次二分求得的平均值，见上break处
        }
        return dMid;
    }

}
