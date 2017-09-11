using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoAppBLL;
using VideoAppBLL.BO;

namespace VideoRestAPI
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();
                var vid = facade.VideoService.Create(
                    new VideoBO()
                    {
                        Title = "Gaurdian of the Galaxzy",
                        Genre = "Adventure",
                        Year = 2015
                    });
                facade.VideoService.Create(
                    new VideoBO()
                    {
                        Title = "Gaurdian of the Galaxzy 2",
                        Genre = "Adventure",
                        Year = 2017
                    });

                facade.RentalService.Create(
                    new RentalBO()
                    {
                        OrderDate = DateTime.Now,
                        DeliveryDate = DateTime.Now.AddDays(7),
                        Video = vid

                    });

            }

            app.UseMvc();
        }
    }
}
