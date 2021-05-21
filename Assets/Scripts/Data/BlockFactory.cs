using System;

namespace DefaultNamespace
{
    public class BlockFactory
    {
        public TrayBlock CreateTrayBlock()
        {
            Random rnd = new Random();
            TrayBlock trayBlock = new TrayBlock(rnd.Next(1,4));
            return trayBlock;
        }
    }
}