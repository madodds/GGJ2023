using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;
using System;

public class PlayerObject : MonoBehaviour
{
    public PlayerCharacter PlayerCharacter;
    public int Money
    {
        get => _money;
    }
    private int _money = 1;

    public void AddMoney() => _money++;

    public void TakeMoney(int amount) => _money = Math.Max(_money - amount, 0);


}
