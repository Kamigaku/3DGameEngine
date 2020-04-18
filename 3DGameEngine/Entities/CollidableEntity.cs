using GameEngine.Datas;
using GameEngine.Geometry;
using GameEngine.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Entities
{
    public class CollidableEntity : AEntity
    {

        #region Member fields
        private float _width;
        private float _height;
        private float _depth;
        private Collider _collider;
        #endregion Member fields

        #region Events
        public event EventHandler<EventArgs> OnCollisionEnter;
        public event EventHandler<EventArgs> OnCollisionExit;
        #endregion Events

        #region Properties
        public Vector3 HalfSize 
        {
            get { return new Vector3(_width / 2, _height / 2, _depth / 2); }
        }

        protected Collider Collider 
        {
            get { return _collider; }
        }
        #endregion Properties

        public CollidableEntity(Model3D model, float width, float height, float depth) : base(model)
        {
            _width = width;
            _height = height;
            _depth = depth;

            Vector3 min = model.Transform.Position - HalfSize;
            Vector3 max = model.Transform.Position + HalfSize;

            _collider = new Collider(this, min, max);

            // Register collider
            EngineDatas.Colliders.Add(_collider);
        }

        public override void Update()
        {
            base.Update();
            /*Logging.Logger.Debug("Set the box position to : " + GetModel().Transform.Position);
            Logging.Logger.Debug("==================");*/
            _collider.SetBoxPosition(GetModel().Transform.Position - HalfSize, GetModel().Transform.Position + HalfSize);

            /*for (int i = 0; i < EngineDatas.Colliders.Count; i++)
            {
                Collider currentCollider = EngineDatas.Colliders[i];
                if (currentCollider != _collider)
                {
                    if (_collider.Intersects(currentCollider))
                    {
                        OnCollisionEnter?.Invoke(this, null);
                    }
                }
            }*/
        }

        public Collider Intersects(Vector3 boxPosition)
        {
            //Logging.Logger.Debug("Simulate box to : " + boxPosition);
            Vector3 oldPosition = GetModel().Transform.Position;
            _collider.SetBoxPosition(boxPosition - HalfSize, boxPosition + HalfSize);

            for (int i = 0; i < EngineDatas.Colliders.Count; i++)
            {
                Collider currentCollider = EngineDatas.Colliders[i];
                if (currentCollider != _collider)
                {
                    if (_collider.Intersects(currentCollider))
                    {
                        return currentCollider;
                    }
                }
            }
            _collider.SetBoxPosition(oldPosition - HalfSize, oldPosition + HalfSize);
            return null;
        }

    }
}
