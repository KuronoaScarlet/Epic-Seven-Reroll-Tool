using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum Phase
{
    ALL,
    SKYSTONES,
    TABLE
}

public class OperationsScript : MonoBehaviour
{
    private int covenantPrice = 184000, mysticsPrice = 280000, covenantQuantity = 5, mysticsQuantity = 50, skystonePack = 951;
    public int skystones, gold, covenants, mystics;
    public int totalRRValue, ssPacksValue = 0, stopSSValue, rerolledSSValue;
    public int covExpValue, covObValue = 0, covSpentValue, covBalValue;
    public int mysObValue = 0, mysSpentValue, mysBalValue;
    public int gSpentValue, gBalValue;

    public TMP_Text initSS, totalRerolls, ssPacks, stopSS, rerolledSS;
    public TMP_Text initG, gSpent, gBalance;
    public TMP_Text initCov, expectedCov, covObtained, covSpent, covBalance;
    public TMP_Text initMys, mysObtained, mysSpent, mysBalance;

    public void SetValues(int ss, int g, int cove, int myst)
    {
        skystones = ss;
        gold = g;
        covenants = cove;
        mystics = myst;
        initG.SetText(gold.ToString() + " G");
        initCov.SetText(covenants.ToString());
        initMys.SetText(mystics.ToString());
        SetValuesToText(Phase.ALL);
    }

    public void SetValuesToText(Phase phase)
    {
        if(phase == Phase.ALL || phase == Phase.SKYSTONES)
        {
            // Skystones value texts update
            PerformSkystonesOperations();
            initSS.SetText(skystones.ToString());
            totalRerolls.SetText(totalRRValue.ToString());
            ssPacks.SetText(ssPacksValue.ToString());
            stopSS.SetText(stopSSValue.ToString());
            rerolledSS.SetText(rerolledSSValue.ToString());
            expectedCov.SetText(covExpValue.ToString());
        }
        if (phase == Phase.ALL || phase == Phase.TABLE)
        {
            // Table 
            PerformBuyOperations();
            gSpent.SetText(gSpentValue.ToString() + " G");
            gBalance.SetText(gBalValue.ToString() + " G");
            covObtained.SetText(covObValue.ToString());
            covSpent.SetText(covSpentValue.ToString() + " G");
            covBalance.SetText(covBalValue.ToString());
            mysObtained.SetText(mysObValue.ToString());
            mysSpent.SetText(mysSpentValue.ToString() + " G");
            mysBalance.SetText(mysBalValue.ToString());
        }
    }

    void PerformSkystonesOperations()
    {
        totalRRValue = Mathf.RoundToInt(skystones / 3);
        stopSSValue = skystones - (ssPacksValue * skystonePack);
        rerolledSSValue = ssPacksValue * skystonePack;
        covExpValue = ssPacksValue * covenantQuantity * 10;
    }

    void PerformBuyOperations()
    {
        covSpentValue = (covObValue / covenantQuantity) * covenantPrice;
        covBalValue = covenants + covObValue;

        mysSpentValue = (mysObValue / mysticsQuantity) * mysticsPrice;
        mysBalValue = mystics + mysObValue;

        gSpentValue = covSpentValue + mysSpentValue;
        gBalValue = gold - gSpentValue;
    }

    public void AddSSPack()
    {
        if(stopSSValue - skystonePack > 0) ssPacksValue++;
        SetValuesToText(Phase.SKYSTONES);
    }

    public void BuyCovenant()
    {
        if(gBalValue - covenantPrice >= 0)  covObValue += covenantQuantity;
        SetValuesToText(Phase.TABLE);
    }

    public void BuyMystic()
    {
        if (gBalValue - mysticsPrice >= 0)  mysObValue += mysticsQuantity;
        SetValuesToText(Phase.TABLE);
    }

    public void UnBuyCovenant()
    {
        if(covObValue - covenantQuantity >= 0)  covObValue -= covenantQuantity;
        SetValuesToText(Phase.TABLE);
    }

    public void UnBuyMystic()
    {
        if (mysObValue - mysticsQuantity >= 0) mysObValue -= mysticsQuantity;
        SetValuesToText(Phase.TABLE);
    }
}
