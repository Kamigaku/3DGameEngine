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
            GetModel().SetTranslationVector(translationVector * _entitySpeed);
        }

        /// <summary>
        /// Set the rotation vector with a Vector representing yaw, pitch and roll values
        /// </summary>
        /// <param name="rotationVector">The rotation's vector representing pitch, yaw and roll</param>
        public void SetRotationValues(Vector3 rotationVector)
        {
            GetModel().SetRotationValues(rotationVector);
        }

        /// <summary>
        /// Set the rotation vector with yaw, pitch and roll value
        /// </summary>
        /// <param name="yaw">The rotation around Y-axis</param>
        /// <param name="pitch">The rotation around X-axis</param>
        /// <param name="roll">The rotation around Z-axis</param>
        public void SetRotationValues(float yaw, float pitch, float roll)
        {
            SetRotationValues(new Vector3(yaw, pitch, roll));
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
