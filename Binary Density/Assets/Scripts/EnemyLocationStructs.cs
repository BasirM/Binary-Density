using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocationStructs : MonoBehaviour
{
   public struct Wave1
    {
        public static Vector3 e1Pos = new Vector3(8f, 4f, -.5f);
        public static Vector3 e2Pos = new Vector3(6f, 4f, -.5f);
        public static Vector3 e3Pos = new Vector3(4f, 4f, -.5f);
        public static Vector3 e4Pos = new Vector3(2f, 4f, -.5f);
        public static Vector3 e5Pos = new Vector3(0f, 4f, -.5f);
        public static Vector3 e6Pos = new Vector3(-2f, 4f, -.5f);
        public static Vector3 e7Pos = new Vector3(-4f, 4f, -.5f);
        public static Vector3 e8Pos = new Vector3(-6f, 4f, -.5f);
        public static Vector3 e9Pos = new Vector3(-8f, 4f, -.5f);
        public static Vector3 e10Pos = new Vector3(-7f, 2f, -.5f);
        public static Vector3 e11Pos = new Vector3(-5f, 2f, -.5f);
        public static Vector3 e12Pos = new Vector3(-3f, 2f, -.5f);
        public static Vector3 e13Pos = new Vector3(-1f, 2f, -.5f);
        public static Vector3 e14Pos = new Vector3(1f, 2f, -.5f);
        public static Vector3 e15Pos = new Vector3(3f, 2f, -.5f);
        public static Vector3 e16Pos = new Vector3(5f, 2f, -.5f);
        public static Vector3 e17Pos = new Vector3(7f, 2f, -.5f);
    }

    public struct Wave2
    {
        public static Vector3 e1Pos = new Vector3(8f, 5f, -.5f);
        public static Vector3 e2Pos = new Vector3(7f, 4f, -.5f);
        public static Vector3 e3Pos = new Vector3(6f, 3f, -.5f);
        public static Vector3 e4Pos = new Vector3(5f, 2f, -.5f);
        public static Vector3 e5Pos = new Vector3(4f, 1f, -.5f);
        public static Vector3 e6Pos = new Vector3(3f, 0f, -.5f);
        public static Vector3 e7Pos = new Vector3(1.5f, 0f, -.5f);
        public static Vector3 e8Pos = new Vector3(0f, 0f, -.5f);
        public static Vector3 e9Pos = new Vector3(-1.5f, 0f, -.5f);
        public static Vector3 e10Pos = new Vector3(-3f, 0f, -.5f);
        public static Vector3 e11Pos = new Vector3(-4f, 1f, -.5f);
        public static Vector3 e12Pos = new Vector3(-5f, 2f, -.5f);
        public static Vector3 e13Pos = new Vector3(-6f, 3f, -.5f);
        public static Vector3 e14Pos = new Vector3(-7f, 4f, -.5f);
        public static Vector3 e15Pos = new Vector3(-8f, 5f, -.5f);
        public static Vector3 e16Pos = new Vector3(4.5f, 0f, -.5f);
        public static Vector3 e17Pos = new Vector3(6f, 0f, -.5f);
        public static Vector3 e18Pos = new Vector3(7.5f, 0f, -.5f);
        public static Vector3 e19Pos = new Vector3(-4.5f, 0f, -.5f);
        public static Vector3 e20Pos = new Vector3(-6f, 0f, -.5f);
        public static Vector3 e21Pos = new Vector3(-7.5f, 0f, -.5f);
        public static Vector3 e22Pos = new Vector3(3f, 4f, -.5f);
        public static Vector3 e23Pos = new Vector3(1.5f, 4f, -.5f);
        public static Vector3 e24Pos = new Vector3(0f, 4f, -.5f);
        public static Vector3 e25Pos = new Vector3(-1.5f, 4f, -.5f);
        public static Vector3 e26Pos = new Vector3(-3f, 4f, -.5f);
        public static Vector3 e27Pos = new Vector3(0f, 1f, -.5f);
        public static Vector3 e28Pos = new Vector3(0f, 1.5f, -.5f);
        public static Vector3 e29Pos = new Vector3(0f, 2f, -.5f);
    }

    public struct Wave3
    {
        public static Vector3 e1Pos = new Vector3(-6f, 5f, -.5f);
        public static Vector3 e2Pos = new Vector3(-7.5f, 3.5f, -.5f);
        public static Vector3 e3Pos = new Vector3(-7.5f, 2f, -.5f);
        public static Vector3 e4Pos = new Vector3(-6f, .5f, -.5f);
        public static Vector3 e5Pos = new Vector3(-4.5f, .5f, -.5f);
        public static Vector3 e6Pos = new Vector3(-3f, 2f, -.5f);
        public static Vector3 e7Pos = new Vector3(-3f, 3.5f, -.5f);
        public static Vector3 e8Pos = new Vector3(-4.5f, 5f, -.5f);
        public static Vector3 e9Pos = new Vector3(-5.25f, 2.75f, -.5f);
        public static Vector3 e10Pos = new Vector3(-2f, 3.5f, -.5f);
        public static Vector3 e11Pos = new Vector3(-.5f, .5f, -.5f);
        public static Vector3 e12Pos = new Vector3(2.5f, 2f, -.5f);
        public static Vector3 e13Pos = new Vector3(1f, 5f, -.5f);
        public static Vector3 e14Pos = new Vector3(-.5f, 5f, -.5f);
        public static Vector3 e15Pos = new Vector3(-2f, 2f, -.5f);
        public static Vector3 e16Pos = new Vector3(1f, .5f, -.5f);
        public static Vector3 e17Pos = new Vector3(2.5f, 3.5f, -.5f);
        public static Vector3 e18Pos = new Vector3(.25f, 2.75f, -.5f);
        public static Vector3 e19Pos = new Vector3(6f, 2.75f, -.5f);
        public static Vector3 e20Pos = new Vector3(3.75f, 3.5f, -.5f);
        public static Vector3 e21Pos = new Vector3(5.25f, .5f, -.5f);
        public static Vector3 e22Pos = new Vector3(8.25f, 2f, -.5f);
        public static Vector3 e23Pos = new Vector3(6.75f, 5f, -.5f);
        public static Vector3 e24Pos = new Vector3(5.25f, 5f, -.5f);
        public static Vector3 e25Pos = new Vector3(3.75f, 2f, -.5f);
        public static Vector3 e26Pos = new Vector3(6.75f, .5f, -.5f);
        public static Vector3 e27Pos = new Vector3(8.25f, 3.5f, -.5f);
    }
}
