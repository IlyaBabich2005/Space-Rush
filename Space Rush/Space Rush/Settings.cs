using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public partial class Settings : Form
    {
        private WeaponTypes playersWeaponType = WeaponTypes.MACHINEGUN;
        private MapDifficulty difficulty = MapDifficulty.NORMAL;

        public Settings()
        {
            InitializeComponent();
        }

        public WeaponTypes GetPlayersWeaponType()
        {
            return this.playersWeaponType;
        }

        public MapDifficulty GetDifficulty()
        {
            return this.difficulty;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Game.GetInstanse().InitializeGame();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void difficultuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.difficultuComboBox.SelectedIndex)
            {
                case 0: this.difficulty = MapDifficulty.EASY; break;
                case 1: this.difficulty = MapDifficulty.NORMAL; break;
                case 2: this.difficulty = MapDifficulty.HARD; break;
                default: throw new IndexOutOfRangeException();
            }
        }

        private void weaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.weaponComboBox.SelectedIndex)
            {
                case 0: this.playersWeaponType = WeaponTypes.MACHINEGUN; break;
                case 1: this.playersWeaponType = WeaponTypes.SHOTGUN; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
