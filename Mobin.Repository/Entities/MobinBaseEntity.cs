using Mobin.Common.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mobin.Repository.Entities
{
    public class AuditableEntity
    {
        protected DateTime CreateAudit_Date { get; set; }
        protected DateTime LastModifiedAudit_Date { get; set; }
        protected string CreateAudit_UserName { get; set; }
        protected string LastModifiedAudit_UserName { get; set; }
        protected string CreateAudit_IP { get; set; }
        protected string LastModifiedAudit_IP { get; set; }
    }

    public interface IMobinBaseEntity<TKey> : IMobinBaseEntity
    {
        TKey ID { get; set; }
    }

    /// <summary>
    /// This entity define a base key for eny entity inherited from this class with property name ID
    /// </summary>
    /// <typeparam name="TKey">Typeof key</typeparam>
    public class MobinBaseEntity<TKey> : MobinBaseEntity,IMobinBaseEntity<TKey>
    //AuditableEntity 
    {
        [Key]
        public virtual TKey ID { get; set; }
    }
}
