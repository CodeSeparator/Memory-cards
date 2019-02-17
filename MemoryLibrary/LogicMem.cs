using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MemoryLibrary
{
    public class LogicMem
    {
        IPlayable play;

        int[] cards = new int[16];
        bool[] opens = new bool[16];
        int done;
        int status;
        int cardA;
        int cardB;
        public int cou;
        static Random rnd = new Random();

        public LogicMem(IPlayable play)
        {
            this.play = play;
        }

        public void CreateNewGame()
        {
            for (int j = 0; j < cards.Length; j++)
                cards[j] = j % (cards.Length / 2) + 1;
            for (int j = 0; j < 100; j++)
                shuffleCards();
            
            for (int j = 0; j < cards.Length; j++)
                play.HideCard(j);
            for (int j = 0; j < cards.Length; j++)
                opens[j] = false;
            done = 0;
            status = 0;
            cou = 0;
        }

        public void ClickPicture(int nr)
        {
            if (opens[nr]) return;
            switch (status)
            {
                case 0: status0(nr); break;
                case 1: status1(nr); break;
                case 2: status2(nr); break;
                case 3: status3(nr); break;
            }
            cou++;
        }

        private void shuffleCards()
        {
            int a = rnd.Next(0, cards.Length);
            int b = rnd.Next(0, cards.Length);
            if (a == b) return;
            cards[a] ^= cards[b];
            cards[b] ^= cards[a];
            cards[a] ^= cards[b];
        }

        private void open(int picture)
        {
            opens[picture] = true;
            play.ShowCard(picture, cards[picture]);
        }

        private void status2(int nr)
        {
            throw new NotImplementedException();
        }

        private void status0(int nr)
        {
            cardA = nr;
            play.ShowCard(cardA, cards[cardA]);
            status = 1;

        }

        private void status3(int nr)
        {
            play.HideCard(cardA);
            play.HideCard(cardB);
            status0(nr);
        }

        private void status1(int nr)
        {
            cardB = nr;
            if (cardA == cardB)
                return;
            play.ShowCard(cardB, cards[cardB]);
            status = 2;
            if (cards[cardA] == cards[cardB])
            {
                open(cardA);
                open(cardB);
                done += 2;
                if (done == 16)
                {
                    play.ShowWin();
                    //initGame();
                }
                else status = 0;
            }
            else status = 3;
        }
    }
}
