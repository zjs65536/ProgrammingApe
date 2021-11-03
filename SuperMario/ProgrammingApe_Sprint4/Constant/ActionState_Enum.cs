using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller_Command
{
    public enum ActionState_Enum
    {
        LeftIdle,
        RightIdle,

        LeftCrouching,
        RightCrounching,

        RightJumping,
        LeftJumping,

        Falling,

        LeftRunning,
        RightRunning,
    }
}
