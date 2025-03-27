using UnityEngine;

public class PRD
{
    public static float PFromC(float c)
    {
        float dCurrP;//��n�ι������������ĸ��ʵ��� ǰn-1�ι�����������P(n)�ĳ˻�
        float dPreSuccessP = 0f; //ǰn-1�ι����з��������ĸ���
        float dPE = 0; //�������������ƽ����������
        int nMaxFail = (int)Mathf.Ceil(1f / c); //nMax
        for (int i = 1; i <= nMaxFail; i++)
        {
            dCurrP = Mathf.Min(1f, i * c) * (1 - dPreSuccessP);
            dPreSuccessP += dCurrP;
            dPE += i * dCurrP;
        }
        return 1f / dPE; //����ƽ����������Ptested
    }

    public static float CFromP(float p)
    {
        float dUp = p; //C��0-p��Χ�ڣ�C<p�������������Ŀ�����
        float dLow = 0f;
        float dMid;
        float dPLast = 1f; //��֤�߼�����ִ������
        while (true)
        {
            dMid = (dUp + dLow) / 2f;//ȡ��ǰ��󱩻����ʷ�Χ�ڵ���ֵΪ����C
            float dPtested = PFromC(dMid);//���Ե�ǰ
            if (Mathf.Abs(dPtested - dPLast) <= 0.00005f) break;// ���ƽ��ֵ�仯����˵�����ֵ������Ѿ���С�ˣ���ʱ�����˳�ѭ����
            if (dPtested > p) dUp = dMid; //��ǰƽ��ֵ��������ֵ�����Ҳ���
            else dLow = dMid;
            dPLast = dPtested; //����ÿ�ζ�����õ�ƽ��ֵ������break��
        }
        return dMid;
    }

}
