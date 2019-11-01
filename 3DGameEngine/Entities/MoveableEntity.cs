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
        private Vector3 _translationVector;
        private float _entitySpeed;
        #endregion Member fields

        public MoveableEntity(Vector3 position, float entitySpeed, GraphicsDevice graphicsDevice, Model3D model) : 
            base(model)
        {
            _entitySpeed = entitySpeed;
            _translationVector = Vector3.Zero;
        }

        public void SetTranslationVector(Vector3 translationVector)
        {
            if (translationVector != Vector3.Zero)
            {
                translationVector.Normalize();
            }
            _translationVector = translationVector * _entitySpeed;
            GetModel().SetTranslationVector(_translationVector);
            //_model.Translate(_translationVector);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
