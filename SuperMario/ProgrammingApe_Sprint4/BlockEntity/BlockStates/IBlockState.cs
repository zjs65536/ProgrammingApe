using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public interface IBlockState
    {
        IBlockState PreviouseState { get; }

        void Enter(IBlockState previousState);
        void Exit();


        void StandardTransition();
        void UsedTransition();
        void BumpTransition();

        void FallingTransition();

        void Update(GameTime gameTime);

    }
}
