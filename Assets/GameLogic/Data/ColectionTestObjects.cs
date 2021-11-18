using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    public class ColectionTestObjects : MonoBehaviour
    {
        public List<TestDataSave> testObjects;


        private void Awake()
        {
            foreach (var testObject in testObjects)
            {
                tests.Add(testObject);
            }
        }

        public List<ITestDataSave> tests = new List<ITestDataSave>();
    }
}