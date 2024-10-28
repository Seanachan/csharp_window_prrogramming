using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Configuration;
using static NCKU_hw6_2.Form1;


namespace NCKU_hw6_2
{
    public partial class Form1 : Form
    {
        
        private const int blockSize = 64;
        private const int rows = 15;
        private const int columns = 30;
        private Panel hotbar;
        private Panel blockPanel;
        public Image img_grass, img_dirt, img_stone;
        public Steve steve;
        public static BlockType selectedBlock;
        private Panel pausePanel = new Panel();
        private bool mapInitialized = false;

        private Vector2F _playerVelocity = new Vector2F(0, 0);
        private bool _isJumping = false;
        private const float Gravity = 0.6f;
        private const float JumpStrength = -9f;
        private const int cellWidth = 48;
        public GameState state;

        Timer gameTimer = new Timer();
        public enum BlockType
        {
            Grass,
            Dirt,
            Stone,
            Air //no block
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left || e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                Console.WriteLine("keyup");
                _playerVelocity.X = 0; // Stop horizontal movement when key is released
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            map.Padding = new Padding(0);
            map.Margin = new Padding(0);
            map.AutoSize=false;
            
            //KeyDown +=OnKeyDown;
            KeyUp += OnKeyUp;
            this.KeyPreview = true;
            this.Controls.Add(pausePanel);
            pausePanel.Controls.Add(resumeGame);
            pausePanel.Controls.Add(save_and_backhome);
            pausePanel.Size = new Size(978, 781);

            //stevePanel.BackColor = Color.Transparent;
            pictureBox1.BackColor= Color.Transparent;
            setVisibleGame(false);
            setVisibleHome(true);
            setVisiblePause(false);
            setScrollBar();
            setFlowLayout();
            this.BackgroundImage = Image.FromFile("background.jpg");
            this.BackColor = Color.Gray;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            img_grass = Image.FromFile("img_grass.png"); img_dirt = Image.FromFile("img_dirt.png"); img_stone = Image.FromFile("img_stone.png");

            gameTimer.Interval = 14; // Roughly 60 FPS
            gameTimer.Tick += GameUpdate;
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void setFlowLayout()
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.AutoSize=false;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(this.ClientSize.Height-flowLayoutPanel1.Size.Height*2, this.ClientSize.Width/2);
            flowLayoutPanel1.Location = new Point(this.ClientSize.Width/2-flowLayoutPanel1.Width/2, this.ClientSize.Height-3*flowLayoutPanel1.Height);
            flowLayoutPanel1.Size = new Size(blockSize*5, blockSize+5);
        }
        private void removeMap()
        {
            for (int i = 0; i<rows; i++)
            {
                for (int j = 0; j<columns; j++)
                {
                    Control controlToRemove = map.GetControlFromPosition(j, i);
                    map.Controls.Remove(controlToRemove);
                }
            }
        }
        private void setMap()
        {
            mapInitialized = true;
            map.BackColor = Color.Gray;
            for (int i = 0; i<rows; i++)
            {
                for (int j = 0; j<columns; j++)
                {
                    if (i>9)
                    {
                        Block newBlock = new Block(BlockType.Stone);
                        //Console.Write(newBlock.Size.Width);
                        map.Controls.Add(newBlock, j, i);
                        Block b = (Block) map.GetControlFromPosition(j,i);
                        //Console.WriteLine(b.Size.Width);
                    }
                    else if (i>6)
                    {
                        Block newBlock = new Block(BlockType.Dirt);
                        map.Controls.Add(newBlock, j, i);
                    }
                    else if (i>5)
                    {
                        Block newBlock = new Block(BlockType.Grass);
                        map.Controls.Add(newBlock, j, i);
                    }
                    else
                    {
                        Block newBlock = new Block(BlockType.Air);
                        map.Controls.Add(newBlock, j, i);
                    }
                }
            }
        }
        private void setScrollBar()
        {
            hScrollBar1.Size = new Size(this.ClientSize.Width, 25);
            vScrollBar1.Size = new Size(25, this.ClientSize.Height);
            hScrollBar1.Location = new Point(0, this.ClientSize.Height-hScrollBar1.Height);
            vScrollBar1.Location = new Point(this.ClientSize.Width-vScrollBar1.Width, 0);

            hScrollBar1.Maximum = blockSize*29-this.ClientSize.Width-40;
            vScrollBar1.Maximum=blockSize*14-this.ClientSize.Height-3;
        }
        private void AddSteve()
        {
            if(steve!=null) steve.Dispose();
            steve = new Steve(0, blockSize*4-2);
            
            steve.Location = new Point((int)steve.position.X,(int)steve.position.Y);
            
            this.Controls.Add(steve);
            steve.BringToFront();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            map.Left = -hScrollBar1.Value;
            UpdateStevePosition();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            map.Top = -vScrollBar1.Value;
            UpdateStevePosition();
        }

        private void SetupHotbar()
        {
            FlowLayoutPanel hotbar = new FlowLayoutPanel
            {
                Height = blockSize+2,
                Width = blockSize*9,
                BackColor = Color.Transparent,
            };

            // Create buttons for each block type
            Button grassButton = new Button { Text = "Grass", BackgroundImage=img_grass,BackgroundImageLayout=ImageLayout.Stretch, Size = new Size(blockSize, blockSize) };
            Button dirtButton = new Button { Text = "Dirt", BackgroundImage=img_dirt, BackgroundImageLayout=ImageLayout.Stretch, Size = new Size(blockSize, blockSize) };
            Button stoneButton = new Button { Text = "Stone", BackgroundImage=img_stone, BackgroundImageLayout = ImageLayout.Stretch, Size = new Size(blockSize, blockSize) };

            // Hook up event handlers to set the selected block type
            grassButton.Click += (s, e) => selectedBlock = (BlockType.Grass);
            dirtButton.Click += (s, e) => selectedBlock = (BlockType.Dirt);
            stoneButton.Click += (s, e) => selectedBlock = (BlockType.Stone);

            // Add buttons to hotbar panel
            hotbar.Controls.Add(grassButton);
            hotbar.Controls.Add(dirtButton);
            hotbar.Controls.Add(stoneButton);

            // Add hotbar to form
            flowLayoutPanel1.Controls.Add(hotbar);
        }
        public void UpdateStevePosition()
        {
            float xOffset = map.Left + steve.position.X; 
            float yOffset = map.Top + steve.position.Y;
            
            steve.Location = new Point((int) xOffset, (int) yOffset);
        }
        private void setVisibleGame(bool visible)
        {
            if (visible)
            {
                map.Visible = true;
                if(steve!=null) steve.Visible = true;
                vScrollBar1.Visible= true;
                hScrollBar1.Visible= true;
                flowLayoutPanel1.Visible = true;
                gameTimer.Start();
            }
            else
            {
                map.Visible = false;
                if(steve!=null) steve.Visible = false;
                vScrollBar1.Visible= false;
                hScrollBar1.Visible= false;
                flowLayoutPanel1.Visible = false;
                gameTimer.Stop();
            }
        }
        private void setVisibleHome(bool b)
        {
            if (b)
            {
                startGame.Visible = true;
                startGame.Visible = true;
                quitGame.Visible = true;
                openSave.Visible =true;
                pictureBox1.Visible = true;
                this.BackgroundImage=Image.FromFile("background.jpg");
                this.BackColor = Color.DarkGray;
            }
            else
            {
                startGame.Visible = false;
                startGame.Visible = false;
                quitGame.Visible = false ;
                openSave.Visible =false;
                pictureBox1.Visible = false;
                this.BackgroundImage=null;
                this.BackColor = Color.DarkGray;
            }
        }

        private void setVisiblePause(bool visible)
        {
            if (visible)
            {
                resumeGame.Visible = true;
                save_and_backhome.Visible = true;
                pausePanel.Visible = true;
                pausePanel.BringToFront();
            }
            else
            {
                resumeGame.Visible = false;
                save_and_backhome.Visible = false;
                pausePanel.Visible = false;
            }
        }
        private void openSave_Click(object sender, EventArgs e)
        {
            setVisibleHome(false);
            setVisibleGame(true);
            SetupHotbar();
            map.BackColor = Color.Gray;
            if (File.Exists("GameState.dat"))
            {
                GameState state = LoadGameState("GameState.dat");
                RestoreGameState(state);
            }
            else
            {
                MessageBox.Show("No save file found.");
            }

        }

        private void quitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resumeGame_Click(object sender, EventArgs e)
        {
            setVisiblePause(false);
        }

        private void save_and_backhome_Click(object sender, EventArgs e)
        {
            setVisiblePause(false);
            setVisibleGame(false);
            setVisibleHome(true);
            state = CreateGameState();
            SaveGameState("GameState.dat");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if(this.BackgroundImage==null&& e.KeyCode == Keys.Escape)
            {
                pausePanel.BackColor = Color.FromArgb(128,Color.Black);
                setVisiblePause(true);
                
                return;
            }
            if (map.Visible==false) return;
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    //MessageBox.Show("press up");
                    //Console.WriteLine("predd up");
                    Jump();
                    break;
                case Keys.A:
                case Keys.Left:
                    MoveLeft();
                    //Console.WriteLine("predd left");
                    break;
                case Keys.D:
                case Keys.Right:
                    //Console.WriteLine("predd right");
                    MoveRight();
                    break;
            }
            //Console.WriteLine();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            //steve = null;
            AddSteve();
            if(!mapInitialized)setMap();
            else
            {
                removeMap();
                setMap();
            }
            setVisibleHome(false);
            setVisibleGame(true);
            SetupHotbar();
        }
        private bool IsBlocked_up(Vector2F position)
        {
            int x = (int)steve.position.X;
            int y = (int)steve.position.Y;
            int x2 = (int)steve.position.X+steve.Size.Width;

            int row = (y-5)/blockSize;
            int col = (x+2)/blockSize;
            int col2 = (x2-2)/blockSize;

            try
            {
                Block left = (Block)map.GetControlFromPosition(col, row);
                Block right = (Block)map.GetControlFromPosition(col2, row);
                //Console.WriteLine("{0}, {1}", right.Location.X, right.Location.Y);
                //Console.WriteLine("{0}, {1}", steve.Right, steve.Top);
                //Console.WriteLine(row);
                //Console.WriteLine(col);

                //Console.WriteLine("steve: {0},{1}", x, y);
                //Console.WriteLine("steve: {0},{1}", x/blockSize, y/blockSize);
                return (left.type != BlockType.Air)||(right.type != BlockType.Air);
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        private bool IsBlocked_right(Vector2F position)
        {
            int x = (int)steve.Left+blockSize;
            int y = steve.Top;
            Console.WriteLine("map: {0},{1}",map.Left,map.Top);
            int row = (y+5)/blockSize;
            int col = (x+1)/blockSize;
            //y+=steve.Height/2;
            try
            {
                Block right = (Block)map.GetControlFromPosition(col, row);
                Block right_bot = (Block)map.GetControlFromPosition(col, row+1);
                Block right_mid = (Block)map.GetControlFromPosition(col, (y+30)/blockSize);

                return (right_mid.type!=BlockType.Air)||(right_bot.type != BlockType.Air)||(right.type != BlockType.Air); // Assumes non-null _blocks entries are obstacles
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return true;
            }
        }
        private bool IsBlocked_left(Vector2F position)
        {
            int x = (int)steve.Left;
            int y = (int) steve.Location.Y;
            int row = (y+3)/blockSize;
            int col = (x-5)/blockSize;
            //y+=steve.Height/2;
            try
            {
                Block left = (Block)map.GetControlFromPosition(col, row);
                Block left_bot = (Block)map.GetControlFromPosition(col, row+1);
                Block left_mid = (Block)map.GetControlFromPosition(col, (y+40)/blockSize);

                return (left_mid.type!=BlockType.Air)||(left_bot.type != BlockType.Air)||(left.type != BlockType.Air);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        private bool IsOnGround()
        {
            //int x = steve.Left;
            //int y=steve.Bottom;

            //int x2 = steve.Right;
            int x = (int) steve.position.X;
            int y = (int)steve.position.Y+steve.Size.Height;
            int x2 = (int)steve.position.X+steve.Size.Width;

            int row = (y+5)/blockSize;
            int col = (x+2)/blockSize;
            int col2= (x2-2)/blockSize;

            try
            {
                Block left = (Block)map.GetControlFromPosition(col, row);
                Block right = (Block)map.GetControlFromPosition(col2, row);
                Console.WriteLine("{0}, {1}", right.Location.X, right.Location.Y);
                Console.WriteLine("{0}, {1}", steve.Right, steve.Top);
                Console.WriteLine(row);
                Console.WriteLine(col);

                Console.WriteLine("steve: {0},{1}", x, y);
                Console.WriteLine("steve: {0},{1}", x/blockSize, y/blockSize);
                return (left.type != BlockType.Air)||(right.type != BlockType.Air);
            }
            catch (Exception ex)
            {
                return true;
            }

        }

        private void GameUpdate(object sender, EventArgs e)
        {
            steve.position.Y += _playerVelocity.Y;
            UpdateStevePosition();
            if (!IsOnGround())
            {
                Console.WriteLine("on the ground");
                _playerVelocity.Y += Gravity;
            }
            else
            {
                _playerVelocity.Y = 0;
                _isJumping = false;

            }

            if (steve.position.X+_playerVelocity.X>0 && steve.position.X+_playerVelocity.X+steve.Width<map.Size.Width)
            {
                if(_playerVelocity.X<0&&!IsBlocked_left(steve.position+_playerVelocity))
                    steve.position.X += _playerVelocity.X;
                else if (_playerVelocity.X>0&&!IsBlocked_right(steve.position+_playerVelocity))
                {
                    steve.position.X += _playerVelocity.X;
                }
                //_playerVelocity.X=0;

            }
            
            

            UpdateStevePosition();
        }
        public void MoveLeft()
        {
            Vector2F newPosition = steve.position + new Vector2F(-1.5f, 0);
            if (steve.Left>10)
            {
                //!IsBlocked_left(newPosition)&&
                //steve.position = newPosition;
                //UpdateStevePosition();
                _playerVelocity.X = -1.5f;
            }
        }

        private void MoveRight()
        {
            Vector2F newPosition = steve.position + new Vector2F(1.5f, 0);
            if (steve.Right<map.Size.Width-10)
            {
                //!IsBlocked_right(newPosition)&&
                Console.WriteLine("yes");
                //steve.position = newPosition;
                //UpdateStevePosition();
                _playerVelocity.X = 1.5f;
            }
        }

        private void Jump()
        {
            if (!_isJumping && IsOnGround()&& !IsBlocked_up(steve.position))
            {
                
                Console.WriteLine("Jump");
                _playerVelocity.Y = JumpStrength;
                _isJumping = true;
            }
        }
        private GameState LoadGameState(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (GameState)formatter.Deserialize(fs);
            }
        }

        private void RestoreGameState(GameState state)
        {
            // Restore Steve's position
            AddSteve();
            steve.position = state.StevePosition;
            UpdateStevePosition();
            setVisibleGame(true);
            // Restore map
            map.Controls.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    BlockType type = state.MapState[i, j];
                    Block newBlock = new Block(type);
                    map.Controls.Add(newBlock, j, i);
                }
            }
        }
        private void SaveGameState(string filename)
        {
            state = CreateGameState(); // Create the game state to save
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, state);
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            MessageBox.Show("Game state saved successfully!");
        }


        private GameState CreateGameState()
        {
            GameState s = new GameState(rows, columns, steve.position);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Block block = (Block)map.GetControlFromPosition(j, i);
                    s.MapState[i, j] = block?.type ?? BlockType.Air;
                }
            }

            return s;
        }

    }
    [Serializable]
    public class GameState
    {
        private const int rows = 15, columns = 30;
        public BlockType[,] MapState { get; set; }  // Array representing the type of each block
        public Vector2F StevePosition { get; set; } // Position of Steve
        public GameState(int rows, int columns, Vector2F stevePosition)
        {
            MapState = new BlockType[rows, columns];
            StevePosition = stevePosition;
        }
    }
}
