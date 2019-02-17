﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MemoryLibrary
{
    public interface IPlayable
    {
        void HideCard(int nr);
        void ShowCard(int nr, int card);
        void ShowWin();
    }
}
