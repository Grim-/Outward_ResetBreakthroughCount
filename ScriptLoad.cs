using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using On;
using UnityEngine;

namespace DisableBreakThroughCount
{
    public class ScriptLoad : MonoBehaviour
    {
        public static DisableBreakThroughCount disableBT;

        public void Initialise()
        {
            Debug.Log(":: Reset Breakthrough Points INIT ::");

            Patch();
        }

        public void Patch()
        {
            //Put in patched methods here
            On.PlayerCharacterStats.OnUpdateStats += new On.PlayerCharacterStats.hook_OnUpdateStats(onUpdateStatsHook);
        }

        private void onUpdateStatsHook(On.PlayerCharacterStats.orig_OnUpdateStats orig, PlayerCharacterStats self)
        {
            orig(self);

            if (Input.GetKeyDown(KeyCode.F12))
            {
                FieldInfo pcStatsInfo = typeof(PlayerCharacterStats).GetField("m_usedBreakthroughCount", BindingFlags.Instance | BindingFlags.NonPublic);

                Debug.Log("Breakthrough use count : BEFORE " + pcStatsInfo.GetValue(self));
                pcStatsInfo.SetValue(self, 0);
                Debug.Log("Breakthrough use count : AFTER " + pcStatsInfo.GetValue(self));
            }
        }
    }
}
