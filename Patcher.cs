using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;
using UnityEngine;

namespace AllDogsAreGoodBois
{
    public class Patcher
    {
        public static readonly List<ThingDef> leather = new List<ThingDef>() { DefOfClass.Leather_Dog, DefOfClass.Leather_Wolf };
        public static void AllDogs()
        {
            foreach(PawnKindDef dog in DefDatabase<PawnKindDef>.AllDefsListForReading)
            {
                if (dog.race != null && leather.Contains(dog.race.race.leatherDef))
                {
                    dog.canArriveManhunter = false;
                }
            }
        }

        [StaticConstructorOnStartup]
        public static class StartUp
        {
            static StartUp()
            {
                AllDogs();
            }
        }
    }

    [RimWorld.DefOf]
    public static class DefOfClass
    {
        public static ThingDef Leather_Dog;
        public static ThingDef Leather_Wolf;

        static DefOfClass()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(DefOfClass));
        }
    }
}
