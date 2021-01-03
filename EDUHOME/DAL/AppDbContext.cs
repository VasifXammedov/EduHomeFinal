using EDUHOME.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Choose> Chooses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<WelcomeToEdu> WelcomeToEdus { get; set; }
        public DbSet<AboutCarousel> AboutCarousels { get; set; }
        public DbSet<AboutNotice> AboutNotices { get; set; }
        public DbSet<AboutVideo> AboutVideos { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<LatestPostDetail> LatestPostDetails { get; set; }
        public DbSet<TagsDetail> TagsDetails { get; set; }
        public DbSet<BestDetailesWorkshop> BestDetailesWorkshops { get; set; }
        public DbSet<SpeakerBest> SpeakerBests { get; set; }
        public DbSet<KamranTeacherDetail> KamranTeacherDetails { get; set; }
        public DbSet<ContactTeacherDetail> ContactTeacherDetails { get; set; }
        public DbSet<SkillsTeacherDetail> SkillsTeacherDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>()
                            .HasOne(b => b.BlogDetail)
                            .WithOne(b => b.Blog)
                            .HasForeignKey<BlogDetail>(BlogDetail => BlogDetail.BlogId);
            modelBuilder.Entity<Course>()
                   .HasOne(a => a.CourseDetail)
                   .WithOne(a => a.Course)
                   .HasForeignKey<CourseDetail>(c => c.CourseId);
            modelBuilder.Entity<Teacher>()
                                  .HasOne(a => a.TeacherDetail)
                                  .WithOne(a => a.Teacher)
                                  .HasForeignKey<TeacherDetail>(c => c.TeacherId);
            //modelBuilder.Entity<Course>()
            //               .HasOne(b => b.CourseDetailEncineering)
            //               .WithOne(b => b.Course)
            //               .HasForeignKey<CourseDetailEncineering>(c => c.CourseId);
        }
       
    }

}

