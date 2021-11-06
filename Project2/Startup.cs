using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Data;

namespace Project2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //testc comment
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<Database_Resource>(options =>
            {
                options.UseSqlServer(Configuration.GetValue<string>("CONNECTION"));
               
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Database_Resource db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

           // RunTestDatabase(db);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

       /* public void RunTestDatabase(Database_Resource db)
        {
            var originalUser = new Data.Entities.User()

            
           
            {
                UserId = Guid.NewGuid(),
                UserName = "Admin",
                UserPassword = "admin"
            } ;



            //Add to database
            db.Users.Add(originalUser);
            db.SaveChanges();

            //Update database
            var updatedUser = originalUser;
            originalUser.UserName = "admin";
            db.Update(updatedUser);
            db.SaveChanges();

            //Delete from database
           // db.Users.Remove(db.Users.FirstOrDefault(x => x.UserId == originalUser.UserId));
            //db.SaveChanges();


            //Lookup from database
            var list = db.Users.AsNoTracking().ToList(); // Query without altering, then you don't need to SaveChanges

            var entity = db.Users.FirstOrDefault(x => x.UserName.Contains("admin")); //singular entity
                                                                                     // var entity = db.Users.Where(x => x.UserName.Contains("admin")); //list of all entities with admin
                                                                                     // var entity = db.Users.Any(x => x.UserName.Contains("admin")); //Boolean of all entities with admin

            //var entityWithQuestions = db.Tests.AsNoTracking().FirstOrDefault(x => x.Name.Contains("test") && x.Questions.Where(z=> z.Answer.Contains("2")));
            //var entityWithQuestions = db.Tests.AsNoTracking()
            //   .Include(x => x.Questions).FirstOrDefault(XmlConfigurationExtensions => XmlConfigurationExtensions.Name.Contatins("test")); 

            string t = "";
            



        }*/

    }
}
