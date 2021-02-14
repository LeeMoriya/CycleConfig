using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using OptionalUI;
using Partiality;
using Partiality.Modloader;
using UnityEngine;

[assembly: IgnoresAccessChecksTo("Assembly-CSharp")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[module: UnverifiableCode]
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class IgnoresAccessChecksToAttribute : Attribute
    {
        public IgnoresAccessChecksToAttribute(string assemblyName)
        {
            AssemblyName = assemblyName;
        }
        public string AssemblyName { get; }
    }
}
public class CycleMod : PartialityMod
{
    public static PartialityMod mod;
    public static int startCycles = 19;
    public static int pebblesCycles = 5;
    public static bool customHunterCycles;
    public static bool customCycleLength;
    public static bool fixedCycle;
    public static int minimumCycleLength;
    public static int maximumCycleLength;
    public static int fixedCycleLength;
    public CycleMod()
    {
        this.ModID = "CycleConfig";
        this.Version = "1.1";
        this.author = "LeeMoriya";
    }

    public override void OnLoad()
    {
        base.OnLoad();
        Hook();
        mod = this;
    }

    public static OptionInterface LoadOI()
    {
        return new CycleConfig();
    }

    public static void Hook()
    {
        On.RedsIllness.RedsCycles += RedsIllness_RedsCycles;
        On.RainCycle.ctor += RainCycle_ctor;
        On.RainCycle.Update += RainCycle_Update;
    }

    private static void RainCycle_Update(On.RainCycle.orig_Update orig, RainCycle self)
    {
        orig.Invoke(self);
        if(fixedCycle && fixedCycleLength == 61 / 2 * 60)
        {
            if (self.timer > 2500)
            {
                self.timer = 2500;
            }
        }
    }

    private static void RainCycle_ctor(On.RainCycle.orig_ctor orig, RainCycle self, World world, float minutes)
    {
        if (customCycleLength)
        {
            float length;
            if (fixedCycle)
            {
                length = (float)fixedCycleLength / 60f;
                if (fixedCycleLength == 61 / 2 * 60)
                {
                    length = 32000 / 60 / 40;
                }
            }
            else
            {
                length = Mathf.Lerp((float)minimumCycleLength, (float)maximumCycleLength, UnityEngine.Random.value) / 60f;
            }
            orig.Invoke(self, world, length);
        }
        else
        {
            orig.Invoke(self, world, minutes);
        }
    }

    private static int RedsIllness_RedsCycles(On.RedsIllness.orig_RedsCycles orig, bool extraCycles)
    {
        if (customHunterCycles)
        {
            return (!extraCycles) ? startCycles : startCycles + pebblesCycles;
        }
        return orig.Invoke(extraCycles);
    }
}

