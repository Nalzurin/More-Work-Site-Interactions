using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using HarmonyLib;
using System.Reflection.Emit;
using System.Reflection;
using RimWorld.QuestGen;

namespace QuestSource
{

    [HarmonyPatch]
    public static class PatchQuestGeneration
    {

        private static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(QuestGen), nameof(QuestGen.Generate));
        }
        private static void Postfix(Quest __result, QuestScriptDef root, Slate initialVars)
        {
            TaggedString desc = __result.description;
            desc += $"\n\n<color=#808080>{root.modContentPack.Name}</color>";
            __result.description = desc;
        }

    }
}
