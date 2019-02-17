using System;
using System.Drawing;
using System.Windows.Forms;
using MemoryLibrary;

namespace Cards
{
    public partial class FormMemCards : Form, IPlayable
    {
        

        LogicMem logic;

        public FormMemCards()
        {
            InitializeComponent();
            logic = new LogicMem(this);
            logic.CreateNewGame();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"Цель игры - открыть все карточки
за минимальное количество ходов.

На столе лежит 16 перевернутых карточек.
На них изображено 8 различных картинок.
Каждая картинка изображена дважды.
Необходимо найти парные карточки.

Щелкайте по карточкам, чтобы их перевернуть.
Если пара пара подобрана верно, то карточки остаются,
если нет - переворачиваются назад.
Запоминайте карточки на картинках, чтобы
в следующий раз открыввть их верно.", "Правила игры");
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"Игра Карточки памяти
создано Дмитрием М.
linksum@mail.ru",
"О программе");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int nr = int.Parse(((PictureBox)sender).Tag.ToString());
            logic.ClickPicture(nr);
            return;
            
        }

        

        public void ShowWin()
        {
            MessageBox.Show("Win. " +  logic.cou + "clicks");

        }

        

        

        

        private void loadPicture(int picture, int image)
        {
           getPictureBox(picture).Image = getImage(image);
        }

        private PictureBox getPictureBox(int picture)
        {
            
            switch (picture)
            {
                case 0: return pictureBox0;
                case 1: return pictureBox1;
                case 2: return pictureBox2;
                case 3: return pictureBox3;
                case 4: return pictureBox4;
                case 5: return pictureBox5;
                case 6: return pictureBox6;
                case 7: return pictureBox7;
                case 8: return pictureBox8;
                case 9: return pictureBox9;
                case 10: return pictureBox10;
                case 11: return pictureBox11;
                case 12: return pictureBox12;
                case 13: return pictureBox13;
                case 14: return pictureBox14;
                case 15: return pictureBox15;
                default: return null;
            }
        }
        private Image getImage(int image)
        {
            switch (image)
            {
                case 0: return Properties.Resources._00;
                case 1: return Properties.Resources._1;
                case 2: return Properties.Resources._2;
                case 3: return Properties.Resources._3;
                case 4: return Properties.Resources._4;
                case 5: return Properties.Resources._5;
                case 6: return Properties.Resources._6;
                case 7: return Properties.Resources._7;
                case 8: return Properties.Resources._8;
                default: return null;
            }
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            logic.CreateNewGame();
            //initGame();
        }

        public void HideCard(int picture)
        {
            loadPicture(picture, 0);
            getPictureBox(picture).Cursor = Cursors.Hand;
        }

        public void ShowCard(int nr, int card)
        {
            loadPicture(nr, card);
            getPictureBox(nr).Cursor = Cursors.Arrow;
        }

        

        
    }
}
