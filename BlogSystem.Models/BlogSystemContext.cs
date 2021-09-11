using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlogSystem.Models
{
    public class BlogSystemContext : DbContext
    {
        public BlogSystemContext()
        :base("BlogDbCon")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<AdminsPermission> AdminsPermission { get; set; }
        public virtual DbSet<SystemMenu> SystemMenu { get; set; }
        public virtual DbSet<WebMenu> WebMenu { get; set; }
        public virtual DbSet<Seo> Seo { get; set; }
        public virtual DbSet<FriendLink> FriendLink { get; set; }
        public virtual DbSet<Copyright> Copyright { get; set; }


        //下面的内容是前台数据库

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<BlogPermission> BlogPermission { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<PhotoWall> PhotoWall { get; set; }



    }
}