using System;

namespace Poc.MobileApp.Shared.Data
{
	public class Entity : IEquatable<Entity>
	{
		public DateTime DataCriacao { get; set; }
		public DateTime DataAlteracao { get; set; }

		private Guid _entityId;

		protected Entity()
		{

		}

		protected Entity(Guid entityId)
		{
			if (Equals(entityId, default(Guid)))
			{
				throw new ArgumentException("The ID cannot be the default value.", "id");
			}

			_entityId = entityId;
		}

		public Guid EntityId
		{
			get { return _entityId; }
			set { _entityId = value; }
		}

		public override bool Equals(object obj)
		{
			var entity = obj as Entity;
			if (entity != null)
			{
				return Equals(entity);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return EntityId.GetHashCode();
		}

		public bool Equals(Entity other)
		{
			if (other == null)
			{
				return false;
			}
			return EntityId.Equals(other.EntityId);
		}
	}
}