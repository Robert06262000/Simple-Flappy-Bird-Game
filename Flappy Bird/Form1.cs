using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 7;
        int scoring = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeDown.Left -= pipeSpeed;
            pipeUp.Left -= pipeSpeed;
            lblScore.Text = scoring.ToString();

            if (pipeDown.Left < -150)
            {
                pipeDown.Left = 800;
                scoring++;
            }
            if (pipeUp.Left < -100)
            {
                pipeUp.Left = 950;
                scoring++;
            }
            if (bird.Bounds.IntersectsWith(pipeUp.Bounds) || bird.Bounds.IntersectsWith(pipeDown.Bounds)
                || bird.Bounds.IntersectsWith(ground.Bounds))
            {
                gameOver();
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                gravity = -7;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }
        }

        private void gameOver()
        {
            gameTimer.Stop();
            lblScore.Text = "Game Over!";
        }
    }
}
