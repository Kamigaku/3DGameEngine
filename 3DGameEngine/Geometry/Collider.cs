using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Geometry
{
    // TODO : créer une classe Collider qui contiendra l'entité, la boundingbox, qui possèdera une méthode Instersect
    // le data engine possédera une liste de Collider,
    // Notion de layer ?
    public class Collider
    {

        #region Member variables
        private BoundingBox _colliderBox;
        private IEntity _boundedEntity;
        #endregion Member variables

        public Collider(IEntity boundedEntity, Vector3 min, Vector3 max)
        {
            _colliderBox = new BoundingBox();
            _boundedEntity = boundedEntity;
            SetBoxPosition(min, max);
        }

        public IEntity GetBoundedEntity()
        {
            return _boundedEntity;
        }

        public void SetBoxPosition(Vector3 min, Vector3 max)
        {
            _colliderBox.Min = min;
            _colliderBox.Max = max;
        }

        public bool Intersects(Collider collider)
        {
            return _colliderBox.Intersects(collider._colliderBox);
        }

    }
}
