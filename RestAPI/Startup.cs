using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoAppBLL;
using VideoAppBLL.BO;


namespace RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //    var facade = new BLLFacade();

            //    // GENRES
            //    var drama = facade.GenreService.Create(
            //        new GenreBO()
            //        {
            //            Name = "Drama"
            //        });
            //    var adventure = facade.GenreService.Create(
            //        new GenreBO()
            //        {
            //            Name = "Adventure"
            //        });
            //    var thriller = facade.GenreService.Create(
            //        new GenreBO()
            //        {
            //            Name = "Thriller"
            //        });

            //    // VIDEOES
            //    var vid1 = facade.VideoService.Create(
            //        new VideoBO()
            //        {
            //            Title = "Gaurdian of the Galaxy",
            //            PricePrDay = 10,
            //            Year = 2015,
            //            //GenreId = adventure.Id,
            //            GenreIds = new List<int>() { adventure.Id, thriller.Id}
            //        });
            //    var vid2 = facade.VideoService.Create(
            //        new VideoBO()
            //        {
            //            Title = "Gaurdian of the Galaxy 2",
            //            PricePrDay = 20,
            //            Year = 2017,
            //            //GenreId = drama.Id
            //            GenreIds = new List<int>() { drama.Id, adventure.Id }

            //        });

            //    // RENTALS
            //    var rental1 = facade.RentalService.Create(
            //        new RentalBO()
            //        {
            //            OrderDate = DateTime.Now,
            //            DeliveryDate = DateTime.Now.AddDays(7),
            //            VideoId = vid1.Id
            //        });
            //    var rental2 = facade.RentalService.Create(
            //        new RentalBO()
            //        {
            //            OrderDate = DateTime.Now.AddDays(2),
            //            DeliveryDate = DateTime.Now.AddDays(9),
            //            VideoId = vid2.Id
            //        });

            //    // USERS
            //    var user1 = facade.UserService.Create(
            //        new UserBO()
            //        {
            //            Username = "Brugernavn1",
            //            Password = "Password1",
            //            RentalId = rental1.Id
            //        });
            //    var user2 = facade.UserService.Create(new UserBO()
            //    {
            //        Username = "Brugernavn2",
            //        Password = "Password2",
            //        RentalId = rental2.Id
            //    });
            

            app.UseMvc();
        }
    }
}