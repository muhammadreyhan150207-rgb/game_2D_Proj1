using System;
using UnityEngine;

public class MonsterInstance
{
    public MonsterData Data { get; private set; }
    public int Level { get; private set; }
    public int CurrentHP { get; private set; }
    public int Exp { get; private set; }

    public event Action Changed;

    private float Scale => 1f + (Level - 1) * 0.1f;
    public int MaxHP => Mathf.RoundToInt(Data.BaseHP * Scale) + Level * 2;
    public int Attack => Mathf.RoundToInt(Data.BaseATK * Scale);
    public int Defense => Mathf.RoundToInt(Data.BaseDEF * Scale);
    public int Speed => Mathf.RoundToInt(Data.BaseSPD * Scale);
    public int ExpToNext => Level * 10;

    public MonsterInstance(MonsterData data, int level)
    {
        Data = data;
        Level = level;
        CurrentHP = MaxHP;
    }

    public void TakeDamage(int amount)
    {
        CurrentHP = Mathf.Max(0, CurrentHP - amount);
        Changed?.Invoke();
    }

    public void GainExp(int amount)
    {
        Exp += amount;
        while (Exp >= ExpToNext)
        {
            Exp -= ExpToNext;
            Level++;
            CurrentHP = MaxHP;
            Debug.Log($"{Data.DisplayName} naik ke Lv {Level}!");

            if (Data.EvolvesTo != null && Level >= Data.EvolveLevel)
            {
                Debug.Log($"{Data.DisplayName} berevolusi menjadi {Data.EvolvesTo.DisplayName}!");
                Data = Data.EvolvesTo;
            }
        }
        Changed?.Invoke();
    }
}