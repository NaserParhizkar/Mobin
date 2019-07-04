using System;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
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

    public interface IBaseEntity<TKey>
    { 
        TKey ID { get; set; }
    }


    /// <summary>
    /// This entity define a base key for eny entity inherited from this class with property name ID
    /// </summary>
    /// <typeparam name="TKey">Typeof key</typeparam>
    public class BaseEntity<TKey> : AuditableEntity ,IBaseEntity<TKey>
    {
        [Key]
        public TKey ID { get; set; }
    }
}
