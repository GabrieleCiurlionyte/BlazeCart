﻿using System;
namespace Models
{
    // IF ANY CHANGE TO A CLASS FIELD(S) IS DONE
    // A DATABASE MIGRATION IS NECESSARY
    public class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? ModifiedOn { get; set; } = DateTime.Now;

        protected virtual object Actual => this;

        public override bool Equals(object obj)
        {
            if (!(obj is Entity other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Actual.GetType() != other.Actual.GetType())
            {
                return false;
            }

            if (Id == default || other.Id == default)
            {
                return false;
            }

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }
    }
}

