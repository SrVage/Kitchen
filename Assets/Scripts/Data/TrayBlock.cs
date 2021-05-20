using System;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public enum BlockState
    {
        None = 0,
        BlueCube = 1,
        GreenCube = 2,
        RedSphere = 3
    }
    public struct TrayBlock
    {
        private BlockState _firstBlock;
        private BlockState _secondBlock;
        private BlockState _thirdBlock;
        
        public BlockState FirstBlock
        {
            get => _firstBlock;
            set { _firstBlock = value; }
        }

        public BlockState SecondBlock
        {
            get => _secondBlock;
            set { _secondBlock = value; }
        }

        public BlockState ThirdBlock
        {
            get => _thirdBlock;
            set { _thirdBlock = value; }
        }


        public TrayBlock(int a)
        {
            Random rnd = new Random();
            switch (a)
            {
                case 1:
                {
                    _firstBlock = (BlockState) rnd.Next(1, 4);
                    _secondBlock = BlockState.None;
                    _thirdBlock = BlockState.None;
                    break;
                }
                case 2:
                {
                    _firstBlock = (BlockState) rnd.Next(1, 4);
                    _secondBlock = (BlockState) rnd.Next(1, 4);
                    _thirdBlock = BlockState.None;
                    break;
                }
                case 3:
                {
                    _firstBlock = (BlockState) rnd.Next(1, 4);
                    _secondBlock = (BlockState) rnd.Next(1, 4);
                    _thirdBlock = (BlockState) rnd.Next(1, 4);
                    break;
                }
                default:
                {
                    _firstBlock = BlockState.None;
                    _secondBlock = BlockState.None;
                    _thirdBlock = BlockState.None;
                    break;
                }
            }
        }

        public bool CompareBlock(TrayBlock v1)
        {
            if (FirstBlock == v1.FirstBlock &&
                SecondBlock == v1.SecondBlock &&
                ThirdBlock == v1.ThirdBlock) 
                return true;
            else
                return false;
        }
    }
}