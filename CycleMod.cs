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
    public CycleMod()
    {
        this.ModID = "CycleConfig";
        this.Version = "1.0";
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
    }

    private static int RedsIllness_RedsCycles(On.RedsIllness.orig_RedsCycles orig, bool extraCycles)
    {
        return (!extraCycles) ? startCycles : startCycles + pebblesCycles;
    }
}

