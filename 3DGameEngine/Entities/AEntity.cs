using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Model;
using Microsoft.Xna.Framework;

namespace GameEngine.Entities
{
    public abstract class AEntity : IEntity
    {

        #region Member fields
        private Model3D _model;
        #endregion Member fields

        #region Constructor
        public AEntity(Model3D model)
        {
            _model = model;
        }
        #endregion Constructor

        public Model3D GetModel()
        {
            return _model;
        }

        public Vector3 GetPosition()
        {
            return _model.GetPosition();
        }

        public virtual void Update()
        {
            _model.Update();
        }
    }
}
