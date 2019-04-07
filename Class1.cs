using Partiality.Modloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DisableBreakThroughCount
{
    public class DisableBreakThroughCount : PartialityMod
    {
        public static ScriptLoad qsmPatch;

        public DisableBreakThroughCount()
        {
            this.ModID = "Reset Breakthrough Points";
            this.Version = "0.1";
            this.author = "Emo #Discord : Emo #7953";
        }

        public override void OnEnable()
        {
            base.OnEnable();

            ScriptLoad.disableBT = this;


            GameObject obj = new GameObject();
            qsmPatch = obj.AddComponent<ScriptLoad>();
            qsmPatch.Initialise();

            Debug.Log(":: Reset Breakthrough Points ENABLED ::");
        }

    }
}

