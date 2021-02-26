using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class ObjectView : LinkableView
	{
		public override void Link(EcsEntity entity)
		{
			base.Link(entity);
			var e = entity;
		}
	}
}