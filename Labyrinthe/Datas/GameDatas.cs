using GameEngine.Camera;
using GameEngine.Controllers;
using GameEngine.Entities;
using GameEngine.Input;
using GameEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Datas
{
    public static class GameDatas
    {

        #region Controls
        public static GameInput Keyboard { get; private set; }
        public static List<AEntity> Entities { get; private set; }
        public static ACamera MainCamera { get; set; }
        #endregion Controls

        #region Graphics Datas
        public static int Width { get; set; }
        public static int Height { get; set; }
        #endregion Graphics Datas

        #region Constructor
        static GameDatas()
        {
            Keyboard = new GameInput();
            Entities = new List<AEntity>();
            Width = 480;
            Height = 800;
        }
        #endregion Constructor

    }
}
