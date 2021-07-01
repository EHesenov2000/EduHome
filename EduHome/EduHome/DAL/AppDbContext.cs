using EduHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AboutEduHome> AboutEduHomes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<NoticeBoardItem> NoticeBoardItems { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EventTags> EventTags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<EventTeachers> EventTeachers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<CourseTags> CourseTags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
