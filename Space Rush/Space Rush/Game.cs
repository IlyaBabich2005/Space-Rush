using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Space_Rush
{
    public partial class Game : Form
    {
        private List<CollidebleEntity> collidebleEntities;
        private List<Entity> entities;
        private static Game instanse = null;
        private PlayableCharacter player;
        private float timeSinceGameStart;
        private Map map;
        private int score = 0;
        private Settings settings;
        private int numOfPlayers = 1;
        private int num = 1;

        private Game()
        {
            InitializeComponent();
            this.BackColor = Color.Black;

            this.collidebleEntities = new List<CollidebleEntity>();
            this.entities = new List<Entity>();
            this.settings = new Settings();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            this.numOfEntitiesLabel.Text = "Счёт: " + this.score;

            this.timeSinceGameStart += (float)this.gameTimer.Interval / 1000;

            this.StopPlayerFromOutOfBounds();

            this.DetectCollisions();

            this.map.SpawnEnemy();
        }

        private void StopPlayerFromOutOfBounds()
        {
            if (this.player.GetHP() <= 0)
            {
                this.map.IsSpawn(false);
            }

            if (player.GetPosition().x <= 0)
            {
                if (player.GetVelosity().x < 0)
                {
                    player.SetVelosity(new Vector2d(0, player.GetVelosity().y));
                }
            }
            if (player.GetPosition().x + player.GetHitBox().Width >= this.Width)
            {
                if (player.GetVelosity().x > 0)
                {
                    player.SetVelosity(new Vector2d(0, player.GetVelosity().y));
                }
            }
            if (player.GetPosition().y <= 0)
            {
                if (player.GetVelosity().y < 0)
                {
                    player.SetVelosity(new Vector2d(player.GetVelosity().x, 0));
                }
            }
            if (player.GetPosition().y + player.GetHitBox().Height >= this.Height - 40)
            {
                if (player.GetVelosity().y > 0)
                {
                    player.SetVelosity(new Vector2d(player.GetVelosity().x, 0));
                }
            }
        }

        private void DetectCollisions()
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                this.entities[i].UpdateState();

                if (entities[i].IsReadyToDespawn())
                {
                    this.DespawnEntity(entities[i]);
                }

                if (i < this.collidebleEntities.Count - 1)
                {
                    for (int j = i + 1; j < this.collidebleEntities.Count; j++)
                    {
                        this.collidebleEntities[i].HandleCollision(this.collidebleEntities[j]);
                    }
                }
            }
        }

        public static Game GetInstanse()
        {
            if (instanse == null)
            {
                instanse = new Game();
            }

            return instanse;
        }

        public float GetDeltaTime()
        {
            return (float)this.gameTimer.Interval / 1000;
        }

        public float GetTimeSinceGameStart()
        {
            return this.timeSinceGameStart;
        }

        public int GetNewID()
        {
            return this.entities.Count() + 1;
        }

        public Vector2d GetWindowSize()
        {
            return new Vector2d(this.Width, this.Height);
        }

        public void TakePoints(int points)
        {
            this.score += points;
        }

        public void SetCollidebleEntities(List<CollidebleEntity> newEntities)
        {
            for (int i = 0; i < newEntities.Count; i++)
            {
                this.SpawnCollidebleEntity(newEntities[i]);
            }
        }

        public void SpawnCollidebleEntity(CollidebleEntity newEntity)
        {
            this.SpawnEntity((Entity)newEntity);
            this.collidebleEntities.Add(newEntity);
        }

        public void SpawnEntity(Entity entity)
        {
            this.entities.Add(entity);
            this.Controls.Add(this.entities[this.entities.Count - 1].GetHitBox());
        }

        public void DespawnEntity(Entity entity)
        {
            this.entities.Remove(entity);
            this.Controls.Remove(entity.GetHitBox());

            try
            {
                this.collidebleEntities.Remove((CollidebleEntity)entity);
            }
            catch
            {
                return;
            }
        }

        public void DespawnAll()
        {
            for (int i = 0; i < this.entities.Count(); i = 0)
            {
                this.DespawnEntity(entities[i]);
            }
        }

        private void InitializePlayer()
        {
            PlayerFabric playerMaker = new PlayerFabric();

            this.player = playerMaker.MakePlayer(this.settings.GetPlayersWeaponType());

            this.SpawnCollidebleEntity(this.player);
            this.SpawnEntity(this.player.GetHpBar());

            this.KeyDown += new KeyEventHandler(player.KeyDown);
            this.KeyUp += new KeyEventHandler(player.KeyUp);
        }


        private void InitializeTimer()
        {
            this.gameTimer.Interval = 16;
            this.gameTimer.Start();
            this.timeSinceGameStart = 0;
        }

        private void InitializeMap()
        {
            MapFabric mapMaker = new MapFabric();

            this.map = mapMaker.MakeMap(this.settings.GetDifficulty());
        }

        public void InitializeGame()
        {
            this.DespawnAll();
            this.InitializeMap();
            this.InitializePlayer();
            this.InitializeTimer();
            this.score = 0;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gameTimer.Stop();
            this.settings = new Settings();

            using (this.settings)
            {
                if(this.settings.ShowDialog() == DialogResult.OK)
                {
                    return;
                }
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InitializeGame();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ц,Ф,Ы,В - перемещение\n К - использование подобранного предмета\n ПРОБЕЛ - стрелять");
        }
    }
}