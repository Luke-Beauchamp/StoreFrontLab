﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommunitySpaceShipData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CommunitySpaceShipEntities : DbContext
    {
        public CommunitySpaceShipEntities()
            : base("name=CommunitySpaceShipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Neighbor> Neighbors { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<SpaceShip> SpaceShips { get; set; }
        public virtual DbSet<SpaceShipStatus> SpaceShipStatuses { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TeamFocu> TeamFocus { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }
}
