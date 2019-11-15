using System;
using UnityEngine;

namespace MazeObjects
{
	public abstract class Feature
	{
		protected bool [,] uniqueObjects;

        protected Feature()
        {
        }

        Feature(bool [,] uniqueObjects)
		{
			this.uniqueObjects = uniqueObjects;
        }

        public abstract void Build();

        public abstract void Update();
	}
}