using System;
using Constants;
using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Helpers
{
public static class Extension
{
#region IEnumerable

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
            action(item);
    }

#endregion
    
#region DoTween

    /// <summary>
    /// If tween IsActive or IsPlaying, than End (Kill of Complete)
    /// </summary>
    /// <param name="tween"></param>
    /// <param name="complete">Decide to Complete or Kill tween</param>
    public static void CheckAndEnd(this Tween tween, bool complete = true)
    {
        if (tween == null) return;

        if (tween.IsActive() && tween.IsPlaying())
        {
            if (complete)
                tween.Complete();
            else
                tween.Kill();
        }
    }

#endregion

#region Object

    /// <summary>
    /// If component persist -> return it, else add it to gameobject
    /// </summary>
    /// <param name="gameObject"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetOrAdd<T>(this GameObject gameObject) where T : Component =>
        gameObject.TryGetComponent(out T component) ? component : gameObject.AddComponent<T>();

    /// <summary>
    ///  Get Object or null (can be used for null-propagation / null-coalescing operations)
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T OrNull<T>(this T obj) where T : Object => obj ? obj : null;

    /// <summary>
    /// Get children of transform (very usefull for LINQs)
    /// </summary>
    public static IEnumerable<Transform> Children(this Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
            yield return transform.GetChild(i);
    }

#endregion

#region Vectors

    /// <summary>
    /// Override specific value of Vector2
    /// </summary>
    /// <returns></returns>
    public static Vector2 With(this Vector2 vector, float? x = null, float? y = null) =>
        new(x ?? vector.x, y ?? vector.y);

    /// <summary>
    /// Override specific value of Vector3
    /// </summary>
    /// <returns></returns>
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
        new(x ?? vector.x, y ?? vector.y, z ?? vector.z);

    /// <summary>
    /// Override specific value of Vector4
    /// </summary>
    /// <returns></returns>
    public static Vector4 With(this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null) =>
        new(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);

    public static float Remap (this float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
    
#endregion

#region IdleNumber

    public static IdleNumber Addition(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value += numberB.RoundToTargetValue(numberA.Lvl);
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }
    
    public static IdleNumber Multiply(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value *= numberB.Value;
        numberA.Lvl += numberB.Lvl;
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }

    public static IdleNumber Subtract(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value -= numberB.RoundToTargetValue(numberA.Lvl);
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }

    public static IdleNumber Divide(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value /= numberB.Value;
        numberA.Lvl -=numberB.Lvl;
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }

    /// <summary>
    /// Round number to certain value (M, B, T, AA, AB) if number is too big or too small
    /// </summary>
    public static void CheckAndRoundIdleNumber(this ref IdleNumber idleNumber)
    {
        bool isNegative = idleNumber.Value < 0;

        idleNumber.Value = Math.Abs(idleNumber.Value);

        if (idleNumber.Value >= 1000)
        {
            while (idleNumber.Value >= 1000)
            {
                if (idleNumber.Lvl < ConstantIdleNumber.LVL.Length - 1)
                {
                    idleNumber.Value /= 1000;
                    idleNumber.Lvl++;
                }
                else
                {
                    idleNumber.Value = Math.Clamp(idleNumber.Value, 0, 999);
                    break;
                }
            }
        }
        else if (idleNumber.Value < 1 && idleNumber.Value > 0)
        {
            if (idleNumber.Lvl > 0)
                while (idleNumber.Value < 1)
                {
                    idleNumber.Value *= 1000;
                    idleNumber.Lvl--;
                }
            else
                idleNumber.Reset();
        }
        else if (idleNumber.Value == 0)
        {
            idleNumber.Reset();
        }

        idleNumber.Value = Math.Round(idleNumber.Value, Math.Clamp(3 * idleNumber.Lvl, 0, 15));

        if (isNegative)
                idleNumber.Value *= -1;
    }

    /// <summary>
    /// Check if currency amount is bigger or equal to price
    /// </summary>
    public static bool IsEnough(this IdleNumber currency, IdleNumber price)
    {
        if (currency.Lvl == price.Lvl)
            return currency.Value >= price.Value;

        return currency.Lvl > price.Lvl;
    }

    public static double RoundToTargetValue(this IdleNumber idleNumber, int targetIdleNumberLvl)
    {
        var lvlDiff = idleNumber.Lvl - targetIdleNumberLvl;

        if (lvlDiff != 0)
            idleNumber.Value *= Math.Pow(1000, lvlDiff);

        return targetIdleNumberLvl == 0
            ? idleNumber.Value
            : Math.Round(idleNumber.Value, Math.Clamp(3 * Math.Abs(lvlDiff), 0, 15));
    }

    public static double RoundToTargetValue(this double number, int targetIdleNumberLvl)
    {
        var lvlDiff = (int)Math.Floor(number / 1000) - targetIdleNumberLvl;

        if (lvlDiff != 0)
            number *= Mathf.Pow(1000, lvlDiff);

        return targetIdleNumberLvl == 0
            ? number
            : Math.Round(number, Math.Clamp(3 * Math.Abs(lvlDiff), 0, 15));
    }

    static void Reset(this ref IdleNumber idleNumber)
    {
        idleNumber.Value = 0;
        idleNumber.Lvl = 0;
    }

    public static string AsString(this IdleNumber number) => $"{(number.Value == 0 ? 0 : (Math.Truncate(number.Value * 100) / 100).ToString("###.##"))} {ConstantIdleNumber.LVL[number.Lvl]}";

#endregion
}
}