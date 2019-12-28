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
        private Vector3 _translationVector = Vector3.Zero;
        private Vector3 _rotationVector = Vector3.Zero;
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
            _translationVector = translationVector * _entitySpeed;
            GetModel().SetTranslationVector(_translationVector);
        }

        public void SetRotationVector(Vector3 rotationVector)
        {
            _rotationVector = rotationVector;
            GetModel().SetRotationVector(_rotationVector);
        }

        public void SetRotationVector(float yaw, float pitch, float roll)
        {
            SetRotationVector(new Vector3(yaw, pitch, roll));
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
