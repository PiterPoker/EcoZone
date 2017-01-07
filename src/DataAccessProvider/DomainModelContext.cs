using Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessProvider
{
    public class DomainModelContext : IdentityDbContext<ApplicationUser>
    {
        public DomainModelContext(DbContextOptions<DomainModelContext> options)
            : base(options)
        {
        }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<BlockType> BlockTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UnitTags> UnitTags { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Block>().HasKey(block => block.Id);
            builder.Entity<BlockType>().HasKey(type => type.Id);
            builder.Entity<Comment>().HasKey(comment => comment.Id);
            builder.Entity<Like>().HasKey(like => like.Id);
            builder.Entity<Tag>().HasKey(tag => tag.Id);
            builder.Entity<Unit>().HasKey(unit => unit.Id);
            builder.Entity<UnitTags>().HasKey(ul => new {ul.TagId, ul.UnitId});

            builder.Entity<Block>()
                .HasOne(block => block.Type)
                .WithMany(types => types.Blocks)
                .HasForeignKey(block => block.TypeId);
            builder.Entity<Block>().HasIndex(block => block.TypeId);

            builder.Entity<Block>()
                .HasOne(block => block.Unit)
                .WithMany(types => types.Blocks)
                .HasForeignKey(block => block.UnitId);
            builder.Entity<Block>().HasIndex(block => block.UnitId);

            builder.Entity<Comment>()
                .HasOne(comment => comment.Author)
                .WithMany(comments => comments.Comments)
                .HasForeignKey(comment => comment.AuthorId);
            builder.Entity<Comment>().HasIndex(comment => comment.AuthorId);

            builder.Entity<Comment>()
                .HasOne(comment => comment.Unit)
                .WithMany(comments => comments.Comments)
                .HasForeignKey(comment => comment.UnitId);
            builder.Entity<Comment>().HasIndex(comment => comment.UnitId);

            builder.Entity<Like>()
                .HasOne(like => like.Author)
                .WithMany(like => like.Likes)
                .HasForeignKey(like => like.AuthorId);
            builder.Entity<Like>().HasIndex(like => like.AuthorId);

            builder.Entity<Like>()
                .HasOne(like => like.Unit)
                .WithMany(like => like.Likes)
                .HasForeignKey(like => like.UnitId);
            builder.Entity<Like>().HasIndex(like => like.UnitId);

            builder.Entity<Unit>()
                .HasOne(unit => unit.Author)
                .WithMany(unit => unit.Units)
                .HasForeignKey(unit => unit.AuthorId);
            builder.Entity<Like>().HasIndex(unit => unit.AuthorId);

            builder.Entity<UnitTags>()
                .HasOne(ut => ut.Unit)
                .WithMany(unit => unit.Tags)
                .HasForeignKey(ut => ut.UnitId);
            builder.Entity<UnitTags>().HasIndex(ut => ut.UnitId);

            builder.Entity<UnitTags>()
                .HasOne(ut => ut.Tag)
                .WithMany(tag => tag.Units)
                .HasForeignKey(ut => ut.TagId);
            builder.Entity<UnitTags>().HasIndex(ut => ut.TagId);

            base.OnModelCreating(builder);
        }
    }
}