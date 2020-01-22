using GameEngine.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Entities
{
    public abstract class MoveableEntity : AEntity
    {

        #region Member fields
        private float _entitySpeed;
        #endregion Member fields

        public MoveableEntity(float entitySpeed, Model3D model) : 
            base(model)
        {
            _entitySpeed = entitySpeed;
        }


        public void SetTranslationVector(Vector3 translationVector)
        {
            if (translationVector != Vector3.Zero)
            {
                translationVector.Normalize();
            }
            GetModel().Transform.SetTranslationVelocity(translationVector * _entitySpeed);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
