using System;
using System.Reflection;
using UnityModManagerNet;
using Harmony12;
using UnityEngine;

namespace Shunter300Mod
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            // Something
            return true; // If false the mod will show an error.
        }
    }

    [HarmonyPatch(typeof(LocoControllerShunter), "Start")]
    class LocoControllerShunter_Àwake_Patch
    {
        static void Postfix(LocoControllerShunter __instance)
        {
            AnimationCurve accAnimationCurve = __instance.tractionTorqueCurve;

            accAnimationCurve.RemoveKey(2);
            accAnimationCurve.AddKey(300f, 0f);
        }
    }

}
