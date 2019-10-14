﻿using System;
using CoreDX.Domain.Core.Entity;

namespace CoreDX.Domain.Model.Entity.Security
{
    /// <summary>
    /// 权限声明基类
    /// </summary>
    /// <typeparam name="TPermissionDefinitionKey">权限定义主键类型</typeparam>
    /// <typeparam name="TIdentityKey">身份主键类型</typeparam>
    public abstract class PermissionDeclarationBase<TPermissionDefinitionKey, TIdentityKey> : ManyToManyReferenceEntityBase<TIdentityKey>
        , IOptimisticConcurrencySupported
        , ILastModificationTimeRecordable
        where TPermissionDefinitionKey : struct, IEquatable<TPermissionDefinitionKey>
        where TIdentityKey : struct, IEquatable<TIdentityKey>
    {
        /// <summary>
        /// 权限值
        /// </summary>
        public virtual short PermissionValue { get; set; }

        /// <summary>
        /// 权限定义Id
        /// </summary>
        public virtual TPermissionDefinitionKey? PermissionDefinitionId { get; set; }

        /// <summary>
        /// 权限定义
        /// </summary>
        public virtual PermissionDefinition<TPermissionDefinitionKey, TIdentityKey> PermissionDefinition { get; set; }

        /// <summary>
        /// 并发标记
        /// </summary>
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTimeOffset LastModificationTime { get; set; } = DateTimeOffset.Now;
    }

    /// <summary>
    /// 角色权限声明
    /// </summary>
    public abstract class RolePermissionDeclaration<TPermissionDefinitionKey, TIdentityKey> : PermissionDeclarationBase<TPermissionDefinitionKey, TIdentityKey>
        where TPermissionDefinitionKey : struct, IEquatable<TPermissionDefinitionKey>
        where TIdentityKey : struct, IEquatable<TIdentityKey>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public TIdentityKey? RoleId { get; set; }
    }

    /// <summary>
    /// 用户权限声明
    /// </summary>
    public abstract class UserPermissionDeclaration<TPermissionDefinitionKey, TIdentityKey> : PermissionDeclarationBase<TPermissionDefinitionKey, TIdentityKey>
        where TPermissionDefinitionKey : struct, IEquatable<TPermissionDefinitionKey>
        where TIdentityKey : struct, IEquatable<TIdentityKey>
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public TIdentityKey? UserId { get; set; }
    }

    /// <summary>
    /// 组织权限声明
    /// </summary>
    public abstract class OrganizationPermissionDeclaration<TPermissionDefinitionKey, TIdentityKey> : PermissionDeclarationBase<TPermissionDefinitionKey, TIdentityKey>
        where TPermissionDefinitionKey : struct, IEquatable<TPermissionDefinitionKey>
        where TIdentityKey : struct, IEquatable<TIdentityKey>
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        public TIdentityKey? OrganizationId { get; set; }
    }
}
