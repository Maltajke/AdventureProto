﻿using ECS.Views;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public abstract class LinkableView : MonoBehaviour, ILinkable
	{
		private EcsEntity _entity;

		public int Hash => transform.GetHashCode();
		public Transform Transform => transform;
		public int UnityInstanceId => gameObject.GetInstanceID();

		public virtual void Link(EcsEntity entity)
		{
			_entity = entity;
		}

		protected virtual void DestroyObject()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
				Destroy(gameObject);
			else
				DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
		}
	}
}