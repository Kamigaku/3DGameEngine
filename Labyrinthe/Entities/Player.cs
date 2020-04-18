using GameEngine.Entities;
using GameEngine.Model;
using Labyrinthe.Datas;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Entities
{

    // L'utilité de cette classe est à remettre en cause. Elle se contente uniquement de faire tourner le personnage "joueur" en fonction
    // de l'orientation de la caméra
    public class Player : MoveableEntity
    {
        public Player(Model3D model, float width, float height, float depth, Vector3 translationVelocity, Vector3 angularVelocity) 
            : base(model, width, height, depth, translationVelocity, angularVelocity) {}

        public override void Update()
        {
            SetRotationVector(new Vector3(0f,
                                          GameDatas.MainCamera.Transform.EulerAngles.Y - GetModel().Transform.EulerAngles.Y,
                                          0f));
            base.Update();
        }
    }
}
