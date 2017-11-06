﻿using System.Diagnostics.CodeAnalysis;
using FluentNHibernate.Mapping;

namespace ShoppingCart.Data.User
{
    public class UserRecord
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class UserRecordMap : ClassMap<UserRecord>
    {
        public UserRecordMap()
        {
            Table("users");
            Id(x => x.Id);
            Map(x => x.Email);
            Map(x => x.Password);
        }
    }
}