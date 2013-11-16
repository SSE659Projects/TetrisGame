using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace Tetris.Tests
{
    [TestFixture]
    class TetrisTests : Game.BlockClass
    {
        [TestCase(Game.BlockTypeNum.block01,ExpectedResult = 0)]
        [TestCase(Game.BlockTypeNum.block02, ExpectedResult = 1)]
        [TestCase(Game.BlockTypeNum.block03, ExpectedResult = 2)]
        [TestCase(Game.BlockTypeNum.block04, ExpectedResult = 3)]
        [TestCase(Game.BlockTypeNum.block05, ExpectedResult = 4)]
        [TestCase(Game.BlockTypeNum.block06, ExpectedResult = 5)]
        [TestCase(Game.BlockTypeNum.block07, ExpectedResult = 6)]
        [TestCase(Game.BlockTypeNum.block08, ExpectedResult = 7)]
        [TestCase(Game.BlockTypeNum.block09, ExpectedResult = 8)]
        [TestCase(Game.BlockTypeNum.block10, ExpectedResult = 9)]
        [TestCase(Game.BlockTypeNum.block11, ExpectedResult = 10)]
        [TestCase(Game.BlockTypeNum.block12, ExpectedResult = 11)]
        public int checkBlockType(Game.BlockTypeNum block)
        {
            return base.GetImageByType(block);
        }

        [TestCase("Red", ExpectedResult = 0)]
        [TestCase("Blue", ExpectedResult = 1)]
        [TestCase("Green", ExpectedResult = 2)]
        [TestCase("Cyan", ExpectedResult = 3)]
        [TestCase("Yellow", ExpectedResult = 4)]
        [TestCase("Orange", ExpectedResult = 5)]
        [TestCase("Magenta", ExpectedResult = 6)]
        [TestCase("Brown", ExpectedResult = 7)]
        [TestCase("DarkBlue", ExpectedResult = 8)]
        [TestCase("GreenYellow", ExpectedResult = 9)]
        [TestCase("Pink", ExpectedResult = 10)]
        [TestCase("None", ExpectedResult = 11)]
        public int checkBlockColor(string color)
        {
            Color c = System.Drawing.Color.FromName(color);
            return base.GetImageByColor(c);
        }

        [TestCase(0, Game.RotationEnum.deg0, ExpectedResult = Game.RotationEnum.deg90)]
        [TestCase(0, Game.RotationEnum.deg90, ExpectedResult = Game.RotationEnum.deg180)]
        [TestCase(0, Game.RotationEnum.deg180, ExpectedResult = Game.RotationEnum.deg270)]
        [TestCase(0, Game.RotationEnum.deg270, ExpectedResult = Game.RotationEnum.deg0)]
        [TestCase(1, Game.RotationEnum.deg0, ExpectedResult = Game.RotationEnum.deg270)]
        [TestCase(1, Game.RotationEnum.deg270, ExpectedResult = Game.RotationEnum.deg180)]
        [TestCase(1, Game.RotationEnum.deg180, ExpectedResult = Game.RotationEnum.deg90)]
        [TestCase(1, Game.RotationEnum.deg90, ExpectedResult = Game.RotationEnum.deg0)]
        public Game.RotationEnum checkNextRotation(int rotateOption, Game.RotationEnum degree)
        {
            Angle = degree; 
            return base.getNextAngle(rotateOption);
        }

        [TestCase(Game.DifficultyEnum.Easy, ExpectedResult = "Easy")]
        [TestCase(Game.DifficultyEnum.Hard, ExpectedResult = "Hard")]
        public string checkDifficultyGeneration(Game.DifficultyEnum d)
        {
            Game.StructBlock structBlock = base.Generate(d);

            if (structBlock.angle == Game.RotationEnum.deg0 ||
                structBlock.angle == Game.RotationEnum.deg90 ||
                structBlock.angle == Game.RotationEnum.deg180 ||
                    structBlock.angle == Game.RotationEnum.deg270)
            {
                if ((structBlock.type == Game.BlockTypeNum.block08 ||
                    structBlock.type == Game.BlockTypeNum.block09 ||
                    structBlock.type == Game.BlockTypeNum.block10 ||
                    structBlock.type == Game.BlockTypeNum.block11) &&
                    d == Game.DifficultyEnum.Hard)
                    return "Hard";
                else if ((structBlock.type == Game.BlockTypeNum.block01 ||
                    structBlock.type == Game.BlockTypeNum.block02 ||
                    structBlock.type == Game.BlockTypeNum.block03 ||
                    structBlock.type == Game.BlockTypeNum.block04 ||
                    structBlock.type == Game.BlockTypeNum.block05 ||
                    structBlock.type == Game.BlockTypeNum.block06 ||
                    structBlock.type == Game.BlockTypeNum.block07) &&
                    d == Game.DifficultyEnum.Easy)
                    return "Easy";
                else
                    return "Hard";
            }
            return "Hard";
        }

        [TestCase("Red", 1)]
        [TestCase("Blue", 2)]
        [TestCase("Green", 3)]
        [TestCase("Cyan", 4)]
        [TestCase("Yellow", 5)]
        [TestCase("Orange", 6)]
        [TestCase("Magenta", 7)]
        [TestCase("Brown", 8)]
        [TestCase("DarkBlue", 9)]
        [TestCase("GreenYellow", 10)]
        [TestCase("Pink", 11)]
        [TestCase("White", 12)]
        public void checkRandomColor(string color, int colorNumber)
        {
            Color expected = System.Drawing.Color.FromName(color);
            Color actual;
            actual = base.Color(colorNumber);
            Assert.AreEqual(expected, actual);
        }
    }
}
