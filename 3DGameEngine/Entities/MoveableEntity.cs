using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Geometry;
using GameEngine.Model;
using Microsoft.Xna.Framework;

namespace GameEngine.Entities
{
    public class MoveableEntity : CollidableEntity
    {

        #region Member fields
        private Vector3 _translationVelocity;
        private Vector3 _angularVelocity;
        private Vector3 _translationVector;
        #endregion Member fields

        #region Constructor
        public MoveableEntity(Model3D model, float width, float height, float depth, Vector3 translationVelocity, Vector3 angularVelocity) 
            : base(model, width, height, depth)
        {
            _translationVelocity = translationVelocity;
            _angularVelocity = angularVelocity;
            OnCollisionEnter += CollisionEnter;
        }
        #endregion Constructor

        public void SetTranslationVector(Vector3 translationVector)
        {
            if (translationVector != Vector3.Zero)
            {
                translationVector.Normalize();
            }
            //GetModel().Transform.SetTranslationVelocity(translationVector * _translationVelocity);
            _translationVector = translationVector * _translationVelocity;
        }

        public void SetRotationVector(Vector3 rotationVector)
        {
            // If we conserve the normalize method, it rotate slower than the camera
            /*if (rotationVector != Vector3.Zero)
            {
                rotationVector.Normalize();
            }*/
            GetModel().Transform.SetRotationVelocity(rotationVector * _angularVelocity);
        }

        public override void Update()
        {

            // We should now move this part of code inside the "CollisionEnter" method
            Vector3 translationVelocity = GetModel().Transform.SimulatePosition(_translationVector);
            if (Intersects(GetModel().Transform.SimulateTranslation(
                    new Vector3(translationVelocity.X, translationVelocity.Y, translationVelocity.Z)).Translation) != null)
            {
                Collider collideWith;
                if ((collideWith = Intersects(GetModel().Transform.SimulateTranslation(new Vector3(translationVelocity.X, 0f, 0f)).Translation)) != null) 
                {
                    CollidableEntity entityCollide = (CollidableEntity)collideWith.GetBoundedEntity();
                    float collideWithPositionX = collideWith.GetBoundedEntity().GetModel().Transform.Position.X;
                    float currentPositionX = GetModel().Transform.Position.X;
                    float deltaCenterPosition = collideWithPositionX - currentPositionX;
                    if (currentPositionX < collideWithPositionX)
                    {
                        deltaCenterPosition += -HalfSize.X + -entityCollide.HalfSize.X - 0.00001f;
                    }
                    else
                    {
                        deltaCenterPosition += HalfSize.X + entityCollide.HalfSize.X + 0.00001f;
                    }
                    translationVelocity.X = deltaCenterPosition;
                }
                if ((collideWith = Intersects(GetModel().Transform.SimulateTranslation(new Vector3(0f, translationVelocity.Y, 0f)).Translation)) != null)
                {
                    CollidableEntity entityCollide = (CollidableEntity)collideWith.GetBoundedEntity();
                    float collideWithPositionY = entityCollide.GetModel().Transform.Position.Y;
                    float currentPositionY = GetModel().Transform.Position.Y;
                    float deltaCenterPosition = collideWithPositionY - currentPositionY;
                    if (currentPositionY < collideWithPositionY)
                    {
                        deltaCenterPosition += (HalfSize.Y * -1) + (entityCollide.HalfSize.Y * -1) - 0.00001f;
                    }
                    else
                    {
                        deltaCenterPosition += HalfSize.Y + entityCollide.HalfSize.Y + 0.00001f;
                    }
                    translationVelocity.Y = deltaCenterPosition;
                    translationVelocity.Y = 0;
                }
                if ((collideWith = Intersects(GetModel().Transform.SimulateTranslation(new Vector3(0f, 0f, translationVelocity.Z)).Translation)) != null)
                {
                    CollidableEntity entityCollide = (CollidableEntity)collideWith.GetBoundedEntity();
                    float collideWithPositionZ = collideWith.GetBoundedEntity().GetModel().Transform.Position.Z;
                    float currentPositionZ = GetModel().Transform.Position.Z;
                    float deltaCenterPosition = collideWithPositionZ - currentPositionZ;
                    if (currentPositionZ < collideWithPositionZ)
                    {
                        deltaCenterPosition += (HalfSize.Z * -1) + (entityCollide.HalfSize.Z * -1) - 0.00001f;
                    }
                    else
                    {
                        deltaCenterPosition += HalfSize.Z + entityCollide.HalfSize.Z + 0.00001f;
                    }
                    translationVelocity.Z = deltaCenterPosition;
                }
            }
            GetModel().Transform.SetTranslationVelocity(translationVelocity);
            base.Update();
        }

        public override void CollisionEnter(object sender, EventArgs e)
        {
            //GetModel().Transform.SetTranslationVelocity(Vector3.Zero);
            Logging.Logger.Debug("Collision has happened");
        }

    }
}
