using System;
using System.Collections.Generic;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Properties
{
	public interface IProperty<T> : IVariable<T>, IObservableContext
	{
		void Store(IContext context, T value);
	}

	public abstract class Property : Variable, IProperty<object>
	{
		protected readonly Dictionary<IContext, WeakReference<IOutput>> m_Cache = new Dictionary<IContext, WeakReference<IOutput>>();
#if UNITY_EDITOR
		public Dictionary<IContext, WeakReference<IOutput>> EditorGetCache() => m_Cache;
#endif
		public sealed override object Load(IContext context)
		{
			return LoadObject(context);
		}

		protected abstract object LoadObject(IContext context);

		public abstract void Store(IContext context, object value);

		public bool IsChanging(IContext context)
		{
			return GetOutput(context).IsChanging();
		}

		public void Subscribe(IContext context, Callback callback)
		{
			GetOutput(context).Subscribe(callback);
		}

		public void Unsubscribe(IContext context, Callback callback)
		{
			GetOutput(context).Unsubscribe(callback);
		}

		protected abstract IOutput GetOutput(IContext context);
	}

	public class Property<T> : Property, IProperty<T>
	{
		protected sealed override object LoadObject(IContext context)
		{
			return Load(context);
		}

		public sealed override void Store(IContext context, object value)
		{
			if (value != null && !typeof(T).IsAssignableFrom(value.GetType()))
			{
				Debug.LogAssertion($"Cannot store {value} to {typeof(T)}");
			}
			else
			{
				Store(context, (T)value);
			}
		}

		protected sealed override IOutput GetOutput(IContext context)
		{
			return Resolve(context);
		}

		public new T Load(IContext context)
		{
			return Resolve(context).Get();
		}

		public void Store(IContext context, T value)
		{
			Resolve(context).Set(value);
		}

		private IOutput<T> Resolve(IContext context)
		{
			if (m_Cache.TryGetValue(context, out var reference))
			{
				if (reference.TryGetTarget(out var cache))
				{
					return cache as IOutput<T>;
				}

				// Reference expired, resolve again 
				IOutput<T> target = null; //Resolver.FromBehaviour<T>(name, context.GetBehaviour());
				reference.SetTarget(target);
				return target;
			}

			// First time
			IOutput<T> output = null; //Resolver.FromBehaviour<T>(name, context.GetBehaviour());
			reference = new WeakReference<IOutput>(output);

			m_Cache.Add(context, reference);
			return output;
		}

		private void OnContextDestroy(IContext context)
		{
			m_Cache.Remove(context);
		}
	}
}
