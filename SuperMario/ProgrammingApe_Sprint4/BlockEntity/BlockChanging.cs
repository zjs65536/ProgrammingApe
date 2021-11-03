using Controller_Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public class BlockChanging
    {
        private BlockEntity BlockEntity { get; set; }

        public BlockChanging(BlockEntity block)
        {
            BlockEntity = block;
        }

        public void Update()
        {

            if (BlockEntity.blockState_Enum == BlockState_enum.QuestionBlock && BlockEntity.Sprite.BlockType() != "questionBlock")
            {
                BlockEntity.Sprite = BlockEntity.SpriteFactory.createBlock(SpriteFactory.sprites.questionBlock);

            }
            else if (BlockEntity.blockState_Enum == BlockState_enum.BrickBlock && BlockEntity.Sprite.BlockType() != "brickBlock")
            {
                BlockEntity.Sprite = BlockEntity.SpriteFactory.createBlock(SpriteFactory.sprites.brickBlock);

            }
            else if (BlockEntity.blockState_Enum == BlockState_enum.UsedBlock && BlockEntity.Sprite.BlockType() != "usedQuestionBlock")
            {
                BlockEntity.Sprite = BlockEntity.SpriteFactory.createBlock(SpriteFactory.sprites.usedQuestionBlock);

            }
            else if (BlockEntity.blockState_Enum == BlockState_enum.ExplodedBlock && BlockEntity.Sprite.BlockType() != "fourPiecesBlock")
            {
                BlockEntity.Sprite = BlockEntity.SpriteFactory.createBlock(SpriteFactory.sprites.fourPiecesBlock);

            }
        }

    }
}

