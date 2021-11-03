using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public interface IEnemyState
    {
        IEnemyState PreviouseState { get; }

        void Enter(IEnemyState previousState);
        void Exit();
        void DieTransition();
        void ShellTransition();
        void KoopaStandardTransition();
        void PiranhaHideTransition();
        void PiranhaStandardTransition();
        void Update(GameTime gameTime);
    }
}
